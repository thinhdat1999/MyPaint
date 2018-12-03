namespace Paint
{
    partial class ColorPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftColorLabel = new System.Windows.Forms.Label();
            this.rightColorLabel = new System.Windows.Forms.Label();
            this.rightColorButton = new System.Windows.Forms.Button();
            this.leftColorButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorPanelLabel = new System.Windows.Forms.Label();
            this.colorButton12 = new Paint.ColorButton();
            this.colorButton11 = new Paint.ColorButton();
            this.colorButton10 = new Paint.ColorButton();
            this.colorButton9 = new Paint.ColorButton();
            this.colorButton8 = new Paint.ColorButton();
            this.colorButton7 = new Paint.ColorButton();
            this.colorButton6 = new Paint.ColorButton();
            this.colorButton5 = new Paint.ColorButton();
            this.colorButton4 = new Paint.ColorButton();
            this.colorButton3 = new Paint.ColorButton();
            this.colorButton2 = new Paint.ColorButton();
            this.colorButton1 = new Paint.ColorButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftColorLabel
            // 
            this.leftColorLabel.AutoSize = true;
            this.leftColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftColorLabel.Location = new System.Drawing.Point(3, 60);
            this.leftColorLabel.Name = "leftColorLabel";
            this.leftColorLabel.Size = new System.Drawing.Size(54, 20);
            this.leftColorLabel.TabIndex = 19;
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
            this.rightColorButton.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.rightColorButton.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
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
            this.leftColorButton.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.leftColorButton.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
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
            this.tableLayoutPanel1.Controls.Add(this.colorButton12, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorButton11, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorButton10, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorButton9, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorButton8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorButton7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorButton6, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorButton5, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorButton4, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorButton3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorButton2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.leftColorLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.colorPanelLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rightColorLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rightColorButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.leftColorButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorButton1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 80);
            this.tableLayoutPanel1.TabIndex = 2;
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
            // colorButton12
            // 
            this.colorButton12.AutoSize = true;
            this.colorButton12.BackColor = System.Drawing.Color.Brown;
            this.colorButton12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton12.Location = new System.Drawing.Point(273, 33);
            this.colorButton12.Name = "colorButton12";
            this.colorButton12.Size = new System.Drawing.Size(24, 24);
            this.colorButton12.TabIndex = 42;
            this.colorButton12.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton12.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton12.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton12.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton11
            // 
            this.colorButton11.AutoSize = true;
            this.colorButton11.BackColor = System.Drawing.Color.Purple;
            this.colorButton11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton11.Location = new System.Drawing.Point(243, 33);
            this.colorButton11.Name = "colorButton11";
            this.colorButton11.Size = new System.Drawing.Size(24, 24);
            this.colorButton11.TabIndex = 41;
            this.colorButton11.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton11.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton11.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton11.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton10
            // 
            this.colorButton10.AutoSize = true;
            this.colorButton10.BackColor = System.Drawing.Color.Violet;
            this.colorButton10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton10.Location = new System.Drawing.Point(213, 33);
            this.colorButton10.Name = "colorButton10";
            this.colorButton10.Size = new System.Drawing.Size(24, 24);
            this.colorButton10.TabIndex = 40;
            this.colorButton10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton10.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton10.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton10.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton9
            // 
            this.colorButton9.AutoSize = true;
            this.colorButton9.BackColor = System.Drawing.Color.Cyan;
            this.colorButton9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton9.Location = new System.Drawing.Point(183, 33);
            this.colorButton9.Name = "colorButton9";
            this.colorButton9.Size = new System.Drawing.Size(24, 24);
            this.colorButton9.TabIndex = 39;
            this.colorButton9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton9.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton9.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton9.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton8
            // 
            this.colorButton8.AutoSize = true;
            this.colorButton8.BackColor = System.Drawing.Color.Blue;
            this.colorButton8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton8.Location = new System.Drawing.Point(153, 33);
            this.colorButton8.Name = "colorButton8";
            this.colorButton8.Size = new System.Drawing.Size(24, 24);
            this.colorButton8.TabIndex = 38;
            this.colorButton8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton8.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton8.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton8.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton7
            // 
            this.colorButton7.AutoSize = true;
            this.colorButton7.BackColor = System.Drawing.Color.White;
            this.colorButton7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton7.Location = new System.Drawing.Point(123, 33);
            this.colorButton7.Name = "colorButton7";
            this.colorButton7.Size = new System.Drawing.Size(24, 24);
            this.colorButton7.TabIndex = 37;
            this.colorButton7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton7.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton7.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton7.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton6
            // 
            this.colorButton6.AutoSize = true;
            this.colorButton6.BackColor = System.Drawing.Color.Green;
            this.colorButton6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton6.Location = new System.Drawing.Point(273, 3);
            this.colorButton6.Name = "colorButton6";
            this.colorButton6.Size = new System.Drawing.Size(24, 24);
            this.colorButton6.TabIndex = 36;
            this.colorButton6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton6.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton6.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton6.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton5
            // 
            this.colorButton5.AutoSize = true;
            this.colorButton5.BackColor = System.Drawing.Color.Orange;
            this.colorButton5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton5.Location = new System.Drawing.Point(243, 3);
            this.colorButton5.Name = "colorButton5";
            this.colorButton5.Size = new System.Drawing.Size(24, 24);
            this.colorButton5.TabIndex = 35;
            this.colorButton5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton5.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton5.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton5.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton4
            // 
            this.colorButton4.AutoSize = true;
            this.colorButton4.BackColor = System.Drawing.Color.Yellow;
            this.colorButton4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton4.Location = new System.Drawing.Point(213, 3);
            this.colorButton4.Name = "colorButton4";
            this.colorButton4.Size = new System.Drawing.Size(24, 24);
            this.colorButton4.TabIndex = 34;
            this.colorButton4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton4.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton4.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton3
            // 
            this.colorButton3.AutoSize = true;
            this.colorButton3.BackColor = System.Drawing.Color.Red;
            this.colorButton3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton3.Location = new System.Drawing.Point(183, 3);
            this.colorButton3.Name = "colorButton3";
            this.colorButton3.Size = new System.Drawing.Size(24, 24);
            this.colorButton3.TabIndex = 33;
            this.colorButton3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton3.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton3.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton2
            // 
            this.colorButton2.AutoSize = true;
            this.colorButton2.BackColor = System.Drawing.Color.Gray;
            this.colorButton2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton2.Location = new System.Drawing.Point(153, 3);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(24, 24);
            this.colorButton2.TabIndex = 32;
            this.colorButton2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton2.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton2.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorButton1
            // 
            this.colorButton1.AutoSize = true;
            this.colorButton1.BackColor = System.Drawing.Color.Black;
            this.colorButton1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton1.Location = new System.Drawing.Point(123, 3);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(24, 24);
            this.colorButton1.TabIndex = 31;
            this.colorButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseClick);
            this.colorButton1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDoubleClick);
            this.colorButton1.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton1.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // ColorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorPanel";
            this.Size = new System.Drawing.Size(300, 80);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton colorButton12;
        private ColorButton colorButton11;
        private ColorButton colorButton10;
        private ColorButton colorButton9;
        private ColorButton colorButton8;
        private ColorButton colorButton7;
        private ColorButton colorButton6;
        private ColorButton colorButton5;
        private ColorButton colorButton4;
        private ColorButton colorButton3;
        private ColorButton colorButton2;
        private System.Windows.Forms.Label leftColorLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label rightColorLabel;
        private System.Windows.Forms.Button rightColorButton;
        private System.Windows.Forms.Button leftColorButton;
        private ColorButton colorButton1;
        private System.Windows.Forms.Label colorPanelLabel;
    }
}
