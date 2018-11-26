using System;
using System.Windows.Forms;

namespace Paint
{
    partial class MyPaint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ToolBoxPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TextBoxButton = new System.Windows.Forms.Button();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.PenButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DrawBoxPanel = new System.Windows.Forms.Panel();
            this.colorPanel = new Paint.ColorPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MouseLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.DrawBoxSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolBoxPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBoxPanel
            // 
            this.ToolBoxPanel.ColumnCount = 6;
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 775F));
            this.ToolBoxPanel.Controls.Add(this.TextBoxButton, 4, 0);
            this.ToolBoxPanel.Controls.Add(this.EllipseButton, 3, 0);
            this.ToolBoxPanel.Controls.Add(this.RectangleButton, 2, 0);
            this.ToolBoxPanel.Controls.Add(this.PenButton, 0, 0);
            this.ToolBoxPanel.Controls.Add(this.LineButton, 1, 0);
            this.ToolBoxPanel.Controls.Add(this.colorPanel, 5, 0);
            this.ToolBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBoxPanel.Location = new System.Drawing.Point(0, 28);
            this.ToolBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ToolBoxPanel.Name = "ToolBoxPanel";
            this.ToolBoxPanel.RowCount = 1;
            this.ToolBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolBoxPanel.Size = new System.Drawing.Size(1340, 105);
            this.ToolBoxPanel.TabIndex = 0;
            // 
            // TextBoxButton
            // 
            this.TextBoxButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxButton.Image = global::MyPaint.Properties.Resources.text3;
            this.TextBoxButton.Location = new System.Drawing.Point(455, 2);
            this.TextBoxButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBoxButton.Name = "TextBoxButton";
            this.TextBoxButton.Size = new System.Drawing.Size(107, 101);
            this.TextBoxButton.TabIndex = 4;
            this.TextBoxButton.UseVisualStyleBackColor = true;
            this.TextBoxButton.Click += new System.EventHandler(this.TextBoxButton_Click);
            // 
            // EllipseButton
            // 
            this.EllipseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EllipseButton.Image = global::MyPaint.Properties.Resources.ellipse;
            this.EllipseButton.Location = new System.Drawing.Point(342, 2);
            this.EllipseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(107, 101);
            this.EllipseButton.TabIndex = 2;
            this.EllipseButton.TabStop = false;
            this.EllipseButton.UseVisualStyleBackColor = true;
            this.EllipseButton.Click += new System.EventHandler(this.EllipseButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RectangleButton.Image = global::MyPaint.Properties.Resources.rectangle;
            this.RectangleButton.Location = new System.Drawing.Point(229, 2);
            this.RectangleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(107, 101);
            this.RectangleButton.TabIndex = 0;
            this.RectangleButton.TabStop = false;
            this.RectangleButton.UseVisualStyleBackColor = true;
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // PenButton
            // 
            this.PenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PenButton.Image = global::MyPaint.Properties.Resources.pencil;
            this.PenButton.Location = new System.Drawing.Point(3, 2);
            this.PenButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PenButton.Name = "PenButton";
            this.PenButton.Size = new System.Drawing.Size(107, 101);
            this.PenButton.TabIndex = 9;
            this.PenButton.TabStop = false;
            this.PenButton.UseVisualStyleBackColor = true;
            this.PenButton.Click += new System.EventHandler(this.PenButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineButton.Image = global::MyPaint.Properties.Resources.line1;
            this.LineButton.Location = new System.Drawing.Point(116, 2);
            this.LineButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(107, 101);
            this.LineButton.TabIndex = 0;
            this.LineButton.TabStop = false;
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1340, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.FileOpen,
            this.FileSave,
            this.FileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // FileNew
            // 
            this.FileNew.Name = "FileNew";
            this.FileNew.Size = new System.Drawing.Size(146, 26);
            this.FileNew.Text = "New        ";
            this.FileNew.Click += new System.EventHandler(this.FileNew_Click);
            // 
            // FileOpen
            // 
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.Size = new System.Drawing.Size(146, 26);
            this.FileOpen.Text = "Open";
            this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
            // 
            // FileSave
            // 
            this.FileSave.Name = "FileSave";
            this.FileSave.Size = new System.Drawing.Size(146, 26);
            this.FileSave.Text = "Save";
            this.FileSave.Click += new System.EventHandler(this.FileSave_Click);
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.Size = new System.Drawing.Size(146, 26);
            this.FileExit.Text = "Exit";
            this.FileExit.Click += new System.EventHandler(this.FileExit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DrawBoxPanel
            // 
            this.DrawBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawBoxPanel.AutoScroll = true;
            this.DrawBoxPanel.AutoSize = true;
            this.DrawBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DrawBoxPanel.Location = new System.Drawing.Point(0, 138);
            this.DrawBoxPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DrawBoxPanel.Name = "DrawBoxPanel";
            this.DrawBoxPanel.Size = new System.Drawing.Size(1339, 430);
            this.DrawBoxPanel.TabIndex = 2;
            // 
            // colorPanel
            // 
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPanel.Location = new System.Drawing.Point(569, 4);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(400, 97);
            this.colorPanel.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MouseLocation,
            this.DrawBoxSize});
            this.statusStrip1.Location = new System.Drawing.Point(0, 565);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1340, 29);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MouseLocation
            // 
            this.MouseLocation.AutoSize = false;
            this.MouseLocation.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.MouseLocation.Name = "MouseLocation";
            this.MouseLocation.Size = new System.Drawing.Size(175, 24);
            this.MouseLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DrawBoxSize
            // 
            this.DrawBoxSize.AutoSize = false;
            this.DrawBoxSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.DrawBoxSize.Name = "DrawBoxSize";
            this.DrawBoxSize.Size = new System.Drawing.Size(175, 24);
            this.DrawBoxSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 594);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.DrawBoxPanel);
            this.Controls.Add(this.ToolBoxPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MyPaint";
            this.Text = "Form1";
            this.ToolBoxPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TableLayoutPanel ToolBoxPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem FileNew;
        private ToolStripMenuItem FileOpen;
        private ToolStripMenuItem FileSave;
        private ToolStripMenuItem FileExit;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button TextBoxButton;
        private Button EllipseButton;
        private Button RectangleButton;
        private Button PenButton;
        private Button LineButton;
        private Panel DrawBoxPanel;
        private ColorPanel colorPanel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel MouseLocation;
        private ToolStripStatusLabel DrawBoxSize;
    }
}

