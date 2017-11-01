namespace OpenTK_winforms_sample02 {
    partial class SimpleForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.GlControlDemo = new OpenTK.GLControl();
            this.BtnBKG_Black = new System.Windows.Forms.Button();
            this.BtnBKG_Blue = new System.Windows.Forms.Button();
            this.BtnBKG_Green = new System.Windows.Forms.Button();
            this.ChkAxes = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblMousePos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GlControlDemo
            // 
            this.GlControlDemo.BackColor = System.Drawing.Color.Black;
            this.GlControlDemo.Location = new System.Drawing.Point(13, 13);
            this.GlControlDemo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GlControlDemo.Name = "GlControlDemo";
            this.GlControlDemo.Size = new System.Drawing.Size(875, 527);
            this.GlControlDemo.TabIndex = 0;
            this.GlControlDemo.VSync = false;
            this.GlControlDemo.Load += new System.EventHandler(this.GlControlDemo_Load);
            this.GlControlDemo.Paint += new System.Windows.Forms.PaintEventHandler(this.GlControlDemo_Paint);
            this.GlControlDemo.MouseLeave += new System.EventHandler(this.GlControlDemo_MouseLeave);
            this.GlControlDemo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GlControlDemo_MouseMove);
            this.GlControlDemo.Resize += new System.EventHandler(this.GlControlDemo_Resize);
            // 
            // BtnBKG_Black
            // 
            this.BtnBKG_Black.Location = new System.Drawing.Point(897, 13);
            this.BtnBKG_Black.Name = "BtnBKG_Black";
            this.BtnBKG_Black.Size = new System.Drawing.Size(115, 31);
            this.BtnBKG_Black.TabIndex = 1;
            this.BtnBKG_Black.Text = "Set bg BLACK";
            this.BtnBKG_Black.UseVisualStyleBackColor = true;
            this.BtnBKG_Black.Click += new System.EventHandler(this.BtnBKG_Black_Click);
            // 
            // BtnBKG_Blue
            // 
            this.BtnBKG_Blue.ForeColor = System.Drawing.Color.Blue;
            this.BtnBKG_Blue.Location = new System.Drawing.Point(897, 50);
            this.BtnBKG_Blue.Name = "BtnBKG_Blue";
            this.BtnBKG_Blue.Size = new System.Drawing.Size(115, 31);
            this.BtnBKG_Blue.TabIndex = 2;
            this.BtnBKG_Blue.Text = "Set bg BLUE";
            this.BtnBKG_Blue.UseVisualStyleBackColor = true;
            this.BtnBKG_Blue.Click += new System.EventHandler(this.BtnBKG_Blue_Click);
            // 
            // BtnBKG_Green
            // 
            this.BtnBKG_Green.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnBKG_Green.Location = new System.Drawing.Point(897, 87);
            this.BtnBKG_Green.Name = "BtnBKG_Green";
            this.BtnBKG_Green.Size = new System.Drawing.Size(115, 31);
            this.BtnBKG_Green.TabIndex = 3;
            this.BtnBKG_Green.Text = "Set bg RED";
            this.BtnBKG_Green.UseVisualStyleBackColor = true;
            this.BtnBKG_Green.Click += new System.EventHandler(this.BtnBKG_Green_Click);
            // 
            // ChkAxes
            // 
            this.ChkAxes.AutoSize = true;
            this.ChkAxes.Checked = true;
            this.ChkAxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAxes.Location = new System.Drawing.Point(897, 396);
            this.ChkAxes.Name = "ChkAxes";
            this.ChkAxes.Size = new System.Drawing.Size(60, 21);
            this.ChkAxes.TabIndex = 4;
            this.ChkAxes.Text = "Axes";
            this.ChkAxes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(987, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ox";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(987, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Oy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(987, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Oz";
            // 
            // LblMousePos
            // 
            this.LblMousePos.AutoSize = true;
            this.LblMousePos.Location = new System.Drawing.Point(897, 522);
            this.LblMousePos.Name = "LblMousePos";
            this.LblMousePos.Size = new System.Drawing.Size(0, 17);
            this.LblMousePos.TabIndex = 8;
            // 
            // SimpleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 553);
            this.Controls.Add(this.LblMousePos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkAxes);
            this.Controls.Add(this.BtnBKG_Green);
            this.Controls.Add(this.BtnBKG_Blue);
            this.Controls.Add(this.BtnBKG_Black);
            this.Controls.Add(this.GlControlDemo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SimpleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenTK GLControl demonstrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl GlControlDemo;
        private System.Windows.Forms.Button BtnBKG_Black;
        private System.Windows.Forms.Button BtnBKG_Blue;
        private System.Windows.Forms.Button BtnBKG_Green;
        private System.Windows.Forms.CheckBox ChkAxes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblMousePos;
    }
}

