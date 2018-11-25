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
            this.ToolLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DrawBoxLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TextBoxButton = new System.Windows.Forms.Button();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.PenButton = new System.Windows.Forms.Button();
            this.colorPanel1 = new Paint.ColorPanel();
            this.ToolLayoutPanel.SuspendLayout();
            this.DrawBoxLayoutPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolLayoutPanel
            // 
            this.ToolLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolLayoutPanel.ColumnCount = 6;
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.41623F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.04318F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.73402F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.80656F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 304F));
            this.ToolLayoutPanel.Controls.Add(this.TextBoxButton, 4, 0);
            this.ToolLayoutPanel.Controls.Add(this.EllipseButton, 3, 0);
            this.ToolLayoutPanel.Controls.Add(this.RectangleButton, 2, 0);
            this.ToolLayoutPanel.Controls.Add(this.LineButton, 1, 0);
            this.ToolLayoutPanel.Controls.Add(this.PenButton, 0, 0);
            this.ToolLayoutPanel.Controls.Add(this.colorPanel1, 5, 0);
            this.ToolLayoutPanel.Location = new System.Drawing.Point(2, 2);
            this.ToolLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ToolLayoutPanel.Name = "ToolLayoutPanel";
            this.ToolLayoutPanel.RowCount = 1;
            this.ToolLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ToolLayoutPanel.Size = new System.Drawing.Size(1001, 85);
            this.ToolLayoutPanel.TabIndex = 2;
            // 
            // DrawBoxLayoutPanel
            // 
            this.DrawBoxLayoutPanel.ColumnCount = 1;
            this.DrawBoxLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DrawBoxLayoutPanel.Controls.Add(this.ToolLayoutPanel, 0, 0);
            this.DrawBoxLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.DrawBoxLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DrawBoxLayoutPanel.Name = "DrawBoxLayoutPanel";
            this.DrawBoxLayoutPanel.RowCount = 2;
            this.DrawBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.38998F));
            this.DrawBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.61002F));
            this.DrawBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.DrawBoxLayoutPanel.Size = new System.Drawing.Size(1005, 459);
            this.DrawBoxLayoutPanel.TabIndex = 0;
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
            // TextBoxButton
            // 
            this.TextBoxButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxButton.Image = global::MyPaint.Properties.Resources.text3;
            this.TextBoxButton.Location = new System.Drawing.Point(545, 18);
            this.TextBoxButton.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxButton.Name = "TextBoxButton";
            this.TextBoxButton.Size = new System.Drawing.Size(48, 48);
            this.TextBoxButton.TabIndex = 4;
            this.TextBoxButton.UseVisualStyleBackColor = true;
            this.TextBoxButton.Click += new System.EventHandler(this.TextBoxButton_Click);
            // 
            // EllipseButton
            // 
            this.EllipseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EllipseButton.Image = global::MyPaint.Properties.Resources.ellipse;
            this.EllipseButton.Location = new System.Drawing.Point(357, 18);
            this.EllipseButton.Margin = new System.Windows.Forms.Padding(2);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(48, 48);
            this.EllipseButton.TabIndex = 2;
            this.EllipseButton.TabStop = false;
            this.EllipseButton.UseVisualStyleBackColor = true;
            this.EllipseButton.Click += new System.EventHandler(this.EllipseButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RectangleButton.Image = global::MyPaint.Properties.Resources.rectangle;
            this.RectangleButton.Location = new System.Drawing.Point(239, 18);
            this.RectangleButton.Margin = new System.Windows.Forms.Padding(2);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(48, 48);
            this.RectangleButton.TabIndex = 0;
            this.RectangleButton.TabStop = false;
            this.RectangleButton.UseVisualStyleBackColor = true;
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LineButton.Image = global::MyPaint.Properties.Resources.line1;
            this.LineButton.Location = new System.Drawing.Point(126, 18);
            this.LineButton.Margin = new System.Windows.Forms.Padding(2);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(48, 48);
            this.LineButton.TabIndex = 0;
            this.LineButton.TabStop = false;
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // PenButton
            // 
            this.PenButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PenButton.Image = global::MyPaint.Properties.Resources.pencil;
            this.PenButton.Location = new System.Drawing.Point(23, 18);
            this.PenButton.Margin = new System.Windows.Forms.Padding(2);
            this.PenButton.Name = "PenButton";
            this.PenButton.Size = new System.Drawing.Size(48, 48);
            this.PenButton.TabIndex = 5;
            this.PenButton.TabStop = false;
            this.PenButton.UseVisualStyleBackColor = true;
            this.PenButton.Click += new System.EventHandler(this.PenButton_Click);
            // 
            // colorPanel1
            // 
            this.colorPanel1.BackColor = System.Drawing.Color.Transparent;
            this.colorPanel1.Location = new System.Drawing.Point(698, 3);
            this.colorPanel1.MaximumSize = new System.Drawing.Size(300, 79);
            this.colorPanel1.MinimumSize = new System.Drawing.Size(300, 79);
            this.colorPanel1.Name = "colorPanel1";
            this.colorPanel1.Size = new System.Drawing.Size(300, 79);
            this.colorPanel1.TabIndex = 6;
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 483);
            this.Controls.Add(this.DrawBoxLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyPaint";
            this.Text = "Form1";
            this.ToolLayoutPanel.ResumeLayout(false);
            this.DrawBoxLayoutPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TableLayoutPanel ToolLayoutPanel;
        private System.Windows.Forms.Button RectangleButton;
        private System.Windows.Forms.TableLayoutPanel DrawBoxLayoutPanel;
        private Button LineButton;
        private Button EllipseButton;
        private Button TextBoxButton;
        private Button PenButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem FileNew;
        private ToolStripMenuItem FileOpen;
        private ToolStripMenuItem FileSave;
        private ToolStripMenuItem FileExit;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ColorPanel colorPanel1;
    }
}

