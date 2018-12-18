namespace Paint
{
    partial class ShapePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapePanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StarButton = new System.Windows.Forms.Button();
            this.ShapeIcons = new System.Windows.Forms.ImageList(this.components);
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.HexagonIcon = new System.Windows.Forms.Button();
            this.PentagonIcon = new System.Windows.Forms.Button();
            this.RhombusButton = new System.Windows.Forms.Button();
            this.upArrowIcon = new System.Windows.Forms.Button();
            this.downArrowIcon = new System.Windows.Forms.Button();
            this.leftArrowIcon = new System.Windows.Forms.Button();
            this.rightArrowIcon = new System.Windows.Forms.Button();
            this.sqrTriangleButton = new System.Windows.Forms.Button();
            this.TriangleButton = new System.Windows.Forms.Button();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.StarButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button15, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.button14, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.HexagonIcon, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PentagonIcon, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.RhombusButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.upArrowIcon, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.downArrowIcon, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.leftArrowIcon, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rightArrowIcon, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sqrTriangleButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.TriangleButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.EllipseButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.RectangleButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LineButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(175, 105);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // StarButton
            // 
            this.StarButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.StarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StarButton.ImageKey = "starIcon.png";
            this.StarButton.ImageList = this.ShapeIcons;
            this.StarButton.Location = new System.Drawing.Point(73, 73);
            this.StarButton.Name = "StarButton";
            this.StarButton.Size = new System.Drawing.Size(29, 29);
            this.StarButton.TabIndex = 15;
            this.StarButton.Tag = "Star";
            this.StarButton.UseVisualStyleBackColor = false;
            this.StarButton.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.StarButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.StarButton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.StarButton.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // ShapeIcons
            // 
            this.ShapeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ShapeIcons.ImageStream")));
            this.ShapeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ShapeIcons.Images.SetKeyName(0, "ellipseIcon.png");
            this.ShapeIcons.Images.SetKeyName(1, "hexagonIcon.png");
            this.ShapeIcons.Images.SetKeyName(2, "lineIcon.png");
            this.ShapeIcons.Images.SetKeyName(3, "pentagonIcon.png");
            this.ShapeIcons.Images.SetKeyName(4, "rectangleIcon.png");
            this.ShapeIcons.Images.SetKeyName(5, "rhombusIcon.png");
            this.ShapeIcons.Images.SetKeyName(6, "sqrTriangleIcon.png");
            this.ShapeIcons.Images.SetKeyName(7, "starIcon.png");
            this.ShapeIcons.Images.SetKeyName(8, "triangleIcon.png");
            this.ShapeIcons.Images.SetKeyName(9, "star2Icon.jpg");
            this.ShapeIcons.Images.SetKeyName(10, "downArrowIcon.png");
            this.ShapeIcons.Images.SetKeyName(11, "leftArrowIcon.png");
            this.ShapeIcons.Images.SetKeyName(12, "rightArrowIcon.png");
            this.ShapeIcons.Images.SetKeyName(13, "upArrowIcon.png");
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.ImageList = this.ShapeIcons;
            this.button15.Location = new System.Drawing.Point(143, 73);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(29, 29);
            this.button15.TabIndex = 14;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button15.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.button14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button14.ImageList = this.ShapeIcons;
            this.button14.Location = new System.Drawing.Point(108, 73);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(29, 29);
            this.button14.TabIndex = 13;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button14.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // HexagonIcon
            // 
            this.HexagonIcon.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.HexagonIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HexagonIcon.ImageKey = "hexagonIcon.png";
            this.HexagonIcon.ImageList = this.ShapeIcons;
            this.HexagonIcon.Location = new System.Drawing.Point(38, 73);
            this.HexagonIcon.Name = "HexagonIcon";
            this.HexagonIcon.Size = new System.Drawing.Size(29, 29);
            this.HexagonIcon.TabIndex = 11;
            this.HexagonIcon.Tag = "Hexagon";
            this.HexagonIcon.UseVisualStyleBackColor = false;
            this.HexagonIcon.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.HexagonIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.HexagonIcon.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.HexagonIcon.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // PentagonIcon
            // 
            this.PentagonIcon.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PentagonIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PentagonIcon.ImageKey = "pentagonIcon.png";
            this.PentagonIcon.ImageList = this.ShapeIcons;
            this.PentagonIcon.Location = new System.Drawing.Point(3, 73);
            this.PentagonIcon.Name = "PentagonIcon";
            this.PentagonIcon.Size = new System.Drawing.Size(29, 29);
            this.PentagonIcon.TabIndex = 10;
            this.PentagonIcon.Tag = "Pentagon";
            this.PentagonIcon.UseVisualStyleBackColor = false;
            this.PentagonIcon.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.PentagonIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.PentagonIcon.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.PentagonIcon.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // RhombusButton
            // 
            this.RhombusButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.RhombusButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RhombusButton.ImageKey = "rhombusIcon.png";
            this.RhombusButton.ImageList = this.ShapeIcons;
            this.RhombusButton.Location = new System.Drawing.Point(143, 38);
            this.RhombusButton.Name = "RhombusButton";
            this.RhombusButton.Size = new System.Drawing.Size(29, 29);
            this.RhombusButton.TabIndex = 9;
            this.RhombusButton.Tag = "Rhombus";
            this.RhombusButton.UseVisualStyleBackColor = false;
            this.RhombusButton.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.RhombusButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.RhombusButton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.RhombusButton.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // upArrowIcon
            // 
            this.upArrowIcon.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.upArrowIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upArrowIcon.ImageKey = "upArrowIcon.png";
            this.upArrowIcon.ImageList = this.ShapeIcons;
            this.upArrowIcon.Location = new System.Drawing.Point(108, 38);
            this.upArrowIcon.Name = "upArrowIcon";
            this.upArrowIcon.Size = new System.Drawing.Size(29, 29);
            this.upArrowIcon.TabIndex = 8;
            this.upArrowIcon.Tag = "UpArrow";
            this.upArrowIcon.UseVisualStyleBackColor = false;
            this.upArrowIcon.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.upArrowIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.upArrowIcon.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.upArrowIcon.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // downArrowIcon
            // 
            this.downArrowIcon.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.downArrowIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downArrowIcon.ImageKey = "downArrowIcon.png";
            this.downArrowIcon.ImageList = this.ShapeIcons;
            this.downArrowIcon.Location = new System.Drawing.Point(73, 38);
            this.downArrowIcon.Name = "downArrowIcon";
            this.downArrowIcon.Size = new System.Drawing.Size(29, 29);
            this.downArrowIcon.TabIndex = 7;
            this.downArrowIcon.Tag = "DownArrow";
            this.downArrowIcon.UseVisualStyleBackColor = false;
            this.downArrowIcon.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.downArrowIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.downArrowIcon.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // leftArrowIcon
            // 
            this.leftArrowIcon.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.leftArrowIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftArrowIcon.ImageKey = "leftArrowIcon.png";
            this.leftArrowIcon.ImageList = this.ShapeIcons;
            this.leftArrowIcon.Location = new System.Drawing.Point(38, 38);
            this.leftArrowIcon.Name = "leftArrowIcon";
            this.leftArrowIcon.Size = new System.Drawing.Size(29, 29);
            this.leftArrowIcon.TabIndex = 6;
            this.leftArrowIcon.Tag = "LeftArrow";
            this.leftArrowIcon.UseVisualStyleBackColor = false;
            this.leftArrowIcon.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.leftArrowIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.leftArrowIcon.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.leftArrowIcon.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // rightArrowIcon
            // 
            this.rightArrowIcon.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rightArrowIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightArrowIcon.ImageKey = "rightArrowIcon.png";
            this.rightArrowIcon.ImageList = this.ShapeIcons;
            this.rightArrowIcon.Location = new System.Drawing.Point(3, 38);
            this.rightArrowIcon.Name = "rightArrowIcon";
            this.rightArrowIcon.Size = new System.Drawing.Size(29, 29);
            this.rightArrowIcon.TabIndex = 5;
            this.rightArrowIcon.Tag = "RightArrow";
            this.rightArrowIcon.UseVisualStyleBackColor = false;
            this.rightArrowIcon.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.rightArrowIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.rightArrowIcon.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.rightArrowIcon.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // sqrTriangleButton
            // 
            this.sqrTriangleButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.sqrTriangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqrTriangleButton.ImageKey = "sqrTriangleIcon.png";
            this.sqrTriangleButton.ImageList = this.ShapeIcons;
            this.sqrTriangleButton.Location = new System.Drawing.Point(143, 3);
            this.sqrTriangleButton.Name = "sqrTriangleButton";
            this.sqrTriangleButton.Size = new System.Drawing.Size(29, 29);
            this.sqrTriangleButton.TabIndex = 4;
            this.sqrTriangleButton.Tag = "SqrTriangle";
            this.sqrTriangleButton.UseVisualStyleBackColor = false;
            this.sqrTriangleButton.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.sqrTriangleButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.sqrTriangleButton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.sqrTriangleButton.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // TriangleButton
            // 
            this.TriangleButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.TriangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TriangleButton.ImageKey = "triangleIcon.png";
            this.TriangleButton.ImageList = this.ShapeIcons;
            this.TriangleButton.Location = new System.Drawing.Point(108, 3);
            this.TriangleButton.Name = "TriangleButton";
            this.TriangleButton.Size = new System.Drawing.Size(29, 29);
            this.TriangleButton.TabIndex = 3;
            this.TriangleButton.Tag = "Triangle";
            this.TriangleButton.UseVisualStyleBackColor = false;
            this.TriangleButton.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.TriangleButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.TriangleButton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.TriangleButton.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // EllipseButton
            // 
            this.EllipseButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.EllipseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EllipseButton.ImageKey = "ellipseIcon.png";
            this.EllipseButton.ImageList = this.ShapeIcons;
            this.EllipseButton.Location = new System.Drawing.Point(73, 3);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(29, 29);
            this.EllipseButton.TabIndex = 2;
            this.EllipseButton.Tag = "Ellipse";
            this.EllipseButton.UseVisualStyleBackColor = false;
            this.EllipseButton.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.EllipseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.EllipseButton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.EllipseButton.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // RectangleButton
            // 
            this.RectangleButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.RectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RectangleButton.ImageKey = "rectangleIcon.png";
            this.RectangleButton.ImageList = this.ShapeIcons;
            this.RectangleButton.Location = new System.Drawing.Point(38, 3);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(29, 29);
            this.RectangleButton.TabIndex = 1;
            this.RectangleButton.Tag = "Rectangle";
            this.RectangleButton.UseVisualStyleBackColor = false;
            this.RectangleButton.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.RectangleButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.RectangleButton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.RectangleButton.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // LineButton
            // 
            this.LineButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.LineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineButton.ImageKey = "lineIcon.png";
            this.LineButton.ImageList = this.ShapeIcons;
            this.LineButton.Location = new System.Drawing.Point(3, 3);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(29, 29);
            this.LineButton.TabIndex = 0;
            this.LineButton.Tag = "Line";
            this.LineButton.UseVisualStyleBackColor = false;
            this.LineButton.Leave += new System.EventHandler(this.ShapeButton_Leave);
            this.LineButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            this.LineButton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.LineButton.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // ShapePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ShapePanel";
            this.Size = new System.Drawing.Size(175, 105);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.ImageList ShapeIcons;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button HexagonIcon;
        private System.Windows.Forms.Button PentagonIcon;
        private System.Windows.Forms.Button RhombusButton;
        private System.Windows.Forms.Button upArrowIcon;
        private System.Windows.Forms.Button downArrowIcon;
        private System.Windows.Forms.Button leftArrowIcon;
        private System.Windows.Forms.Button rightArrowIcon;
        private System.Windows.Forms.Button sqrTriangleButton;
        private System.Windows.Forms.Button TriangleButton;
        private System.Windows.Forms.Button EllipseButton;
        private System.Windows.Forms.Button RectangleButton;
        private System.Windows.Forms.Button LineButton;
        private System.Windows.Forms.Button StarButton;
    }
}
