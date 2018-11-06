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

        Bitmap DrawArea;

        bool isDrawing = false;
        bool isShifting = false;
        bool isPictureClear = true;

        Point ptMouseDown;
        Point ptCurrent;
        Graphics _g;
        int shapes;

        ShapeFormer shapeFormer;

        Stack<Image> UndoList;
        Stack<Image> RedoList;

        public MyPaint()
        {
            InitializeComponent();
            Text = "MY PAINT :\">";
            KeyPreview = true;
            DrawArea = new Bitmap(PictureBox.Size.Width, PictureBox.Size.Height);
            UndoList = new Stack<Image>();
            RedoList = new Stack<Image>();
            shapeFormer = new ShapeFormer();
        }

        //Tải lại màn hình mỗi lần vẽ hình, phần pictureBox sẽ tải lại hình cũ khi cập nhật vẽ hình mới liên tục
        private void RefreshPictureBox()
        {
            if (DrawArea != null)
            {
                PictureBox.BackgroundImage = DrawArea.Clone(new Rectangle(0, 0, PictureBox.Width, PictureBox.Height), DrawArea.PixelFormat);
            }
        }

        #region Draw Events
        private void PictureBox_MouseDown(object sender, MouseEventArgs mea)
        {
            if (mea.Button == MouseButtons.Left)
            {
                if (DrawArea != null) _g = Graphics.FromImage(DrawArea);
                DrawPen = new Pen(colorPanel1.GetCurrentColor());
                ptCurrent = ptMouseDown = mea.Location;
                isDrawing = true;
                isPictureClear = false;
                RedoList.Clear();
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs mea)
        {
            if (isDrawing)
            {
                if (shapes >= 1 && shapes <= 4)
                {
                    ptCurrent = mea.Location;
                    Refresh();
                }
                else
                {
                    Point ptNew = mea.Location;
                    Graphics grfx = PictureBox.CreateGraphics();
                    grfx.DrawLine(DrawPen, ptCurrent, ptNew);
                    grfx.Dispose();
                    _g.DrawLine(DrawPen, ptCurrent, ptNew);
                    ptCurrent = ptNew;
                }
            }
        }
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing)
            {
                switch (shapes)
                {
                    case 1:
                    case 4:
                        {
                            if (!isShifting) e.Graphics.DrawRectangle(DrawPen, shapeFormer.FormRectangle(ptMouseDown,ptCurrent));
                            if (isShifting) e.Graphics.DrawRectangle(DrawPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }

                    case 2:
                        {
                            if (!isShifting) e.Graphics.DrawEllipse(DrawPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (isShifting) e.Graphics.DrawEllipse(DrawPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }
                    case 3:
                        {
                            e.Graphics.DrawLine(DrawPen, ptMouseDown, ptCurrent);
                            break;
                        }
                }
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs mea)
        {
            if (isDrawing)
            {
                switch (shapes)
                {
                    case 1:
                        {
                            //Save rectangle in DrawArea
                            if (!isShifting) _g.DrawRectangle(DrawPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (isShifting) _g.DrawRectangle(DrawPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }

                    case 2:
                        {
                            //Save ellipse in DrawArea
                            if (!isShifting) _g.DrawEllipse(DrawPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (isShifting) _g.DrawEllipse(DrawPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }
                    case 3:
                        {
                            _g.DrawLine(DrawPen, ptMouseDown, ptCurrent);
                            UndoList.Push(PictureBox.BackgroundImage);
                            break;
                        }
                    case 4:
                        {
                            {
                                RichTextBox textBox = new RichTextBox();
                                Point location = PictureBox.PointToScreen(ptMouseDown);
                                PopupTextForm form = new PopupTextForm(textBox, location,
                                  () =>
                                  {
                                      _g.DrawString(textBox.Text, DefaultFont, Brushes.Black, ptMouseDown);
                                  }
                                  );
                                form.Show();
                                Refresh();

                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                UndoList.Push(PictureBox.BackgroundImage);
                RefreshPictureBox();
                isDrawing = false;
            }
        }
        #endregion

        #region Click Button

        private void PenButton_Click(object sender, EventArgs e)
        {
            shapes = 0;
        }
        private void RectangleButton_Click(object sender, EventArgs e)
        {
            shapes = 1;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            shapes = 2;
        }
        private void LineButton_Click(object sender, EventArgs e)
        {
            shapes = 3;
        }
        private void TextBoxButton_Click(object sender, EventArgs e)
        {
            shapes = 4;
        }
        #endregion

        #region Undo & Redo
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.Z)
                    Undo();
                if (e.KeyCode == Keys.Y)
                    Redo();
            }
            if (e.Shift) isShifting = true;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!e.Shift) isShifting = false;
        }

        public void Undo()
        {
            if (!isPictureClear)
            {
                RedoList.Push(PictureBox.BackgroundImage);
            }

            if (UndoList.Count() != 0 && UndoList.Peek() != null)
                DrawArea = new Bitmap(UndoList.Pop(), PictureBox.Size);
            else
            {
                DrawArea = new Bitmap(PictureBox.Size.Width, PictureBox.Size.Height);
                isPictureClear = true;
            }
            if (UndoList.Count() == 1) UndoList.Pop();
            RefreshPictureBox();
        }
        public void Redo()
        {
            if (RedoList.Count() != 0)
            {
                UndoList.Push(PictureBox.BackgroundImage);
            }
            else return;
            while (RedoList.Peek() == null)
            {
                RedoList.Pop();
            }
            if (RedoList.Peek() != null)
            {
                DrawArea = new Bitmap(RedoList.Pop(), PictureBox.Size);
                isPictureClear = false;
            }
            else return;
            RefreshPictureBox();
        }
        #endregion

        private void MyPaint_SizeChanged(object sender, EventArgs e)
        {
            DrawArea = new Bitmap(PictureBox.Size.Width, PictureBox.Size.Height);
            RefreshPictureBox();
        }

    }
}
