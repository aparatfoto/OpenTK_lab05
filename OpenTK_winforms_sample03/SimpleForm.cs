using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using OpenTK;

/**
    Aplicația utilizează biblioteca OpenTK v2.0.0 (stable) oficială și OpenTK. GLControl v2.0.0
    (unstable) neoficială. Aplicația fiind scrisă în modul GUI (WinForms) vom utiliza controlul WinForms
    oferit de OpenTK, pe acre îl vom importa in Toolbox! Acest lucru se poate face doar dacă copiem
    local packetul OpenTK.GLControl.dll oferit de NuGet, apoi îl aducem ca referință în Toolbox.
    Tipul de ferestră utilizat: FORM. Se demmonstrează modul imediat de randare (vezi comentariu!)...
**/
namespace OpenTK_winforms_sample02 {

    public partial class SimpleForm : Form {

        private int eyePosX = 100;
        private int eyePosY = 100;
        private int eyePosZ = 50;
        private Point mousePos;
        private bool mouse2DControlStat = true;
        private bool mouse3DControlStat = true;


        // Constructor.
        public SimpleForm() {
            InitializeComponent();
        }

        // Setare mediu OpenGL și încarcarea resurselor (dacă e necesar) - de exemplu culoarea de
        // fundal a controlului 3D.
        // Atenție! Acest cod se execută înainte de desenarea efectivă a scenei 3D.
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            // Ne asigurăm că viewport-ul este setat corect - nu uitați că prima desenare a ferestrei
            // va permite trecerea de la fereastra de mărime (0,0) la cea de mărime specificată - fără
            // un resize vom avea un control de mărime (0,0).
            GlControlDemo_Resize(this, EventArgs.Empty);   // Ensure the Viewport is set up correctly
            GL.ClearColor(Color.GreenYellow);
        }

        // Inițierea afișării și setarea viewport-ului grafic.
        // Viewport-ul va fi dimensionat conform mărimii ferestrei active (cele 2 obiecte pot avea și mărimi 
        // diferite).
        private void GlControlDemo_Resize(object sender, EventArgs e) {
            if (GlControlDemo.ClientSize.Height == 0)
                GlControlDemo.ClientSize = new System.Drawing.Size(GlControlDemo.ClientSize.Width, 1);

            GL.Viewport(0, 0, GlControlDemo.ClientSize.Width, GlControlDemo.ClientSize.Height);
        }

        // Secțiunea de randare a scenei 3D pe controlul GL. Este declanșată de invalidarea acestuia la
        // utilizarea metodei "Invalidate()" (printre altele). Randarea aceasta se poate face programatic
        // (de către sistem) când acesta are nevoie, sau comandat dacă am făcut vreo actualizate în mod
        // explicit în modelul 3D.
        private void GlControlDemo_Paint(object sender, PaintEventArgs e) {
            GlControlDemo.MakeCurrent();

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            //Setări preliminară pentru mediul 3D.
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(0, 0, 0, 0, -1, 1);

            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //float halfWidth = (float)(this.GlControlDemo.Width / 2);
            //float halfHeight = (float)(this.GlControlDemo.Height / 2);
            //GL.Ortho(-halfWidth, halfWidth, halfHeight, -halfHeight, 1000, -1000);
            //GL.Viewport(this.GlControlDemo.Size);

            Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Enable(EnableCap.DepthTest);            //Corecții de adâncime.
            GL.DepthFunc(DepthFunction.Less);

            /*
            // Controlul rotației cu mouse-ul (2D).
            if (mouse2DControlStat == true) {
                GL.Rotate(mousePos.X, 0, 1, 0);
            }
            // Controlul rotației cu mouse-ul (3D).
            if (mouse2DControlStat == true) {
                GL.Rotate(mousePos.X, 0, 1, 1);
            }
            */

            GenerateAxes();

            GlControlDemo.SwapBuffers();
        }

        private void GenerateAxes() {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(75, 0, 0);
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 75, 0);
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 75);
            GL.End();
        }

        [STAThread]
        public static void Main() {

            // Utilizarea cuvântului-cheie "using" va permite dealocarea memoriei o dată ce obiectul nu mai este
            // în uz (vezi metoda "Dispose()").
            // Deoarece scena 3D este desenată pe suprafața unui control WinForms, al cărui "painter" este administrat
            // de .NET, nu putem "forța" redesenarea ferestrei la un framerate prestabilit. În schimb vom invoca
            // metoda "Invalidate()" asupra controlului GL (OpenGL) ori de câte ori cadrul 3D a fost actualizat și este
            // nevoie să desenăm modificările pe canvasul controlului GL ("on-demand" rendering).
            using (SimpleForm sample = new SimpleForm()) {

                //Utilities.SetWindowTitle(example);
                sample.ShowDialog();
            }
        }

        private void BtnBKG_Black_Click(object sender, EventArgs e) {
            GL.ClearColor(Color.Black);
            GlControlDemo.Invalidate();
        }

        private void BtnBKG_Blue_Click(object sender, EventArgs e) {
            GL.ClearColor(Color.MidnightBlue);
            GlControlDemo.Invalidate();
        }

        private void BtnBKG_Green_Click(object sender, EventArgs e) {
            GL.ClearColor(Color.IndianRed);
            GlControlDemo.Invalidate();
        }

        private void GlControlDemo_MouseMove(object sender, MouseEventArgs e) {
            mousePos = new Point(e.X, e.Y);
            LblMousePos.Text = "(" + mousePos.X + "," + mousePos.Y + ")";
        }

        private void GlControlDemo_MouseLeave(object sender, EventArgs e) {
            LblMousePos.Text = "";
        }

        private void GlControlDemo_Load(object sender, EventArgs e) {

        }
    }
}
