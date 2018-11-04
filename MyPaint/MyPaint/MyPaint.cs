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
        Bitmap Clone;

        bool isDrawing = false;
        bool isShifting = false;
        bool isPictureClear = true;

        Point ptMouseDown;
        Point ptCurrent;
        Graphics _g;
        int shapes;

        Stack<Image> UndoList;
        Stack<Image> RedoList;

        public MyPaint()
        {
            InitializeComponent();
            Text = "MY PAINT :\">";
            KeyPreview = true;
            DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            UndoList = new Stack<Image>();
            RedoList = new Stack<Image>();
        }

        //Tải lại màn hình mỗi lần vẽ hình, phần pictureBox sẽ tải lại hình cũ khi cập nhật vẽ hình mới liên tục
        private void RefreshFormBackground()
        {
            if (DrawArea != null)
            {
                Clone = DrawArea.Clone(new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), DrawArea.PixelFormat);
                pictureBox1.BackgroundImage = Clone;
            }
        }

        //Vẽ hình chữ nhật từ các tọa độ chuột
        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(ptMouseDown.X, ptCurrent.X),
                Math.Min(ptMouseDown.Y, ptCurrent.Y),
                Math.Abs(ptMouseDown.X - ptCurrent.X),
                Math.Abs(ptMouseDown.Y - ptCurrent.Y));
        }

        //Vẽ hình vuông từ tọa độ chuột
        private Rectangle getSquare()
        {
            if ((ptMouseDown.X - ptCurrent.X) > Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)))
                return new Rectangle(
                    ptMouseDown.X - Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                        Math.Min(ptMouseDown.Y, ptCurrent.Y),
                        Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                        Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));

            else if ((ptMouseDown.Y - ptCurrent.Y) > Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)))
                return new Rectangle(
                    Math.Min(ptMouseDown.X, ptCurrent.X),
                    ptMouseDown.Y - Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                        Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                        Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));

            return new Rectangle(
                Math.Min(ptMouseDown.X, ptCurrent.X),
                Math.Min(ptMouseDown.Y, ptCurrent.Y),
                Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));
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
                    Point ptNew = new Point(mea.X, mea.Y);
                    Graphics grfx = pictureBox1.CreateGraphics();
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
                            if (!isShifting) e.Graphics.DrawRectangle(DrawPen, getRectangle());
                            if (isShifting) e.Graphics.DrawRectangle(DrawPen, getSquare());
                            break;
                        }

                    case 2:
                        {
                            if (!isShifting) e.Graphics.DrawEllipse(DrawPen, getRectangle());
                            if (isShifting) e.Graphics.DrawEllipse(DrawPen, getSquare());
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
                            if (!isShifting) _g.DrawRectangle(DrawPen, getRectangle());
                            if (isShifting) _g.DrawRectangle(DrawPen, getSquare());
                            break;
                        }

                    case 2:
                        {
                            //Save ellipse in DrawArea
                            if (!isShifting) _g.DrawEllipse(DrawPen, getRectangle());
                            if (isShifting) _g.DrawEllipse(DrawPen, getSquare());
                            break;
                        }
                    case 3:
                        {
                            _g.DrawLine(DrawPen, ptMouseDown, ptCurrent);
                            UndoList.Push(pictureBox1.BackgroundImage);
                            break;
                        }
                    case 4:
                        {
                            {

                                RichTextBox textBox = new RichTextBox();
                                Point location = pictureBox1.PointToScreen(ptMouseDown);
                                PopupForm form = new PopupForm(textBox, location,
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
                UndoList.Push(pictureBox1.BackgroundImage);
                RefreshFormBackground();
                isDrawing = false;
            }
        }
        #endregion

        #region Click Button
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
                RedoList.Push(pictureBox1.BackgroundImage);
            }


            if (UndoList.Count() != 0 && UndoList.Peek() != null)
                DrawArea = new Bitmap(UndoList.Pop(), pictureBox1.Size);
            else
            {
                DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
                isPictureClear = true;
            }
            if (UndoList.Count() == 1) UndoList.Pop();
            RefreshFormBackground();
        }
        public void Redo()
        {
            if (RedoList.Count() != 0)
            {
                UndoList.Push(pictureBox1.BackgroundImage);
            }
            else return;
            while (RedoList.Peek() == null)
            {
                RedoList.Pop();
            }
            if (RedoList.Peek() != null)
            {
                DrawArea = new Bitmap(RedoList.Pop(), pictureBox1.Size);
                isPictureClear = false;

            }
            else return;
            RefreshFormBackground();
        }
        #endregion
    }

    public class PopupForm : Form
    {
        private Action _onAccept;
        private Control _control;
        private Point _point;

        public PopupForm(Control control, Point point, Action onAccept)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
            _point = point;
            _control = control;
            _onAccept = onAccept;

        }

        protected override void OnLoad(EventArgs e)
        {
            this.Controls.Add(_control);
            _control.Location = new Point(0, 0);
            this.Size = new Size(150, 25);
            this.Location = _point;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {       if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            _onAccept();
            this.Close();
        }
    }
}
