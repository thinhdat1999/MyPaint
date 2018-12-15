using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class DrawBox : PictureBox
    {
        Stack<Bitmap> UndoList;
        Stack<Bitmap> RedoList;

        Graphics _g;
        Pen _pen;

        PopupTextBox textBox;

        Point ptMouseDown;
        Point ptMouseMove;

        Rectangle oldRect;
        Rectangle areaRect;

        int _dragHandle = 0;
        string _drawType;
        bool _isOpenYet;

        enum DrawStatus
        {
            Idle,
            LineDrawing,
            ToolDrawing,
            ShapeDrawing,
            Resize
        };
        DrawStatus _drawStatus;
        public bool IsOpen { set => _isOpenYet = value; }
        public Image RedoListPush { set => RedoList.Push(new Bitmap(value)); }
        public string DrawType { set => _drawType = value; }

        #region Constructor
        //Constructor tạo DrawBox
        public DrawBox(Size _size)
        {
            Size = _size;
            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();
            Image = (Image)(new Bitmap(Width, Height));

            Region region = new Region(new Rectangle(0, 0, Width, Height));
            _g = Graphics.FromImage(Image);
            _g.FillRegion(new SolidBrush(Color.White), region);
        }
        #endregion

        #region Mouse Down
        //Khởi tạo các thuộc tính khi nhấn chuột trái vào vùng DrawBox
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            ptMouseDown = e.Location;

            if (_drawStatus == DrawStatus.Idle)
            {
                Color _drawColor = Color.Empty;

                if (ShapePanel.ShapeLabel != null)
                {
                    _drawType = ShapePanel.ShapeLabel;
                }
                else _drawType = ToolPanel.ToolLabel;

                if (e.Button == MouseButtons.Left)
                {
                    _drawColor = ColorPanel.LeftColor;
                }

                else if (e.Button == MouseButtons.Right)
                {
                    _drawColor = ColorPanel.RightColor;
                }

                switch (_drawType)
                {
                    case "Pen":
                        UndoList.Push(new Bitmap(Image));
                        RedoList.Clear();
                        _pen = new Pen(_drawColor, 1);
                        _drawStatus = DrawStatus.ToolDrawing;
                        break;

                    case "Bucket":
                        UndoList.Push(new Bitmap(Image));
                        RedoList.Clear();
                        FloodFill(ptMouseDown, _drawColor);
                        RedoList.Push(new Bitmap(Image));
                        break;

                    case "Eraser":
                        UndoList.Push(new Bitmap(Image));
                        RedoList.Clear();
                        _pen = new Pen(ColorPanel.RightColor, 10);
                        _drawStatus = DrawStatus.ToolDrawing;
                        break;

                    case "Brush":
                        UndoList.Push(new Bitmap(Image));
                        RedoList.Clear();
                        _pen = new Pen(_drawColor, 5);
                        _drawStatus = DrawStatus.ToolDrawing;
                        break;

                    case "Line":
                        UndoList.Push(new Bitmap(Image));
                        RedoList.Clear();
                        _pen = new Pen(_drawColor);
                        _drawStatus = DrawStatus.LineDrawing;
                        break;

                    default:
                        _pen = new Pen(_drawColor);
                        _drawStatus = DrawStatus.ShapeDrawing;
                        break;
                }
            }

            else if (_drawStatus == DrawStatus.Resize)
            {
                if ((_dragHandle = ResizePaint.GetDragHandle(e.Location, areaRect)) != 9)
                {
                    oldRect = areaRect;
                }

                else
                {
                    _drawStatus = DrawStatus.Idle;
                    _g = Graphics.FromImage(Image);
                    ShapePaint.DrawShape(_g, _pen, areaRect, _drawType);
                    RedoList.Push(new Bitmap(Image));
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region Mouse Move
        //Khi di chuyển chuột (và đè chuột trái - tức đang vẽ) trên vùng DrawBox
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_drawStatus == DrawStatus.LineDrawing)
            {
                ptMouseMove = e.Location;
                this.Invalidate();
            }

            else if (_drawStatus == DrawStatus.ToolDrawing)
            {
                DrawDrag(ptMouseDown, e.Location, _drawType);
                ptMouseDown = e.Location;
            }

            else if (_drawStatus == DrawStatus.ShapeDrawing)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    areaRect = ShapePaint.CreateSquare(ptMouseDown, e.Location);
                }
                else areaRect = ShapePaint.CreateRectangle(ptMouseDown, e.Location);
                this.Invalidate();
            }

            else if (_drawStatus == DrawStatus.Resize)
            {
                if (oldRect != Rectangle.Empty)
                {
                    ResizePaint.UpdateAreaRect(ref areaRect, oldRect, ptMouseDown, e.Location, _dragHandle);
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region OnPaint
        //Cập nhật lại DrawBox liên tục khi đang vẽ để tạo độ mượt
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_drawStatus == DrawStatus.LineDrawing)
            {
                e.Graphics.DrawLine(_pen, ptMouseDown, ptMouseMove);
            }

            else if (_drawStatus == DrawStatus.ShapeDrawing)
            {
                ShapePaint.DrawShape(e.Graphics, _pen, areaRect, _drawType);
            }

            else if (_drawStatus == DrawStatus.Resize)
            {
                ShapePaint.DrawShape(e.Graphics, _pen, areaRect, _drawType);
                ResizePaint.DrawDragRectangle(e.Graphics, areaRect);
            }
        }
        #endregion

        #region Mouse Up
        //Khi thả chuột
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (_drawStatus == DrawStatus.LineDrawing)
            {
                _g = Graphics.FromImage(Image);
                _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                _drawStatus = DrawStatus.Idle;
                RedoList.Push(new Bitmap(Image));
            }

            else if (_drawStatus == DrawStatus.ToolDrawing)
            {
                _drawStatus = DrawStatus.Idle;
                RedoList.Push(new Bitmap(Image));
            }

            // Nếu là ShapeDrawing thì push Image vào UndoList và Clear RedoList nếu areaRect Width và Height > 1px
            // Không push vào RedoList ở bước này nếu không sẽ làm mất hình cuối khi Redo
            else if (_drawStatus == DrawStatus.ShapeDrawing)
            {
                _g = CreateGraphics();

                if (areaRect.Width > 1 && areaRect.Height > 1 && ptMouseDown != e.Location)
                {
                    UndoList.Push(new Bitmap(Image));
                    RedoList.Clear();
                    ShapePaint.DrawShape(_g, _pen, areaRect, _drawType);
                    ResizePaint.DrawDragRectangle(_g, areaRect);
                    _drawStatus = DrawStatus.Resize;
                }
                else _drawStatus = DrawStatus.Idle;
            }

            else if (_drawStatus == DrawStatus.Resize)
            {
                oldRect = Rectangle.Empty;
            }
        }
        #endregion

        #region DrawDrag
        private void DrawDrag(Point ptMouseDown, Point ptMouseMove, string type)
        {
            switch (type)
            {
                case "Pen":
                    _g = CreateGraphics();
                    _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                    _g = Graphics.FromImage(Image);
                    _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                    break;

                case "Eraser":
                    _g = CreateGraphics();
                    _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                    _g = Graphics.FromImage(Image);
                    _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                    break;

                case "Brush":
                    _g = CreateGraphics();
                    _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                    _g = Graphics.FromImage(Image);
                    _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                    break;
            }
        }
        #endregion

        #region Bucket
        void FloodFill(Point node, Color replaceColor)
        {
            //UndoList.Push(new Bitmap(Image));
            Bitmap DrawBitmap = new Bitmap(Image);
            Color targetColor = DrawBitmap.GetPixel(node.X, node.Y);

            if (targetColor.ToArgb() == replaceColor.ToArgb())
                return;

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(node);

            //Thực hiện flood sang 4 vị trí xung quanh, nếu trùng màu với màu ban đầu thì đổi màu và duyệt tiếp xung quanh
            while (pixels.Count != 0)
            {
                Point floodNode = pixels.Pop();

                Color floodColor = DrawBitmap.GetPixel(floodNode.X, floodNode.Y);

                if (floodColor == targetColor)
                {
                    DrawBitmap.SetPixel(floodNode.X, floodNode.Y, replaceColor);

                    if (floodNode.X - 1 >= 0)
                        pixels.Push(new Point(floodNode.X - 1, floodNode.Y));

                    if (floodNode.X + 1 < DrawBitmap.Width)
                        pixels.Push(new Point(floodNode.X + 1, floodNode.Y));

                    if (floodNode.Y - 1 >= 0)
                        pixels.Push(new Point(floodNode.X, floodNode.Y - 1));

                    if (floodNode.Y + 1 < DrawBitmap.Height)
                        pixels.Push(new Point(floodNode.X, floodNode.Y + 1));
                }
            }
            Image = (Image)DrawBitmap;
        }
        #endregion

        #region TextBox
        //void DrawTextBox()
        //{
        //    Rectangle rect = !_isShiftPress ? ShapePaint.CreateRectangle(ptMouseDown, ptMouseMove) : ShapePaint.CreateSquare(ptMouseDown, ptMouseMove);
        //    textBox = new PopupTextBox(rect.Size, rect.Location);
        //    textBox.Leave += DrawString_WhenLeave;
        //    textBox.KeyDown += DrawString_WhenPressEscape;
        //    this.Controls.Add(textBox);
        //}

        //Chèn văn bản vào vùng DrawBox
        public void AddText(string txt, Point location)
        {
            //_brush = new SolidBrush(_drawColor);
            //_g.DrawString(txt, DefaultFont, _brush, location);
            //UndoList.Push(new Bitmap(Image));
        }

        void DrawString_WhenPressEscape(object sender, KeyEventArgs e)
        {
            PopupTextBox s = sender as PopupTextBox;
            if (e.KeyCode == Keys.Escape)
            {
                AddText(s.Text, s.Location);
                s.Dispose();
            }
        }

        void DrawString_WhenLeave(object sender, EventArgs e)
        {
            PopupTextBox s = sender as PopupTextBox;
            AddText(s.Text, s.Location);
            s.Dispose();
        }
        #endregion

        #region Undo & Redo
        //Thực hiện Undo, nếu DrawBox chưa trống thì chèn Bitmap hiện tại vào Redo để có thể hoàn tác
        public void Undo()
        {
            _isOpenYet = false;
            CheckOpen();
            // Nếu đang resize mà undo thì hoàn tất resize và lưu hình vào RedoList
            if (_drawStatus == DrawStatus.Resize)
            {
                _drawStatus = DrawStatus.Idle;
                _g = Graphics.FromImage(Image);
                ShapePaint.DrawShape(_g, _pen, areaRect, _drawType);
                RedoList.Push(new Bitmap(Image));
                this.Invalidate();
            }

            if (UndoList.Count > 0)
            {
                RedoList.Push(UndoList.Peek());
                Image = (Image)UndoList.Pop();
                Size = Image.Size;
            }
        }

        public void CheckOpen()
        {
            if (_isOpenYet == true)
            {
                UndoList.Clear();
                RedoList.Clear();
                _isOpenYet = false;
            }
        }

        //Thực hiện Redo, nếu DrawBox chưa trống thì chèn Bitmap hiện tại vào Redo để có thể hoàn tác
        public void Redo()
        {
            CheckOpen();
            if (RedoList.Count > 1)
            {
                UndoList.Push(RedoList.Pop());
                Image = (Image)RedoList.Peek();
                Size = Image.Size;
            }
        }
        #endregion
    }
}