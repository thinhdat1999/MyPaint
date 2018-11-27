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
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.PenButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.drawPanel = new Paint.DrawPanel();
            this.colorPanel = new Paint.ColorPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DrawBoxPanel = new System.Windows.Forms.Panel();
            this.ToolBoxPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBoxPanel
            // 
            this.ToolBoxPanel.ColumnCount = 6;
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.ToolBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 457F));
            this.ToolBoxPanel.Controls.Add(this.EllipseButton, 3, 0);
            this.ToolBoxPanel.Controls.Add(this.RectangleButton, 2, 0);
            this.ToolBoxPanel.Controls.Add(this.PenButton, 0, 0);
            this.ToolBoxPanel.Controls.Add(this.LineButton, 1, 0);
            this.ToolBoxPanel.Controls.Add(this.drawPanel, 4, 0);
            this.ToolBoxPanel.Controls.Add(this.colorPanel, 5, 0);
            this.ToolBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBoxPanel.Location = new System.Drawing.Point(0, 24);
            this.ToolBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ToolBoxPanel.Name = "ToolBoxPanel";
            this.ToolBoxPanel.RowCount = 1;
            this.ToolBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolBoxPanel.Size = new System.Drawing.Size(1005, 85);
            this.ToolBoxPanel.TabIndex = 0;
            // 
            // EllipseButton
            // 
            this.EllipseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EllipseButton.Location = new System.Drawing.Point(257, 2);
            this.EllipseButton.Margin = new System.Windows.Forms.Padding(2);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(81, 81);
            this.EllipseButton.TabIndex = 2;
            this.EllipseButton.TabStop = false;
            this.EllipseButton.UseVisualStyleBackColor = true;
            // 
            // RectangleButton
            // 
            this.RectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RectangleButton.Location = new System.Drawing.Point(172, 2);
            this.RectangleButton.Margin = new System.Windows.Forms.Padding(2);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(81, 81);
            this.RectangleButton.TabIndex = 0;
            this.RectangleButton.TabStop = false;
            this.RectangleButton.UseVisualStyleBackColor = true;
            // 
            // PenButton
            // 
            this.PenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PenButton.Location = new System.Drawing.Point(2, 2);
            this.PenButton.Margin = new System.Windows.Forms.Padding(2);
            this.PenButton.Name = "PenButton";
            this.PenButton.Size = new System.Drawing.Size(81, 81);
            this.PenButton.TabIndex = 9;
            this.PenButton.TabStop = false;
            this.PenButton.UseVisualStyleBackColor = true;
            // 
            // LineButton
            // 
            this.LineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineButton.Location = new System.Drawing.Point(87, 2);
            this.LineButton.Margin = new System.Windows.Forms.Padding(2);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(81, 81);
            this.LineButton.TabIndex = 0;
            this.LineButton.TabStop = false;
            this.LineButton.UseVisualStyleBackColor = true;
            // 
            // drawPanel
            // 
            this.drawPanel.Location = new System.Drawing.Point(343, 3);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(200, 79);
            this.drawPanel.TabIndex = 11;
            // 
            // colorPanel
            // 
            this.colorPanel.Location = new System.Drawing.Point(551, 3);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(300, 79);
            this.colorPanel.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1005, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // FileNew
            // 
            this.FileNew.Name = "FileNew";
            this.FileNew.Size = new System.Drawing.Size(122, 22);
            this.FileNew.Text = "New        ";
            this.FileNew.Click += new System.EventHandler(this.FileNew_Click);
            // 
            // FileOpen
            // 
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.Size = new System.Drawing.Size(122, 22);
            this.FileOpen.Text = "Open";
            this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
            // 
            // FileSave
            // 
            this.FileSave.Name = "FileSave";
            this.FileSave.Size = new System.Drawing.Size(122, 22);
            this.FileSave.Text = "Save";
            this.FileSave.Click += new System.EventHandler(this.FileSave_Click);
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.Size = new System.Drawing.Size(122, 22);
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
            this.DrawBoxPanel.Location = new System.Drawing.Point(0, 112);
            this.DrawBoxPanel.Name = "DrawBoxPanel";
            this.DrawBoxPanel.Size = new System.Drawing.Size(1005, 371);
            this.DrawBoxPanel.TabIndex = 2;
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 483);
            this.Controls.Add(this.DrawBoxPanel);
            this.Controls.Add(this.ToolBoxPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyPaint";
            this.Text = "Form1";
            this.ToolBoxPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private Button EllipseButton;
        private Button RectangleButton;
        private Button PenButton;
        private Button LineButton;
        private Panel DrawBoxPanel;
        private DrawPanel drawPanel;
        private ColorPanel colorPanel;
    }
}

