using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class MyPaint : Form
    {
        private DrawBox drawBox;

        //Khởi tạo các giá trị khi load form
        public MyPaint()
        {
            InitializeComponent();
            Text = "MY PAINT :\">";
            KeyPreview = true;
            ActiveControl = PenButton;

            drawBox = new DrawBox(DrawBoxLayoutPanel.Size);
            drawBox.MouseDown += drawBox_MouseDown;
            DrawBoxLayoutPanel.Controls.Add(drawBox);
        }

        private void drawBox_MouseDown(object sender, MouseEventArgs e)
        {
            drawBox.BorderColor = PaintColorPanel.GetCurrentColor();
        }

        #region Click Button
        private void PenButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 0;
        }
        private void RectangleButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 1;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 2;
        }
        private void LineButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 3;
        }
        private void TextBoxButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 4;
        }
        #endregion

        //Tạo sự kiện Undo, Redo khi nhấn các tổ hợp phím Ctrl + Z, Ctrl + Y, Shift
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    drawBox.Undo();
                }

                else if (e.KeyCode == Keys.Y)
                {
                    drawBox.Redo();
                }
            }

            else if (e.Shift) drawBox.isShiftPress = true;
        }

        //Khi thả nút shift
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!e.Shift) drawBox.isShiftPress = false;
        }
    }
}