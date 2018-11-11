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
            this.PenButton = new System.Windows.Forms.Button();
            this.PaintColorPanel = new Paint.ColorPanel();
            this.TextBoxButton = new System.Windows.Forms.Button();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.DrawBoxLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ToolLayoutPanel.SuspendLayout();
            this.DrawBoxLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolLayoutPanel
            // 
            this.ToolLayoutPanel.ColumnCount = 6;
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.41623F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.04318F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.73402F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.80656F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.ToolLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.ToolLayoutPanel.Controls.Add(this.PenButton, 0, 0);
            this.ToolLayoutPanel.Controls.Add(this.PaintColorPanel, 5, 0);
            this.ToolLayoutPanel.Controls.Add(this.TextBoxButton, 4, 0);
            this.ToolLayoutPanel.Controls.Add(this.EllipseButton, 3, 0);
            this.ToolLayoutPanel.Controls.Add(this.RectangleButton, 2, 0);
            this.ToolLayoutPanel.Controls.Add(this.LineButton, 1, 0);
            this.ToolLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolLayoutPanel.Location = new System.Drawing.Point(2, 2);
            this.ToolLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ToolLayoutPanel.Name = "ToolLayoutPanel";
            this.ToolLayoutPanel.RowCount = 1;
            this.ToolLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.ToolLayoutPanel.Size = new System.Drawing.Size(1001, 94);
            this.ToolLayoutPanel.TabIndex = 2;
            // 
            // PenButton
            // 
            this.PenButton.Image = global::MyPaint.Properties.Resources.pencil;
            this.PenButton.Location = new System.Drawing.Point(2, 2);
            this.PenButton.Margin = new System.Windows.Forms.Padding(2);
            this.PenButton.Name = "PenButton";
            this.PenButton.Size = new System.Drawing.Size(48, 48);
            this.PenButton.TabIndex = 5;
            this.PenButton.TabStop = false;
            this.PenButton.UseVisualStyleBackColor = true;
            this.PenButton.Click += new System.EventHandler(this.PenButton_Click);
            // 
            // PaintColorPanel
            // 
            this.PaintColorPanel.BackColor = System.Drawing.Color.White;
            this.PaintColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaintColorPanel.Location = new System.Drawing.Point(675, 2);
            this.PaintColorPanel.Margin = new System.Windows.Forms.Padding(2);
            this.PaintColorPanel.Name = "PaintColorPanel";
            this.PaintColorPanel.Size = new System.Drawing.Size(221, 74);
            this.PaintColorPanel.TabIndex = 3;
            // 
            // TextBoxButton
            // 
            this.TextBoxButton.Image = global::MyPaint.Properties.Resources.text3;
            this.TextBoxButton.Location = new System.Drawing.Point(534, 2);
            this.TextBoxButton.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxButton.Name = "TextBoxButton";
            this.TextBoxButton.Size = new System.Drawing.Size(48, 48);
            this.TextBoxButton.TabIndex = 4;
            this.TextBoxButton.UseVisualStyleBackColor = true;
            this.TextBoxButton.Click += new System.EventHandler(this.TextBoxButton_Click);
            // 
            // EllipseButton
            // 
            this.EllipseButton.Image = global::MyPaint.Properties.Resources.ellipse;
            this.EllipseButton.Location = new System.Drawing.Point(386, 2);
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
            this.RectangleButton.Image = global::MyPaint.Properties.Resources.rectangle;
            this.RectangleButton.Location = new System.Drawing.Point(249, 2);
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
            this.LineButton.Image = global::MyPaint.Properties.Resources.line1;
            this.LineButton.Location = new System.Drawing.Point(116, 2);
            this.LineButton.Margin = new System.Windows.Forms.Padding(2);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(48, 48);
            this.LineButton.TabIndex = 0;
            this.LineButton.TabStop = false;
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // DrawBoxLayoutPanel
            // 
            this.DrawBoxLayoutPanel.ColumnCount = 1;
            this.DrawBoxLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DrawBoxLayoutPanel.Controls.Add(this.ToolLayoutPanel, 0, 0);
            this.DrawBoxLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawBoxLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawBoxLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DrawBoxLayoutPanel.Name = "DrawBoxLayoutPanel";
            this.DrawBoxLayoutPanel.RowCount = 2;
            this.DrawBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.44444F));
            this.DrawBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.55556F));
            this.DrawBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.DrawBoxLayoutPanel.Size = new System.Drawing.Size(1005, 483);
            this.DrawBoxLayoutPanel.TabIndex = 0;
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 483);
            this.Controls.Add(this.DrawBoxLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyPaint";
            this.Text = "Form1";
            this.ToolLayoutPanel.ResumeLayout(false);
            this.DrawBoxLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TableLayoutPanel ToolLayoutPanel;
        private System.Windows.Forms.Button RectangleButton;
        private System.Windows.Forms.TableLayoutPanel DrawBoxLayoutPanel;
        private Button LineButton;
        private System.Drawing.Pen DrawPen;
        private Button EllipseButton;
        private ColorPanel PaintColorPanel;
        private Button TextBoxButton;
        private Button PenButton;
    }
}

