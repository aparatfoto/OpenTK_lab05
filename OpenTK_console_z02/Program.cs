using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_console_z02 {
    internal class SimpleWindow3D : GameWindow {

        const float rotation_speed = 180.0f;
        float angle;
        bool showCube = true;
        KeyboardState lastKeyPress;
        private const int XYZ_SIZE = 75;
        private bool axesControl = true;
        private bool trans1 = false;
        private bool trans2 = false;

        private int[,] objVertices = {
            {5, 10, 5,
                                      10, 5, 10,
                5, 10, 5,
                10, 5, 10,
                5, 5, 5,
                5, 5, 5,
                5, 10, 5,
                10, 10, 5,
                10, 10, 10,
                10, 10, 10,
                5, 10, 5,
                10, 10, 5},
                                     {5, 5, 12,
                                         5, 12, 12,
                                         5, 5, 5,
                                         5, 5, 5,
                                         5, 12, 5,
                                         12, 5, 12,
                                         12, 12, 12,
                                         12, 12, 12,
                                         5, 12, 5,
                                         12, 5, 12,
                                         5, 5, 12,
                                         5, 12, 12},
                                     {6, 6, 6,
                                         6, 6, 6,
                                         6, 6, 12,
                                         6, 12, 12,
                                         6, 6, 12,
                                         6, 12, 12,
                                         6, 6, 12,
                                         6, 12, 12,
                                         6, 6, 12,
                                         6, 12, 12,
                                         12, 12, 12,
                                         12, 12, 12}};
        private Color[] colorVertices = { Color.White, Color.LawnGreen, Color.WhiteSmoke, Color.Tomato, Color.Turquoise, Color.OldLace, Color.Olive, Color.MidnightBlue, Color.PowderBlue, Color.PeachPuff, Color.LavenderBlush, Color.MediumAquamarine };
        private bool trans3;

        private SimpleWindow3D() : base(800, 600) {
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            showCube = true;
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            MouseState mouse = OpenTK.Input.Mouse.GetState();

            // Se utilizeaza mecanismul de control input oferit de OpenTK (include perifcerice multiple, inclusiv
            // pentru gaminig - gamepads, joysticks, etc.).
            if (keyboard[OpenTK.Input.Key.Escape]) {
                this.Exit();
                return;
            } else if (keyboard[OpenTK.Input.Key.P] && !keyboard.Equals(lastKeyPress)) {
                // Ascundere comandată, prin apăsarea unei taste - cu verificare de remanență! Timpul de reacție
                // uman << calculator.
                if (showCube) {
                    showCube = false;
                } else {
                    showCube = true;
                }
            } else if (keyboard[OpenTK.Input.Key.Z] && !keyboard.Equals(lastKeyPress)) {
                trans1 = true;
            } else if (keyboard[OpenTK.Input.Key.X] && !keyboard.Equals(lastKeyPress)) {
                trans2 = !trans2;
            }else if (keyboard[OpenTK.Input.Key.Y] && !keyboard.Equals(lastKeyPress))
            {
                trans3 = !trans3;
            }
            lastKeyPress = keyboard;


            if (mouse[OpenTK.Input.MouseButton.Left]) {
                // Ascundere comandată, prin clic de mouse - fără testare remanență.
                if (showCube) {
                    showCube = false;
                } else {
                    showCube = true;
                }
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //GL.LoadIdentity();

            //angle += rotation_speed * (float)e.Time;
            // GL.Rotate(angle, 0.0f, 1.0f, 0.0f);

            if (axesControl) {
                DrawAxes();
            }

            if (showCube == true) {
                if (trans1) {
                    GL.Translate(1, 0, 0);
                    trans1 = false;
                }
                DrawCube();
            }

            if (showCube == true)
            {
                if (trans2)
                {
                    GL.Translate(0, 1, 0);
                    trans1 = false;
                }
                DrawCube();
            }

            if (showCube == true)
            {
                if (trans3)
                {
                    GL.Translate(0, 0, 1);
                    trans1 = false;
                }
                DrawCube();
            }

            this.SwapBuffers();
        }

        private void DrawAxes() {
            // Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);
            GL.End();

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;
            GL.End();

            // Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }

        private void DrawCube() {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 35; i = i + 3) {
                //For i As Integer = 0 To 35 Step 3
                GL.Color3(colorVertices[i / 3]);
                GL.Vertex3(objVertices[0, i], objVertices[1, i], objVertices[2, i]);
                GL.Vertex3(objVertices[0, i + 1], objVertices[1, i + 1], objVertices[2, i + 1]);
                GL.Vertex3(objVertices[0, i + 2], objVertices[1, i + 2], objVertices[2, i + 2]);
            }
            GL.End();
        }

        [STAThread]
        static void Main(string[] args) {

            using (SimpleWindow3D example = new SimpleWindow3D()) {
                example.Run(30.0, 0.0);
            }

        }
    }
}
