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
        private TableLayoutPanel tableLayoutPanel1;
        private Label colorPanelLabel;
        private Label rightColorLabel;
        private Label leftColorLabel;
        private Button cyanButton;
        private Button yellowButton;
        private Button purpleButton;
        private Button pinkButton;
        private Button brownButton;
        private Button grayButton;
        private Button orangeButton;
        private Button blueButton;
        private Button greenButton;
        private Button redButton;
        private Button whiteButton;
        private Button blackButton;
        private Button rightColorButton;
        private Button leftColorButton;

        public ColorPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.leftColorButton = new System.Windows.Forms.Button();
            this.rightColorButton = new System.Windows.Forms.Button();
            this.blackButton = new System.Windows.Forms.Button();
            this.whiteButton = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.orangeButton = new System.Windows.Forms.Button();
            this.grayButton = new System.Windows.Forms.Button();
            this.brownButton = new System.Windows.Forms.Button();
            this.pinkButton = new System.Windows.Forms.Button();
            this.purpleButton = new System.Windows.Forms.Button();
            this.yellowButton = new System.Windows.Forms.Button();
            this.cyanButton = new System.Windows.Forms.Button();
            this.leftColorLabel = new System.Windows.Forms.Label();
            this.rightColorLabel = new System.Windows.Forms.Label();
            this.colorPanelLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.colorPanelLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rightColorLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.leftColorLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cyanButton, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.yellowButton, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.purpleButton, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.pinkButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.brownButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.grayButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.orangeButton, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.blueButton, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.greenButton, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.redButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.whiteButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.blackButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightColorButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.leftColorButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 80);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // leftColorButton
            // 
            this.leftColorButton.BackColor = System.Drawing.Color.Black;
            this.leftColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftColorButton.Location = new System.Drawing.Point(3, 3);
            this.leftColorButton.Name = "leftColorButton";
            this.tableLayoutPanel1.SetRowSpan(this.leftColorButton, 2);
            this.leftColorButton.Size = new System.Drawing.Size(54, 54);
            this.leftColorButton.TabIndex = 0;
            this.leftColorButton.UseVisualStyleBackColor = false;
            // 
            // rightColorButton
            // 
            this.rightColorButton.BackColor = System.Drawing.Color.White;
            this.rightColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightColorButton.Location = new System.Drawing.Point(63, 3);
            this.rightColorButton.Name = "rightColorButton";
            this.tableLayoutPanel1.SetRowSpan(this.rightColorButton, 2);
            this.rightColorButton.Size = new System.Drawing.Size(54, 54);
            this.rightColorButton.TabIndex = 1;
            this.rightColorButton.UseVisualStyleBackColor = false;
            // 
            // blackButton
            // 
            this.blackButton.BackColor = System.Drawing.Color.Black;
            this.blackButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blackButton.Location = new System.Drawing.Point(123, 3);
            this.blackButton.Name = "blackButton";
            this.blackButton.Size = new System.Drawing.Size(24, 24);
            this.blackButton.TabIndex = 2;
            this.blackButton.UseVisualStyleBackColor = false;
            // 
            // whiteButton
            // 
            this.whiteButton.BackColor = System.Drawing.Color.White;
            this.whiteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whiteButton.Location = new System.Drawing.Point(153, 3);
            this.whiteButton.Name = "whiteButton";
            this.whiteButton.Size = new System.Drawing.Size(24, 24);
            this.whiteButton.TabIndex = 3;
            this.whiteButton.UseVisualStyleBackColor = false;
            // 
            // redButton
            // 
            this.redButton.BackColor = System.Drawing.Color.Red;
            this.redButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redButton.Location = new System.Drawing.Point(183, 3);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(24, 24);
            this.redButton.TabIndex = 4;
            this.redButton.UseVisualStyleBackColor = false;
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.Green;
            this.greenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.greenButton.Location = new System.Drawing.Point(213, 3);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(24, 24);
            this.greenButton.TabIndex = 5;
            this.greenButton.UseVisualStyleBackColor = false;
            // 
            // blueButton
            // 
            this.blueButton.BackColor = System.Drawing.Color.Blue;
            this.blueButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueButton.Location = new System.Drawing.Point(243, 3);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(24, 24);
            this.blueButton.TabIndex = 6;
            this.blueButton.UseVisualStyleBackColor = false;
            // 
            // orangeButton
            // 
            this.orangeButton.BackColor = System.Drawing.Color.Orange;
            this.orangeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orangeButton.Location = new System.Drawing.Point(273, 3);
            this.orangeButton.Name = "orangeButton";
            this.orangeButton.Size = new System.Drawing.Size(24, 24);
            this.orangeButton.TabIndex = 7;
            this.orangeButton.UseVisualStyleBackColor = false;
            // 
            // grayButton
            // 
            this.grayButton.BackColor = System.Drawing.Color.Gray;
            this.grayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grayButton.Location = new System.Drawing.Point(123, 33);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(24, 24);
            this.grayButton.TabIndex = 8;
            this.grayButton.UseVisualStyleBackColor = false;
            // 
            // brownButton
            // 
            this.brownButton.BackColor = System.Drawing.Color.Brown;
            this.brownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brownButton.Location = new System.Drawing.Point(153, 33);
            this.brownButton.Name = "brownButton";
            this.brownButton.Size = new System.Drawing.Size(24, 24);
            this.brownButton.TabIndex = 9;
            this.brownButton.UseVisualStyleBackColor = false;
            // 
            // pinkButton
            // 
            this.pinkButton.BackColor = System.Drawing.Color.Pink;
            this.pinkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinkButton.Location = new System.Drawing.Point(183, 33);
            this.pinkButton.Name = "pinkButton";
            this.pinkButton.Size = new System.Drawing.Size(24, 24);
            this.pinkButton.TabIndex = 10;
            this.pinkButton.UseVisualStyleBackColor = false;
            // 
            // purpleButton
            // 
            this.purpleButton.BackColor = System.Drawing.Color.Purple;
            this.purpleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purpleButton.Location = new System.Drawing.Point(213, 33);
            this.purpleButton.Name = "purpleButton";
            this.purpleButton.Size = new System.Drawing.Size(24, 24);
            this.purpleButton.TabIndex = 11;
            this.purpleButton.UseVisualStyleBackColor = false;
            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = System.Drawing.Color.Yellow;
            this.yellowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yellowButton.Location = new System.Drawing.Point(243, 33);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(24, 24);
            this.yellowButton.TabIndex = 12;
            this.yellowButton.UseVisualStyleBackColor = false;
            // 
            // cyanButton
            // 
            this.cyanButton.BackColor = System.Drawing.Color.Cyan;
            this.cyanButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cyanButton.Location = new System.Drawing.Point(273, 33);
            this.cyanButton.Name = "cyanButton";
            this.cyanButton.Size = new System.Drawing.Size(24, 24);
            this.cyanButton.TabIndex = 13;
            this.cyanButton.UseVisualStyleBackColor = false;
            // 
            // leftColorLabel
            // 
            this.leftColorLabel.AutoSize = true;
            this.leftColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftColorLabel.Location = new System.Drawing.Point(3, 60);
            this.leftColorLabel.Name = "leftColorLabel";
            this.leftColorLabel.Size = new System.Drawing.Size(54, 20);
            this.leftColorLabel.TabIndex = 15;
            this.leftColorLabel.Text = "Color 1";
            this.leftColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightColorLabel
            // 
            this.rightColorLabel.AutoSize = true;
            this.rightColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightColorLabel.Location = new System.Drawing.Point(63, 60);
            this.rightColorLabel.Name = "rightColorLabel";
            this.rightColorLabel.Size = new System.Drawing.Size(54, 20);
            this.rightColorLabel.TabIndex = 16;
            this.rightColorLabel.Text = "Color 2";
            this.rightColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorPanelLabel
            // 
            this.colorPanelLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.colorPanelLabel, 6);
            this.colorPanelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPanelLabel.Location = new System.Drawing.Point(123, 60);
            this.colorPanelLabel.Name = "colorPanelLabel";
            this.colorPanelLabel.Size = new System.Drawing.Size(174, 20);
            this.colorPanelLabel.TabIndex = 17;
            this.colorPanelLabel.Text = "Colors (double-click to edit)";
            this.colorPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorPanel
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorPanel";
            this.Size = new System.Drawing.Size(300, 80);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
