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
        Brush _brush;
        Color _drawColor;

        ShapeTool shapeTool;
        PopupTextBox textBox;

        Point ptMouseDown, ptMouseMove;
        Point dragPoint;

        Rectangle oldRect;
        Rectangle areaRect;

        int _dragHandle = 0;
        string _drawType;

        bool _isShiftPress;

        enum DrawStatus
        {
            Idle,
            Drawing,
            Resize,
            Done
        };
        DrawStatus _drawStatus;

        public Color DrawColor { set => _drawColor = value; }
        public string DrawType
        {
            set
            {
                if (_drawStatus == DrawStatus.Resize)
                {
                    string _oldType = _drawType;
                    string _newType = value;
                    if (_oldType != _newType)
                    {
                        _drawStatus = DrawStatus.Done;
                        Refresh();
                    }
                }
                _drawType = value;
            }
        }
        public bool isShiftPress { set => _isShiftPress = value; }

        #region Constructor
        //Constructor tạo DrawBox
        public DrawBox(Size size)
        {
            Size = size;
            BackColor = Color.White;

            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();

            shapeTool = new ShapeTool();
            Image = (Image)(new Bitmap(Width, Height));

        }
        #endregion

        #region Mouse Down
        //Khởi tạo các thuộc tính khi nhấn chuột trái vào vùng DrawBox
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                if (_drawStatus == DrawStatus.Idle)
                {
                    switch (_drawType)
                    {
                        //Tô màu (Bucket)
                        case "Bucket":
                            ptMouseDown = e.Location;
                            _drawStatus = DrawStatus.Drawing;
                            break;

                        //Xóa (Erase - note: nhớ chỉnh lại màu backcolor)
                        case "Erase":
                            _brush = new SolidBrush(Color.White);
                            _drawStatus = DrawStatus.Drawing;
                            break;

                        //Các hình còn lại
                        default:
                            _pen = new Pen(_drawColor);
                            _drawStatus = DrawStatus.Drawing;
                            break;
                    }
                    UndoList.Push(new Bitmap(Image));
                    RedoList.Clear();
                }

                if (_drawStatus == DrawStatus.Drawing)
                {
                    ptMouseMove = ptMouseDown = e.Location;
                }

                // Nếu đang resize thì lấy thông tin tại điểm đặt chuột
                else if (_drawStatus == DrawStatus.Resize)
                {
                    bool isDragPointClicked = false;

                    for (int i = 1; i <= 8; i++)
                    {
                        //Check xem vị trí đặt chuột có trùng với dragPoint nào không
                        // Nếu có thì isDragPointClicked = true và break
                        if (GetHandleRect(i).Contains(e.Location))
                        {
                            _dragHandle = i;
                            oldRect = areaRect;
                            dragPoint = GetHandlePoint(i);
                            isDragPointClicked = true;
                            break;
                        }
                    }

                    // Check xem có dragPoint nào được click hay không
                    // Nếu không thì kết thúc resize và vẽ hình mới vào Image
                    if (!isDragPointClicked)
                    {
                        DrawAfterResize();
                        this.Invalidate();
                    }
                }
            }
        }
        #endregion

        #region Mouse Move
        //Khi di chuyển chuột (và đè chuột trái - tức đang vẽ) trên vùng DrawBox
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_drawStatus == DrawStatus.Drawing)
            {
                ptMouseMove = e.Location;
                switch (_drawType)
                {
                    case "Pen":
                        DrawPen();
                        ptMouseDown = ptMouseMove;
                        break;

                    case "Erase":
                        DrawErase();
                        ptMouseDown = ptMouseMove;
                        break;

                    default:
                        Refresh();
                        break;
                }
            }

            if (_drawStatus == DrawStatus.Drawing)
            {
                if (!_isShiftPress)
                {
                    areaRect = shapeTool.FormRectangle(ptMouseDown, ptMouseMove);
                }
                else
                {
                    areaRect = shapeTool.FormSquare(ptMouseDown, ptMouseMove);
                }
            }

            if (_drawStatus == DrawStatus.Resize)
            {
                switch (_dragHandle)
                {
                    case 1:
                        int diffX = dragPoint.X - e.Location.X;
                        int diffY = dragPoint.Y - e.Location.Y;
                        if (oldRect.Width + diffX > 0 && oldRect.Height + diffY > 0)
                            areaRect = new Rectangle(oldRect.Left - diffX, oldRect.Top - diffY, oldRect.Width + diffX, oldRect.Height + diffY);
                        break;

                    case 2:
                        int diff = dragPoint.X - e.Location.X;
                        if (oldRect.Width + diff > 0)
                            areaRect = new Rectangle(oldRect.Left - diff, oldRect.Top, oldRect.Width + diff, oldRect.Height);
                        break;

                    case 3:
                        diffX = dragPoint.X - e.Location.X;
                        diffY = dragPoint.Y - e.Location.Y;
                        if (oldRect.Width + diffX > 0 && oldRect.Height - diffY > 0)
                            areaRect = new Rectangle(oldRect.Left - diffX, oldRect.Top, oldRect.Width + diffX, oldRect.Height - diffY);
                        break;

                    case 4:
                        diff = dragPoint.Y - e.Location.Y;
                        if (oldRect.Height + diff > 0)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top - diff, oldRect.Width, oldRect.Height + diff);
                        break;

                    case 5:
                        diff = dragPoint.Y - e.Location.Y;
                        if (oldRect.Height - diff > 0)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width, oldRect.Height - diff);
                        break;

                    case 6:
                        diffX = dragPoint.X - e.Location.X;
                        diffY = dragPoint.Y - e.Location.Y;
                        if (oldRect.Width - diffX > 0 && oldRect.Height + diffY > 0)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top - diffY, oldRect.Width - diffX, oldRect.Height + diffY);
                        break;

                    case 7:
                        diff = dragPoint.X - e.Location.X;
                        if (oldRect.Width - diff > 0)
                            areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diff, oldRect.Height);
                        break;

                    case 8:
                        diffX = dragPoint.X - e.Location.X;
                        diffY = dragPoint.Y - e.Location.Y;
                        if (oldRect.Width - diffX > 0 && oldRect.Height - diffY > 0)
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
            _g = e.Graphics;


            if (_drawStatus == DrawStatus.Idle)
            {
                areaRect = shapeTool.FormRectangle(ptMouseDown, ptMouseMove);
            }

            if (_drawStatus == DrawStatus.Drawing)
            {
                switch (_drawType)
                {
                    case "Rectangle": { DrawRectangle(); break; }
                    case "Ellipse": { DrawEllipse(); break; }
                    case "Triangle": { DrawTriangle(); break; }
                    case "Ziczac": { DrawArrow(); break; }
                    case "Line": { DrawLine(); break; }
                    case "Text": { DrawRectangle(); break; }
                }
            }

            if (_drawStatus == DrawStatus.Resize)
            {
                //Vẽ lại hình cần resize và khung hình chữ nhật chứa các drag point
                switch (_drawType)
                {
                    case "Rectangle":
                        DrawRectangle();
                        break;

                    case "Ellipse":
                        DrawEllipse();
                        break;

                    case "Triangle":
                        DrawTriangle();
                        break;

                    case "Ziczac":
                        DrawArrow();
                        break;
                }
                DrawDragRectangle();
            }
        }
        #endregion

        #region Mouse Up
        //Khi thả chuột
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _g = CreateGraphics();

            if (_drawStatus == DrawStatus.Drawing)
            {
                switch (_drawType)
                {
                    case "Pen":
                        _drawStatus = DrawStatus.Done;
                        RedoList.Push(new Bitmap(Image));
                        break;

                    case "Bucket":
                        _drawStatus = DrawStatus.Done;
                        FloodFill(ptMouseDown, _drawColor);
                        RedoList.Push(new Bitmap(Image));
                        break;

                    case "Line":
                        _drawStatus = DrawStatus.Done;
                        _g = Graphics.FromImage(Image);
                        DrawLine();
                        RedoList.Push(new Bitmap(Image));
                        break;

                    case "Rectangle":
                        if (areaRect.Width > 1 && areaRect.Height > 1)
                        {
                            DrawRectangle();
                            DrawDragRectangle();
                        }
                        break;

                    case "Ellipse":
                        if (areaRect.Width > 1 && areaRect.Height > 1)
                        {
                            DrawEllipse();
                            DrawDragRectangle();
                        }
                        break;

                    case "Triangle":
                        if (areaRect.Width > 1 && areaRect.Height > 1)
                        {
                            DrawTriangle();
                            DrawDragRectangle();
                        }
                        break;

                    case "Ziczac":
                        if (areaRect.Width > 1 && areaRect.Height > 1)
                        {
                            DrawArrow();
                            DrawDragRectangle();
                        }
                        break;

                    case "Text":
                        DrawTextBox();
                        break;
                }

            }

            if (_drawStatus == DrawStatus.Resize)
            {
                _dragHandle = 0;
            }

            if (_drawStatus == DrawStatus.Done)
            {
                _drawStatus = DrawStatus.Idle;
                Refresh();
            }
        }
        #endregion

        #region Drag Rectagle
        private void DrawDragRectangle()
        {
            _drawStatus = DrawStatus.Resize;

            Pen _dragBorderPen = new Pen(Color.LightBlue);
            _dragBorderPen.DashStyle = DashStyle.Dash;
            _g.DrawRectangle(_dragBorderPen, areaRect);

            for (int i = 1; i <= 8; i++)
            {
                _g.DrawRectangle(new Pen(Color.Black), GetHandleRect(i));
            }
        }
        #endregion

        #region Pen
        void DrawPen()
        {
            _g = CreateGraphics();
            _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
            _g = Graphics.FromImage(Image);
            _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
        }
        #endregion

        #region Line
        void DrawLine()
        {
            _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
        }
        #endregion

        #region Erase
        void DrawErase()
        {
            _g = CreateGraphics();
            _g.FillRectangle(_brush, new Rectangle(ptMouseDown, new Size(5, 5)));
            _g = Graphics.FromImage(Image);
            _g.FillRectangle(_brush, new Rectangle(ptMouseDown, new Size(5, 5)));
        }
        #endregion

        #region Rectangle
        void DrawRectangle()
        {
            _g.DrawRectangle(_pen, areaRect);
        }
        #endregion

        #region Ellipse
        void DrawEllipse()
        {
            _g.DrawEllipse(_pen, areaRect);
        }
        #endregion

        #region Triangle
        void DrawTriangle()
        {
            Point[] points = shapeTool.FormTriangle(areaRect);
            _g.DrawPolygon(_pen, points);    
        }
        #endregion

        #region Arrow
        void DrawArrow()
        {
            Point[] points = shapeTool.FormArrow(areaRect);
            _g.DrawPolygon(_pen, points);
        }

        #endregion

        #region Bucket
        //Thuật toán Flood Fill dùng stack - tìm Bitmap lớn nhất trùng màu tại điểm đã chọn và đổ màu mới
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
        void DrawTextBox()
        {
            Rectangle rect = !_isShiftPress ? shapeTool.FormRectangle(ptMouseDown, ptMouseMove) : shapeTool.FormSquare(ptMouseDown, ptMouseMove);
            textBox = new PopupTextBox(rect.Size, rect.Location);
            textBox.Leave += DrawString_WhenLeave;
            textBox.KeyDown += DrawString_WhenPressEscape;
            this.Controls.Add(textBox);
        }

        //Chèn văn bản vào vùng DrawBox
        public void AddText(string txt, Point location)
        {
            _brush = new SolidBrush(_drawColor);
            _g.DrawString(txt, DefaultFont, _brush, location);
            UndoList.Push(new Bitmap(Image));
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
            if (UndoList.Count > 0)
            {
                RedoList.Push(UndoList.Peek());
                Image = (Image)UndoList.Pop();
            }
        }

        //Thực hiện Redo, nếu DrawBox chưa trống thì chèn Bitmap hiện tại vào Redo để có thể hoàn tác
        public void Redo()
        {
            if (RedoList.Count > 1)
            {
                UndoList.Push(RedoList.Pop());
                Image = (Image)RedoList.Peek();
            }
        }
        #endregion

        #region Resize
        Point GetHandlePoint(int value)
        {
            Point result = Point.Empty;

            if (value == 1)
                result = new Point(areaRect.Left, areaRect.Top);
            else if (value == 2)
                result = new Point(areaRect.Left, areaRect.Top + (areaRect.Height / 2));
            else if (value == 3)
                result = new Point(areaRect.Left, areaRect.Bottom);
            else if (value == 4)
                result = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Top);
            else if (value == 5)
                result = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Bottom);
            else if (value == 6)
                result = new Point(areaRect.Right, areaRect.Top);
            else if (value == 7)
                result = new Point(areaRect.Right, areaRect.Top + (areaRect.Height / 2));
            else if (value == 8)
                result = new Point(areaRect.Right, areaRect.Bottom);
            return result;
        }

        Rectangle GetHandleRect(int value)
        {
            Point p = GetHandlePoint(value);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(5, 5));
        }

        void DrawAfterResize()
        {
            _g = Graphics.FromImage(Image);
            switch (_drawType)
            {
                case "Rectangle":
                    DrawRectangle();
                    break;

                case "Ellipse":
                    DrawEllipse();
                    break;

                case "Triangle":
                    DrawTriangle();
                    break;

                case "Ziczac":
                    DrawArrow();
                    break;
            }
            _drawStatus = DrawStatus.Idle;
            RedoList.Push(new Bitmap(Image));
        }
        #endregion
    }
}