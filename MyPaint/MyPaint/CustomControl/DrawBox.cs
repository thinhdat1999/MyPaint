using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        Color _leftColor;
        Color _rightColor;

        PopupTextBox textBox;

        Point ptMouseDown;
        Point _dragPoint;

        Rectangle oldRect;
        Rectangle areaRect;

        int _dragHandle = 0;
        string _drawType;

        enum DrawStatus
        {
            Idle,
            ToolDrawing,
            ShapeDrawing,
            Resize
        };
        DrawStatus _drawStatus;

        public Image UndoListPush
        {
            set
            {
                UndoList.Push(new Bitmap(value));
                RedoList.Clear();
            }
        }

        public Image RedoListPush { set => RedoList.Push(new Bitmap(value)); }
        public Color LeftColor { set => _leftColor = value; }
        public Color RightColor { set => _rightColor = value; }
        public string DrawType { set => _drawType = value; }

        #region Constructor
        //Constructor tạo DrawBox
        public DrawBox(Size size)
        {
            Size = size;
            BackColor = Color.White;
            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();
            Image = (Image)(new Bitmap(Width, Height));
        }
        #endregion

        #region Mouse Down
        //Khởi tạo các thuộc tính khi nhấn chuột trái vào vùng DrawBox
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ptMouseDown = e.Location;

            // Lấy màu theo chuột trái - phải
            Color _drawColor = Color.Empty;

            if (e.Button == MouseButtons.Left)
            {
                _drawColor = _leftColor;
            }

            else if (e.Button == MouseButtons.Right)
            {
                _drawColor = _rightColor;
            }

            // Nếu trong trạng thái chờ thì chuẩn bị các thông số để vẽ
            // Theo từng _drawType (chia ra các trạng thái của drawStatus)
            if (_drawStatus == DrawStatus.Idle)
            {
                UndoList.Push(new Bitmap(Image));
                RedoList.Clear();

                switch (_drawType)
                {
                    case "Bucket":
                        BucketFill(e.Location, _drawColor);
                        RedoList.Push(new Bitmap(Image));
                        break;

                    case "Eraser":
                        _pen = new Pen(_rightColor, 10);
                        _drawStatus = DrawStatus.ToolDrawing;
                        break;

                    case "Brush":
                        _pen = new Pen(_drawColor, 5);
                        _drawStatus = DrawStatus.ToolDrawing;
                        break;

                    default:
                        _pen = new Pen(_drawColor);
                        _drawStatus = DrawStatus.ShapeDrawing;
                        break;
                }
            }

            // Nếu đang resize thì lấy thông tin tại điểm đặt chuột
            else if (_drawStatus == DrawStatus.Resize)
            {
                int DragPointIndex = ResizePaint.GetDragHandle(e.Location, areaRect);

                if (DragPointIndex > 0)
                {
                    _dragHandle = DragPointIndex;
                    _dragPoint = e.Location;
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

            if (_drawStatus == DrawStatus.ToolDrawing)
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
                switch (_dragHandle)
                {
                    case 1:
                        int diffX = _dragPoint.X - e.Location.X;
                        int diffY = _dragPoint.Y - e.Location.Y;
                        if (oldRect.Width + diffX > 8 && oldRect.Height + diffY > 8)
                            areaRect = new Rectangle(oldRect.Left - diffX, oldRect.Top - diffY, oldRect.Width + diffX, oldRect.Height + diffY);
                        break;

                    case 2:
                        int diff = _dragPoint.X - e.Location.X;
                        if (oldRect.Width + diff > 8)
                            areaRect = new Rectangle(oldRect.Left - diff, oldRect.Top, oldRect.Width + diff, oldRect.Height);
                        break;

                    case 3:
                        diffX = _dragPoint.X - e.Location.X;
                        diffY = _dragPoint.Y - e.Location.Y;
                        if (oldRect.Width + diffX > 8 && oldRect.Height - diffY > 8)
                            areaRect = new Rectangle(oldRect.Left - diffX, oldRect.Top, oldRect.Width + diffX, oldRect.Height - diffY);
                        break;

                    case 4:
                        diff = _dragPoint.Y - e.Location.Y;
                        if (oldRect.Height + diff > 8)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top - diff, oldRect.Width, oldRect.Height + diff);
                        break;

                    case 5:
                        diff = _dragPoint.Y - e.Location.Y;
                        if (oldRect.Height - diff > 8)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width, oldRect.Height - diff);
                        break;

                    case 6:
                        diffX = _dragPoint.X - e.Location.X;
                        diffY = _dragPoint.Y - e.Location.Y;
                        if (oldRect.Width - diffX > 8 && oldRect.Height + diffY > 8)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top - diffY, oldRect.Width - diffX, oldRect.Height + diffY);
                        break;

                    case 7:
                        diff = _dragPoint.X - e.Location.X;
                        if (oldRect.Width - diff > 8)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diff, oldRect.Height);
                        break;

                    case 8:
                        diffX = _dragPoint.X - e.Location.X;
                        diffY = _dragPoint.Y - e.Location.Y;
                        if (oldRect.Width - diffX > 8 && oldRect.Height - diffY > 8)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diffX, oldRect.Height - diffY);
                        break;
                }
                this.Invalidate();
            }
        }
        #endregion

        #region OnPaint
        //Cập nhật lại DrawBox liên tục khi đang vẽ để tạo độ mượt
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (_drawStatus == DrawStatus.ShapeDrawing)
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

            if (_drawStatus == DrawStatus.ToolDrawing)
            {
                _drawStatus = DrawStatus.Idle;
                RedoList.Push(new Bitmap(Image));
            }

            else if (_drawStatus == DrawStatus.ShapeDrawing)
            {
                _g = CreateGraphics();
                RedoList.Push(new Bitmap(Image));

                if (areaRect.Width > 8 && areaRect.Height > 8 && ptMouseDown != e.Location)
                {
                    ShapePaint.DrawShape(_g, _pen, areaRect, _drawType);
                    ResizePaint.DrawDragRectangle(_g, areaRect);
                    _drawStatus = DrawStatus.Resize;
                }
                else _drawStatus = DrawStatus.Idle;
            }

            else if (_drawStatus == DrawStatus.Resize)
            {
                _dragHandle = 0;
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
        void BucketFill(Point node, Color replaceColor)
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

                    if (floodNode.X - 1 != 0)
                        pixels.Push(new Point(floodNode.X - 1, floodNode.Y));

                    if (floodNode.X + 1 != DrawBitmap.Width)
                        pixels.Push(new Point(floodNode.X + 1, floodNode.Y));

                    if (floodNode.Y - 1 != 0)
                        pixels.Push(new Point(floodNode.X, floodNode.Y - 1));

                    if (floodNode.Y + 1 != DrawBitmap.Height)
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

        //Thực hiện Redo, nếu DrawBox chưa trống thì chèn Bitmap hiện tại vào Redo để có thể hoàn tác
        public void Redo()
        {
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