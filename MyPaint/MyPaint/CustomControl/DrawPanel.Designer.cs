namespace Paint
{
    partial class DrawPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textButton = new System.Windows.Forms.Button();
            this.DrawIconList = new System.Windows.Forms.ImageList(this.components);
            this.bucketButton = new System.Windows.Forms.Button();
            this.ziczagButton = new System.Windows.Forms.Button();
            this.brushButton = new System.Windows.Forms.Button();
            this.eraseButton = new System.Windows.Forms.Button();
            this.triangleButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.penButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.bucketButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ziczagButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.brushButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.eraseButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.triangleButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.circleButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.rectangleButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lineButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.penButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 80);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textButton
            // 
            this.textButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textButton.ImageIndex = 7;
            this.textButton.ImageList = this.DrawIconList;
            this.textButton.Location = new System.Drawing.Point(163, 43);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(34, 34);
            this.textButton.TabIndex = 9;
            this.textButton.UseVisualStyleBackColor = false;
            // 
            // DrawIconList
            // 
            this.DrawIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DrawIconList.ImageStream")));
            this.DrawIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.DrawIconList.Images.SetKeyName(0, "brushIcon.png");
            this.DrawIconList.Images.SetKeyName(1, "bucketIcon.png");
            this.DrawIconList.Images.SetKeyName(2, "ellipseIcon.png");
            this.DrawIconList.Images.SetKeyName(3, "eraserIcon.png");
            this.DrawIconList.Images.SetKeyName(4, "lineIcon.png");
            this.DrawIconList.Images.SetKeyName(5, "penIcon.png");
            this.DrawIconList.Images.SetKeyName(6, "rectangleIcon.png");
            this.DrawIconList.Images.SetKeyName(7, "textIcon.png");
            this.DrawIconList.Images.SetKeyName(8, "triangleIcon.png");
            this.DrawIconList.Images.SetKeyName(9, "ziczacIcon.png");
            // 
            // bucketButton
            // 
            this.bucketButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.bucketButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bucketButton.ImageIndex = 1;
            this.bucketButton.ImageList = this.DrawIconList;
            this.bucketButton.Location = new System.Drawing.Point(123, 43);
            this.bucketButton.Name = "bucketButton";
            this.bucketButton.Size = new System.Drawing.Size(34, 34);
            this.bucketButton.TabIndex = 8;
            this.bucketButton.UseVisualStyleBackColor = false;
            // 
            // ziczagButton
            // 
            this.ziczagButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ziczagButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ziczagButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ziczagButton.ImageIndex = 9;
            this.ziczagButton.ImageList = this.DrawIconList;
            this.ziczagButton.Location = new System.Drawing.Point(83, 43);
            this.ziczagButton.Name = "ziczagButton";
            this.ziczagButton.Size = new System.Drawing.Size(34, 34);
            this.ziczagButton.TabIndex = 7;
            this.ziczagButton.UseVisualStyleBackColor = false;
            // 
            // brushButton
            // 
            this.brushButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.brushButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brushButton.ImageIndex = 0;
            this.brushButton.ImageList = this.DrawIconList;
            this.brushButton.Location = new System.Drawing.Point(43, 43);
            this.brushButton.Name = "brushButton";
            this.brushButton.Size = new System.Drawing.Size(34, 34);
            this.brushButton.TabIndex = 6;
            this.brushButton.UseVisualStyleBackColor = false;
            // 
            // eraseButton
            // 
            this.eraseButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.eraseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eraseButton.ImageIndex = 3;
            this.eraseButton.ImageList = this.DrawIconList;
            this.eraseButton.Location = new System.Drawing.Point(3, 43);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(34, 34);
            this.eraseButton.TabIndex = 5;
            this.eraseButton.UseVisualStyleBackColor = false;
            // 
            // triangleButton
            // 
            this.triangleButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.triangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triangleButton.ImageIndex = 8;
            this.triangleButton.ImageList = this.DrawIconList;
            this.triangleButton.Location = new System.Drawing.Point(163, 3);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(34, 34);
            this.triangleButton.TabIndex = 4;
            this.triangleButton.UseVisualStyleBackColor = false;
            // 
            // circleButton
            // 
            this.circleButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.circleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleButton.ImageIndex = 2;
            this.circleButton.ImageList = this.DrawIconList;
            this.circleButton.Location = new System.Drawing.Point(123, 3);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(34, 34);
            this.circleButton.TabIndex = 3;
            this.circleButton.UseVisualStyleBackColor = false;
            // 
            // rectangleButton
            // 
            this.rectangleButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleButton.ImageIndex = 6;
            this.rectangleButton.ImageList = this.DrawIconList;
            this.rectangleButton.Location = new System.Drawing.Point(83, 3);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(34, 34);
            this.rectangleButton.TabIndex = 2;
            this.rectangleButton.UseVisualStyleBackColor = false;
            // 
            // lineButton
            // 
            this.lineButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineButton.ImageIndex = 4;
            this.lineButton.ImageList = this.DrawIconList;
            this.lineButton.Location = new System.Drawing.Point(43, 3);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(34, 34);
            this.lineButton.TabIndex = 1;
            this.lineButton.UseVisualStyleBackColor = false;
            // 
            // penButton
            // 
            this.penButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.penButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.penButton.ImageIndex = 5;
            this.penButton.ImageList = this.DrawIconList;
            this.penButton.Location = new System.Drawing.Point(3, 3);
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(34, 34);
            this.penButton.TabIndex = 0;
            this.penButton.UseVisualStyleBackColor = false;
            // 
            // DrawPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DrawPanel";
            this.Size = new System.Drawing.Size(200, 80);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button textButton;
        private System.Windows.Forms.Button bucketButton;
        private System.Windows.Forms.Button ziczagButton;
        private System.Windows.Forms.Button brushButton;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button penButton;
        private System.Windows.Forms.ImageList DrawIconList;
    }
}
