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
        Point ptMouseDown;
        Point ptCurrent;
        Size _fullSize;
        Graphics _g;
        int shapes;
        Stack<Image> UndoList;
        Stack<Image> RedoList;
        public MyPaint()
        {
            InitializeComponent();
            this.KeyPreview = true; // Form receive KeyEvent before pass to focus control
            DrawPen = new Pen(Color.Black);
            DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = DrawArea;
            Text = "MY PAINT :\">";
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //ForeColor = SystemColors.WindowText;
        }
        private void RefreshFormBackground()
        {
            //Create a copy of DrawArea
            Clone = DrawArea.Clone(new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), DrawArea.PixelFormat);
            pictureBox1.BackgroundImage = Clone;
        }
        private void Form1Load(object sender, EventArgs e)
        {
            _fullSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            // Create graphic object
            DrawArea = new Bitmap(_fullSize.Width, _fullSize.Height);
            _g = Graphics.FromImage(DrawArea);
            UndoList = new Stack<Image>();
            RedoList = new Stack<Image>();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(ptMouseDown.X, ptCurrent.X),
                Math.Min(ptMouseDown.Y, ptCurrent.Y),
                Math.Abs(ptMouseDown.X - ptCurrent.X),
                Math.Abs(ptMouseDown.Y - ptCurrent.Y));
        }
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
            if (mea.Button != MouseButtons.Left)
                return;
            _g = Graphics.FromImage(DrawArea);
            DrawPen = new Pen(colorPanel1.GetCurrentColor());
            ptCurrent = ptMouseDown = mea.Location;
            isDrawing = true;

        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs mea)
        {
            if (!isDrawing)
                return;
            switch (shapes)
            {
                case 1:
                    {
                        ptCurrent = mea.Location;
                        Refresh();
                        break;
                    }

                case 2:
                    {
                        ptCurrent = mea.Location;
                        Refresh();
                        break;
                    }
                case 3:
                    {
                        ptCurrent = mea.Location;
                        Refresh();
                        break;
                    }
                case 4:
                    {
                        ptCurrent = mea.Location;
                        Refresh();
                        break;

                    }
                default:
                    {

                        Point ptNew = new Point(mea.X, mea.Y);
                        // Scribble when mouse move
                        Graphics grfx = pictureBox1.CreateGraphics();
                        grfx.DrawLine(DrawPen, ptCurrent, ptNew);
                        grfx.Dispose();
                        // Save scribble
                        _g.DrawLine(DrawPen, ptCurrent, ptNew);
                        ptCurrent = ptNew;
                        break;
                    }
            }
        }
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            switch (shapes)
            {
                case 1:
                    {
                        if (isDrawing && !isShifting) e.Graphics.DrawRectangle(DrawPen, getRectangle());
                        if (isDrawing && isShifting) e.Graphics.DrawRectangle(DrawPen, getSquare());
                        break;
                    }

                case 2:
                    {
                        if (isDrawing && !isShifting) e.Graphics.DrawEllipse(DrawPen, getRectangle());
                        if (isDrawing && isShifting) e.Graphics.DrawEllipse(DrawPen, getSquare());
                        break;
                    }
                case 3:
                    {
                        if (isDrawing && !isShifting) e.Graphics.DrawLine(DrawPen, ptMouseDown, ptCurrent);
                        break;
                    }
                case 4:
                    {
                        if (isDrawing) e.Graphics.DrawRectangle(DrawPen, getRectangle());
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private Tuple<Point, Point> getPoints()
        {
            return new Tuple<Point, Point>
            (
                item1: ptMouseDown,
                item2: ptCurrent
            );
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
                            UndoList.Push(pictureBox1.BackgroundImage);
                            break;
                        }

                    case 2:
                        {
                            //Save ellipse in DrawArea
                            if (!isShifting) _g.DrawEllipse(DrawPen, getRectangle());
                            if (isShifting) _g.DrawEllipse(DrawPen, getSquare());
                            UndoList.Push(pictureBox1.BackgroundImage);
                            break;
                        }
                    case 3:
                        {
                            _g.DrawLine(DrawPen, getPoints().Item1, getPoints().Item2);
                            UndoList.Push(pictureBox1.BackgroundImage);
                            //_g.DrawLine(drawpen, ptMouseDown, ptCurrent);
                            break;
                        }
                    case 4:
                        {
                            //if (!isShifting) _g.DrawRectangle(drawpen, getRectangle());
                            {

                                RichTextBox textBox = new RichTextBox();
                                /*
                                {
                                    Location = new Point(Math.Min(ptMouseDown.X, ptCurrent.X),
                                                Math.Min(ptMouseDown.Y, ptCurrent.Y)),
                                    Size = new Size(Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                                                    Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y))),
                                    Font = DefaultFont,
                                };
                                pictureBox1.Controls.Add(textBox);
                                */
                                Point location = pictureBox1.PointToScreen(ptMouseDown);
                                PopupForm form = new PopupForm(textBox, location,
                                  () => {
                                      _g.DrawString(textBox.Text, DefaultFont, Brushes.Black, ptMouseDown);
                                      RefreshFormBackground();
                                  }
                                  );
                                form.Show();
                                Refresh();
                                //_g.DrawString(textBox.Text, DefaultFont, Brushes.Black, ptMouseDown);
                            }

                            UndoList.Push(pictureBox1.BackgroundImage);
                            break;
                        }
                    default:
                        {
                            UndoList.Push(pictureBox1.BackgroundImage);
                            break;
                        }
                }
                RefreshFormBackground();
                isDrawing = false;
            }
        }
        #endregion
        private void RectangleButton_Click(object sender, EventArgs e)
        {
            shapes = 1;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            shapes = 2;
        }
        private void PenButton_Click(object sender, EventArgs e)
        {
            shapes = 3;
        }
        private void TextBoxButton_Click(object sender, EventArgs e)
        {
            shapes = 4;
        }
        #region Undo & Redo
        /*
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                Undo();   // Implement the Ctrl+F short-cut keystroke
                return true;     // This keystroke was handled, don't pass to the control with the focus
            }
            if (keyData == (Keys.Control | Keys.Y))
            {
                Redo();
               // return true;
            }
                return base.ProcessCmdKey(ref msg, keyData);
        }
        private void MyPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift) isShifting = true;
        }
        private void MyPaint_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift) isShifting = false;
        }
        */
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
            {
                Undo();
            }

            else if (e.KeyCode == Keys.Y && e.Modifiers == Keys.Control)
                Redo();
            if (e.Shift) isShifting = true;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            e.SuppressKeyPress = true;
            if (!e.Shift) isShifting = false;
        }

        public void Undo()
        {
            if (pictureBox1.BackgroundImage != null)
                RedoList.Push(pictureBox1.BackgroundImage);
            if (UndoList.Count() >= 1)
                pictureBox1.BackgroundImage = UndoList.Pop();
            else return;
            if (pictureBox1.BackgroundImage == null) return;
            else
            {
                DrawArea = new Bitmap(pictureBox1.BackgroundImage, pictureBox1.Size);
                RefreshFormBackground();
            }
        }
        public void Redo()
        {
            if (RedoList.Count() == 0) return;
            UndoList.Push(pictureBox1.BackgroundImage);
            while (RedoList.Peek() == null)
            {
                RedoList.Pop();
            }
            if (RedoList.Peek() != null)
                DrawArea = new Bitmap(RedoList.Pop(), pictureBox1.Size);
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

        public PopupForm(Control control, int x, int y, Action onAccept)
          : this(control, new Point(x, y), onAccept)
        {
        }

        public PopupForm(Control control, Point point, Action onAccept)
        {
            if (control == null) throw new ArgumentNullException("control");

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
            _point = point;
            _control = control;
            _onAccept = onAccept;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Controls.Add(_control);
            _control.Location = new Point(0, 0);
            this.Size = _control.Size;
            this.Location = _point;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                _onAccept();
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Close();
        }
    }
}
