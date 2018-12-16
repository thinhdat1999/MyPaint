﻿using System;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPaint));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.MouseLocationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MouseLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.DrawBoxSizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DrawBoxSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FileToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.EditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.DrawBoxPanel = new Paint.DrawBoxPanel();
            this.DrawToolPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolPanel = new Paint.ToolPanel();
            this.shapePanel = new Paint.ShapePanel();
            this.colorPanel = new Paint.ColorPanel();
            this.StyleComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ShapesLabel = new System.Windows.Forms.Label();
            this.ToolLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PenWidthBox = new System.Windows.Forms.NumericUpDown();
            this.statusStrip.SuspendLayout();
            this.ToolsPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.DrawToolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenWidthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MouseLocationLabel,
            this.MouseLocation,
            this.DrawBoxSizeLabel,
            this.DrawBoxSize});
            this.statusStrip.Location = new System.Drawing.Point(0, 500);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(840, 29);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // MouseLocationLabel
            // 
            this.MouseLocationLabel.Image = ((System.Drawing.Image)(resources.GetObject("MouseLocationLabel.Image")));
            this.MouseLocationLabel.Name = "MouseLocationLabel";
            this.MouseLocationLabel.Size = new System.Drawing.Size(20, 24);
            // 
            // MouseLocation
            // 
            this.MouseLocation.AutoSize = false;
            this.MouseLocation.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.MouseLocation.Name = "MouseLocation";
            this.MouseLocation.Size = new System.Drawing.Size(175, 24);
            this.MouseLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DrawBoxSizeLabel
            // 
            this.DrawBoxSizeLabel.Image = ((System.Drawing.Image)(resources.GetObject("DrawBoxSizeLabel.Image")));
            this.DrawBoxSizeLabel.Name = "DrawBoxSizeLabel";
            this.DrawBoxSizeLabel.Size = new System.Drawing.Size(20, 24);
            // 
            // DrawBoxSize
            // 
            this.DrawBoxSize.AutoSize = false;
            this.DrawBoxSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.DrawBoxSize.Name = "DrawBoxSize";
            this.DrawBoxSize.Size = new System.Drawing.Size(175, 24);
            this.DrawBoxSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.ColumnCount = 1;
            this.ToolsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolsPanel.Controls.Add(this.DrawToolPanel, 0, 0);
            this.ToolsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolsPanel.Location = new System.Drawing.Point(0, 24);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.RowCount = 1;
            this.ToolsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.ToolsPanel.Size = new System.Drawing.Size(840, 99);
            this.ToolsPanel.TabIndex = 4;
            // 
            // FileToolStrip
            // 
            this.FileToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.FileOpen,
            this.FileSave,
            this.FileSaveAs,
            this.FileExit});
            this.FileToolStrip.Name = "FileToolStrip";
            this.FileToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FileToolStrip.Size = new System.Drawing.Size(37, 20);
            this.FileToolStrip.Text = "File";
            // 
            // FileNew
            // 
            this.FileNew.Image = ((System.Drawing.Image)(resources.GetObject("FileNew.Image")));
            this.FileNew.Name = "FileNew";
            this.FileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileNew.Size = new System.Drawing.Size(186, 22);
            this.FileNew.Text = "New        ";
            this.FileNew.Click += new System.EventHandler(this.FileNew_Click);
            // 
            // FileOpen
            // 
            this.FileOpen.Image = ((System.Drawing.Image)(resources.GetObject("FileOpen.Image")));
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(186, 22);
            this.FileOpen.Text = "Open";
            this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
            // 
            // FileSave
            // 
            this.FileSave.Image = ((System.Drawing.Image)(resources.GetObject("FileSave.Image")));
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(186, 22);
            this.FileSave.Text = "Save";
            this.FileSave.Click += new System.EventHandler(this.FileSave_Click);
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("FileSaveAs.Image")));
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.FileSaveAs.Size = new System.Drawing.Size(186, 22);
            this.FileSaveAs.Text = "Save As";
            this.FileSaveAs.Click += new System.EventHandler(this.FileSaveAs_Click);
            // 
            // FileExit
            // 
            this.FileExit.Image = ((System.Drawing.Image)(resources.GetObject("FileExit.Image")));
            this.FileExit.Name = "FileExit";
            this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.FileExit.Size = new System.Drawing.Size(186, 22);
            this.FileExit.Text = "Exit";
            this.FileExit.Click += new System.EventHandler(this.FileExit_Click);
            // 
            // EditToolStrip
            // 
            this.EditToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditUndo,
            this.EditRedo});
            this.EditToolStrip.Name = "EditToolStrip";
            this.EditToolStrip.Size = new System.Drawing.Size(39, 20);
            this.EditToolStrip.Text = "Edit";
            // 
            // EditUndo
            // 
            this.EditUndo.Image = ((System.Drawing.Image)(resources.GetObject("EditUndo.Image")));
            this.EditUndo.Name = "EditUndo";
            this.EditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.EditUndo.Size = new System.Drawing.Size(144, 22);
            this.EditUndo.Text = "Undo";
            this.EditUndo.Click += new System.EventHandler(this.EditUndo_Click);
            // 
            // EditRedo
            // 
            this.EditRedo.Image = ((System.Drawing.Image)(resources.GetObject("EditRedo.Image")));
            this.EditRedo.Name = "EditRedo";
            this.EditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.EditRedo.Size = new System.Drawing.Size(144, 22);
            this.EditRedo.Text = "Redo";
            this.EditRedo.Click += new System.EventHandler(this.EditRedo_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStrip,
            this.EditToolStrip});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(840, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // DrawBoxPanel
            // 
            this.DrawBoxPanel.AutoScroll = true;
            this.DrawBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawBoxPanel.Location = new System.Drawing.Point(0, 123);
            this.DrawBoxPanel.Name = "DrawBoxPanel";
            this.DrawBoxPanel.Size = new System.Drawing.Size(840, 377);
            this.DrawBoxPanel.TabIndex = 5;
            // 
            // DrawToolPanel
            // 
            this.DrawToolPanel.ColumnCount = 5;
            this.DrawToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.DrawToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.DrawToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 309F));
            this.DrawToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.DrawToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.DrawToolPanel.Controls.Add(this.toolPanel, 0, 0);
            this.DrawToolPanel.Controls.Add(this.shapePanel, 1, 0);
            this.DrawToolPanel.Controls.Add(this.colorPanel, 2, 0);
            this.DrawToolPanel.Controls.Add(this.StyleComboBox, 4, 0);
            this.DrawToolPanel.Controls.Add(this.label2, 3, 1);
            this.DrawToolPanel.Controls.Add(this.ShapesLabel, 1, 2);
            this.DrawToolPanel.Controls.Add(this.ToolLabel, 0, 2);
            this.DrawToolPanel.Controls.Add(this.label1, 3, 0);
            this.DrawToolPanel.Controls.Add(this.PenWidthBox, 4, 1);
            this.DrawToolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawToolPanel.Location = new System.Drawing.Point(3, 0);
            this.DrawToolPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.DrawToolPanel.Name = "DrawToolPanel";
            this.DrawToolPanel.RowCount = 3;
            this.DrawToolPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DrawToolPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.DrawToolPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.DrawToolPanel.Size = new System.Drawing.Size(834, 115);
            this.DrawToolPanel.TabIndex = 2;
            // 
            // toolPanel
            // 
            this.toolPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolPanel.Location = new System.Drawing.Point(4, 4);
            this.toolPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolPanel.Name = "toolPanel";
            this.DrawToolPanel.SetRowSpan(this.toolPanel, 2);
            this.toolPanel.Size = new System.Drawing.Size(101, 67);
            this.toolPanel.TabIndex = 3;
            // 
            // shapePanel
            // 
            this.shapePanel.BackColor = System.Drawing.Color.Transparent;
            this.shapePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shapePanel.Location = new System.Drawing.Point(113, 4);
            this.shapePanel.Margin = new System.Windows.Forms.Padding(4);
            this.shapePanel.Name = "shapePanel";
            this.DrawToolPanel.SetRowSpan(this.shapePanel, 2);
            this.shapePanel.Size = new System.Drawing.Size(192, 67);
            this.shapePanel.TabIndex = 5;
            // 
            // colorPanel
            // 
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPanel.Location = new System.Drawing.Point(313, 4);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.colorPanel.Name = "colorPanel";
            this.DrawToolPanel.SetRowSpan(this.colorPanel, 3);
            this.colorPanel.Size = new System.Drawing.Size(299, 107);
            this.colorPanel.TabIndex = 0;
            // 
            // StyleComboBox
            // 
            this.StyleComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Solid"});
            this.StyleComboBox.DisplayMember = "Solid";
            this.StyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleComboBox.FormattingEnabled = true;
            this.StyleComboBox.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "Dash Dot",
            "Dash Dot Dot"});
            this.StyleComboBox.Location = new System.Drawing.Point(668, 8);
            this.StyleComboBox.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.StyleComboBox.Name = "StyleComboBox";
            this.StyleComboBox.Size = new System.Drawing.Size(98, 21);
            this.StyleComboBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 39);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Width:";
            // 
            // ShapesLabel
            // 
            this.ShapesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ShapesLabel.AutoSize = true;
            this.ShapesLabel.Location = new System.Drawing.Point(187, 75);
            this.ShapesLabel.Name = "ShapesLabel";
            this.ShapesLabel.Size = new System.Drawing.Size(43, 40);
            this.ShapesLabel.TabIndex = 6;
            this.ShapesLabel.Text = "Shapes";
            // 
            // ToolLabel
            // 
            this.ToolLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ToolLabel.AutoSize = true;
            this.ToolLabel.Location = new System.Drawing.Point(40, 75);
            this.ToolLabel.Name = "ToolLabel";
            this.ToolLabel.Size = new System.Drawing.Size(28, 40);
            this.ToolLabel.TabIndex = 4;
            this.ToolLabel.Text = "Tool";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 8, 0, 5);
            this.label1.Size = new System.Drawing.Size(38, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Style:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // PenWidthBox
            // 
            this.PenWidthBox.Location = new System.Drawing.Point(668, 42);
            this.PenWidthBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.PenWidthBox.Name = "PenWidthBox";
            this.PenWidthBox.Size = new System.Drawing.Size(98, 20);
            this.PenWidthBox.TabIndex = 10;
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 529);
            this.Controls.Add(this.DrawBoxPanel);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyPaint";
            this.Text = "MyPaint";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ToolsPanel.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.DrawToolPanel.ResumeLayout(false);
            this.DrawToolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenWidthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private StatusStrip statusStrip;
        private ToolStripStatusLabel MouseLocation;
        private ToolStripStatusLabel DrawBoxSize;
        private ToolStripStatusLabel MouseLocationLabel;
        private ToolStripStatusLabel DrawBoxSizeLabel;
        private TableLayoutPanel ToolsPanel;
        private ToolStripMenuItem FileToolStrip;
        private ToolStripMenuItem FileNew;
        private ToolStripMenuItem FileOpen;
        private ToolStripMenuItem FileSave;
        private ToolStripMenuItem FileSaveAs;
        private ToolStripMenuItem FileExit;
        private ToolStripMenuItem EditToolStrip;
        private ToolStripMenuItem EditUndo;
        private ToolStripMenuItem EditRedo;
        private MenuStrip menuStrip;
        private DrawBoxPanel DrawBoxPanel;
        private TableLayoutPanel DrawToolPanel;
        private ToolPanel toolPanel;
        private ShapePanel shapePanel;
        private ColorPanel colorPanel;
        private ComboBox StyleComboBox;
        private Label label2;
        private Label ShapesLabel;
        private Label ToolLabel;
        private Label label1;
        private NumericUpDown PenWidthBox;
    }
}

