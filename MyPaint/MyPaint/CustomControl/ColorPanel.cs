using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class ColorPanel : UserControl
    {
        public ColorPanel()
        {
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            InitializeComponent();
        }

        private System.Windows.Forms.Button Red;
        private System.Windows.Forms.Button Blue;
        private System.Windows.Forms.Button Yellow;
        private System.Windows.Forms.Button Green;
        private System.Windows.Forms.Button Orange;
        private System.Windows.Forms.Button White;
        private System.Windows.Forms.Button Black;
        private System.Windows.Forms.Button Brown;
        private System.Windows.Forms.Button Purple;
        private System.Windows.Forms.TextBox ShowColor;
        private System.Windows.Forms.Button Morecolor;
        private System.Windows.Forms.ColorDialog colorDialog1;

        private void Morecolor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ShowColor.BackColor = colorDialog1.Color;
            }
        }
        public Color GetCurrentColor()
        {
            return ShowColor.BackColor;
        }
        private void Red_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.Red;
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.Blue;
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.Yellow;
        }

        private void Green_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.Green;
        }

        private void Orange_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.Orange;
        }

        private void White_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.White;
        }

        private void Black_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.Black;
        }

        private void Brown_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.Brown;
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            ShowColor.BackColor = Color.Purple;
        }
        private void InitializeComponent()
        {
            this.Red = new System.Windows.Forms.Button();
            this.Blue = new System.Windows.Forms.Button();
            this.Yellow = new System.Windows.Forms.Button();
            this.Green = new System.Windows.Forms.Button();
            this.Orange = new System.Windows.Forms.Button();
            this.White = new System.Windows.Forms.Button();
            this.Black = new System.Windows.Forms.Button();
            this.Brown = new System.Windows.Forms.Button();
            this.Purple = new System.Windows.Forms.Button();
            this.ShowColor = new System.Windows.Forms.TextBox();
            this.Morecolor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.Red;
            this.Red.Location = new System.Drawing.Point(50, 11);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(22, 21);
            this.Red.TabIndex = 0;
            this.Red.TabStop = false;
            this.Red.UseVisualStyleBackColor = false;
            this.Red.Click += new System.EventHandler(this.Red_Click);
            // 
            // Blue
            // 
            this.Blue.BackColor = System.Drawing.Color.Blue;
            this.Blue.Location = new System.Drawing.Point(78, 11);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(22, 21);
            this.Blue.TabIndex = 1;
            this.Blue.TabStop = false;
            this.Blue.UseVisualStyleBackColor = false;
            this.Blue.Click += new System.EventHandler(this.Blue_Click);
            // 
            // Yellow
            // 
            this.Yellow.BackColor = System.Drawing.Color.Yellow;
            this.Yellow.Location = new System.Drawing.Point(106, 11);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(22, 21);
            this.Yellow.TabIndex = 2;
            this.Yellow.TabStop = false;
            this.Yellow.UseVisualStyleBackColor = false;
            this.Yellow.Click += new System.EventHandler(this.Yellow_Click);
            // 
            // Green
            // 
            this.Green.BackColor = System.Drawing.Color.Green;
            this.Green.Location = new System.Drawing.Point(134, 11);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(22, 21);
            this.Green.TabIndex = 3;
            this.Green.TabStop = false;
            this.Green.UseVisualStyleBackColor = false;
            this.Green.Click += new System.EventHandler(this.Green_Click);
            // 
            // Orange
            // 
            this.Orange.BackColor = System.Drawing.Color.Orange;
            this.Orange.Location = new System.Drawing.Point(162, 11);
            this.Orange.Name = "Orange";
            this.Orange.Size = new System.Drawing.Size(22, 21);
            this.Orange.TabIndex = 4;
            this.Orange.TabStop = false;
            this.Orange.UseVisualStyleBackColor = false;
            this.Orange.Click += new System.EventHandler(this.Orange_Click);
            // 
            // White
            // 
            this.White.BackColor = System.Drawing.Color.White;
            this.White.Location = new System.Drawing.Point(50, 38);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(22, 21);
            this.White.TabIndex = 5;
            this.White.TabStop = false;
            this.White.UseVisualStyleBackColor = false;
            this.White.Click += new System.EventHandler(this.White_Click);
            // 
            // Black
            // 
            this.Black.BackColor = System.Drawing.Color.Black;
            this.Black.Location = new System.Drawing.Point(78, 38);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(22, 21);
            this.Black.TabIndex = 6;
            this.Black.TabStop = false;
            this.Black.UseVisualStyleBackColor = false;
            this.Black.Click += new System.EventHandler(this.Black_Click);
            // 
            // Brown
            // 
            this.Brown.BackColor = System.Drawing.Color.Brown;
            this.Brown.Location = new System.Drawing.Point(106, 38);
            this.Brown.Name = "Brown";
            this.Brown.Size = new System.Drawing.Size(22, 21);
            this.Brown.TabIndex = 7;
            this.Brown.TabStop = false;
            this.Brown.UseVisualStyleBackColor = false;
            this.Brown.Click += new System.EventHandler(this.Brown_Click);
            // 
            // Purple
            // 
            this.Purple.BackColor = System.Drawing.Color.Purple;
            this.Purple.Location = new System.Drawing.Point(134, 38);
            this.Purple.Name = "Purple";
            this.Purple.Size = new System.Drawing.Size(22, 21);
            this.Purple.TabIndex = 8;
            this.Purple.TabStop = false;
            this.Purple.UseVisualStyleBackColor = false;
            this.Purple.Click += new System.EventHandler(this.Purple_Click);
            // 
            // ShowColor
            // 
            this.ShowColor.BackColor = System.Drawing.Color.Black;
            this.ShowColor.Location = new System.Drawing.Point(15, 26);
            this.ShowColor.Name = "ShowColor";
            this.ShowColor.Size = new System.Drawing.Size(19, 22);
            this.ShowColor.TabIndex = 9;
            this.ShowColor.TabStop = false;
            // 
            // Morecolor
            // 
            this.Morecolor.Location = new System.Drawing.Point(162, 38);
            this.Morecolor.Name = "Morecolor";
            this.Morecolor.Size = new System.Drawing.Size(22, 23);
            this.Morecolor.TabIndex = 10;
            this.Morecolor.TabStop = false;
            this.Morecolor.Text = "...";
            this.Morecolor.UseVisualStyleBackColor = true;
            this.Morecolor.Click += new System.EventHandler(this.Morecolor_Click);
            // 
            // ColorPanel
            // 
            this.Controls.Add(this.Morecolor);
            this.Controls.Add(this.ShowColor);
            this.Controls.Add(this.Purple);
            this.Controls.Add(this.Brown);
            this.Controls.Add(this.Black);
            this.Controls.Add(this.White);
            this.Controls.Add(this.Orange);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Yellow);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.Red);
            this.Name = "ColorPanel";
            this.Size = new System.Drawing.Size(203, 72);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }




}
