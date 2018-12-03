namespace Paint
{
    partial class ToolPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TextButton = new System.Windows.Forms.Button();
            this.ToolIcons = new System.Windows.Forms.ImageList(this.components);
            this.PickerButton = new System.Windows.Forms.Button();
            this.BrushButton = new System.Windows.Forms.Button();
            this.EraserButton = new System.Windows.Forms.Button();
            this.BucketButton = new System.Windows.Forms.Button();
            this.PenButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.TextButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.PickerButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BrushButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.EraserButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BucketButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PenButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(105, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TextButton
            // 
            this.TextButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.TextButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextButton.ImageKey = "textIcon.png";
            this.TextButton.ImageList = this.ToolIcons;
            this.TextButton.Location = new System.Drawing.Point(73, 38);
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new System.Drawing.Size(29, 29);
            this.TextButton.TabIndex = 5;
            this.TextButton.Tag = "Text";
            this.TextButton.UseVisualStyleBackColor = false;
            this.TextButton.Leave += new System.EventHandler(this.ToolButton_Leave);
            this.TextButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolButton_MouseDown);
            // 
            // ToolIcons
            // 
            this.ToolIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ToolIcons.ImageStream")));
            this.ToolIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ToolIcons.Images.SetKeyName(0, "brushIcon.png");
            this.ToolIcons.Images.SetKeyName(1, "bucketIcon.png");
            this.ToolIcons.Images.SetKeyName(2, "eraserIcon.png");
            this.ToolIcons.Images.SetKeyName(3, "pencilIcon.png");
            this.ToolIcons.Images.SetKeyName(4, "pickerIcon.png");
            this.ToolIcons.Images.SetKeyName(5, "textIcon.png");
            // 
            // PickerButton
            // 
            this.PickerButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PickerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PickerButton.ImageKey = "pickerIcon.png";
            this.PickerButton.ImageList = this.ToolIcons;
            this.PickerButton.Location = new System.Drawing.Point(38, 38);
            this.PickerButton.Name = "PickerButton";
            this.PickerButton.Size = new System.Drawing.Size(29, 29);
            this.PickerButton.TabIndex = 4;
            this.PickerButton.Tag = "Picker";
            this.PickerButton.UseVisualStyleBackColor = false;
            this.PickerButton.Leave += new System.EventHandler(this.ToolButton_Leave);
            this.PickerButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolButton_MouseDown);
            // 
            // BrushButton
            // 
            this.BrushButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BrushButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrushButton.ImageKey = "brushIcon.png";
            this.BrushButton.ImageList = this.ToolIcons;
            this.BrushButton.Location = new System.Drawing.Point(3, 38);
            this.BrushButton.Name = "BrushButton";
            this.BrushButton.Size = new System.Drawing.Size(29, 29);
            this.BrushButton.TabIndex = 3;
            this.BrushButton.Tag = "Brush";
            this.BrushButton.UseVisualStyleBackColor = false;
            this.BrushButton.Leave += new System.EventHandler(this.ToolButton_Leave);
            this.BrushButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolButton_MouseDown);
            // 
            // EraserButton
            // 
            this.EraserButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.EraserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EraserButton.ImageKey = "eraserIcon.png";
            this.EraserButton.ImageList = this.ToolIcons;
            this.EraserButton.Location = new System.Drawing.Point(73, 3);
            this.EraserButton.Name = "EraserButton";
            this.EraserButton.Size = new System.Drawing.Size(29, 29);
            this.EraserButton.TabIndex = 2;
            this.EraserButton.Tag = "Eraser";
            this.EraserButton.UseVisualStyleBackColor = false;
            this.EraserButton.Leave += new System.EventHandler(this.ToolButton_Leave);
            this.EraserButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolButton_MouseDown);
            // 
            // BucketButton
            // 
            this.BucketButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BucketButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BucketButton.ImageKey = "bucketIcon.png";
            this.BucketButton.ImageList = this.ToolIcons;
            this.BucketButton.Location = new System.Drawing.Point(38, 3);
            this.BucketButton.Name = "BucketButton";
            this.BucketButton.Size = new System.Drawing.Size(29, 29);
            this.BucketButton.TabIndex = 1;
            this.BucketButton.Tag = "Bucket";
            this.BucketButton.UseVisualStyleBackColor = false;
            this.BucketButton.Leave += new System.EventHandler(this.ToolButton_Leave);
            this.BucketButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolButton_MouseDown);
            // 
            // PenButton
            // 
            this.PenButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PenButton.ImageKey = "pencilIcon.png";
            this.PenButton.ImageList = this.ToolIcons;
            this.PenButton.Location = new System.Drawing.Point(3, 3);
            this.PenButton.Name = "PenButton";
            this.PenButton.Size = new System.Drawing.Size(29, 29);
            this.PenButton.TabIndex = 0;
            this.PenButton.Tag = "Pen";
            this.PenButton.UseVisualStyleBackColor = false;
            this.PenButton.Leave += new System.EventHandler(this.ToolButton_Leave);
            this.PenButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolButton_MouseDown);
            // 
            // ToolPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ToolPanel";
            this.Size = new System.Drawing.Size(105, 70);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button PickerButton;
        private System.Windows.Forms.Button BrushButton;
        private System.Windows.Forms.Button EraserButton;
        private System.Windows.Forms.Button BucketButton;
        private System.Windows.Forms.Button PenButton;
        private System.Windows.Forms.ImageList ToolIcons;
        private System.Windows.Forms.Button TextButton;
    }
}
