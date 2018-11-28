﻿using System;
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
        
        bool _isDrawable;
        bool _isShiftPress;
        
        enum ResizeStage
        {
            Idle = 0,
            Active = 1,
            Done
        };
        ResizeStage _resizeStage;
        
        public Color DrawColor { set => _drawColor = value; }
        public string DrawType { set => _drawType = value; }
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
                // Nếu đang resize thì lấy thông tin tại điểm đặt chuột
                if (_resizeStage == ResizeStage.Active)
                {
                    bool isDragPointClicked = false;
                    _isDrawable = false;

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
                        _resizeStage = ResizeStage.Done;
                        _g = Graphics.FromImage(Image);
                        switch (_drawType)
                        {
                            case "Rectangle":
                                _g.DrawRectangle(_pen, areaRect);
                                break;

                            case "Ellipse":
                                _g.DrawEllipse(_pen, areaRect);
                                break;
                                
                            case "Triangle":
                                DrawTriangle();
                                break;
                                
                            case "Ziczac":
                                DrawArrow();
                                break;
                        }
                        this.Invalidate();
                    }
                }

                if (_resizeStage == ResizeStage.Idle)
                {
                    switch (_drawType)
                    {
                        //Tô màu (Bucket)
                        case "Bucket":
                            ptMouseDown = e.Location;
                            FloodFill(ptMouseDown, _drawColor);
                            break;


                        //Xóa (Erase - note: nhớ chỉnh lại màu backcolor)
                        case "Erase":
                            _brush = new SolidBrush(Color.White);
                            break;

                        //Vẽ pen, line, rectangle, circle
                        default:
                            _pen = new Pen(_drawColor);
                            break;
                    }

                    _isDrawable = true;
                    ptMouseMove = ptMouseDown = e.Location;
                }

                UndoList.Push(new Bitmap(Image));
                RedoList.Clear();
            }
        }
        #endregion

        #region Mouse Move
        //Khi di chuyển chuột (và đè chuột trái - tức đang vẽ) trên vùng DrawBox
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDrawable)
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
            // nếu _resizeStage = 1 thì check vị trí _dragHandle và chỉnh sửa theo mouseMove
            // Những điểm khác tương tự ( từ 1 - 8)
            /* Các drag Point trên hình chữ nhật như sau:
                1--4--6
                2-----7
                3--5--8
            */

            if (_resizeStage == ResizeStage.Active)
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
            if (_isDrawable)
            {
                _g = e.Graphics;
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

            if (_resizeStage == ResizeStage.Active)
            {
                _g = e.Graphics;

                //Vẽ lại hình cần resize và khung hình chữ nhật chứa các drag point
                switch (_drawType)
                {
                    case "Rectangle":
                        _g.DrawRectangle(_pen, areaRect);
                        DrawDragRectangle();
                        break;

                    case "Ellipse":
                        _g.DrawEllipse(_pen, areaRect);
                        DrawDragRectangle();
                        break;

                    case "Triangle":
                        DrawTriangle();
                        DrawDragRectangle();
                        break;

                    case "Ziczac":
                        DrawArrow();
                        DrawDragRectangle();
                        break;

                }

                //set lại 8 điểm drag point dựa trên hình mới
                for (int i = 1; i <= 8; i++)
                {
                    _g.DrawRectangle(new Pen(Color.Black), GetHandleRect(i));
                }
            }
        }
        #endregion

        #region Mouse Up
        //Khi thả chuột
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _g = CreateGraphics();

            if (_resizeStage == ResizeStage.Idle)
            {
                switch (_drawType)
                {
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

                    case "Line":
                        _g = Graphics.FromImage(Image);
                        DrawLine();
                        break;

                    case "Text":
                        DrawTextBox();
                        break;
                }

                _isDrawable = false;
                RedoList.Push(new Bitmap(Image));
            }

            if (_resizeStage == ResizeStage.Done)
            {
                _resizeStage = ResizeStage.Idle;
                _isDrawable = false;
            }

            if (_resizeStage == ResizeStage.Active)
            {
                _dragHandle = 0;
            }
        }
        #endregion

        #region Drag Rectagle
        private void DrawDragRectangle()
        {
            Pen _dragBorderPen = new Pen(Color.LightBlue);
            _dragBorderPen.DashStyle = DashStyle.Dash;

            _g.DrawRectangle(new Pen(Color.LightBlue), areaRect);
            _resizeStage = ResizeStage.Active;

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
            if (!_isShiftPress)
            {
                _g.DrawRectangle(_pen, shapeTool.FormRectangle(ptMouseDown, ptMouseMove));
                areaRect = shapeTool.FormRectangle(ptMouseDown, ptMouseMove);
            }
            if (_isShiftPress)
            {
                _g.DrawRectangle(_pen, shapeTool.FormSquare(ptMouseDown, ptMouseMove));
                areaRect = shapeTool.FormSquare(ptMouseDown, ptMouseMove);
            }
        }
        #endregion

        #region Ellipse
        void DrawEllipse()
        {
            if (!_isShiftPress)
            {
                _g.DrawEllipse(_pen, shapeTool.FormRectangle(ptMouseDown, ptMouseMove));
                areaRect = shapeTool.FormRectangle(ptMouseDown, ptMouseMove);
            }

            if (_isShiftPress)
            {
                _g.DrawEllipse(_pen, shapeTool.FormSquare(ptMouseDown, ptMouseMove));
                areaRect = shapeTool.FormSquare(ptMouseDown, ptMouseMove);
            }
        }
        #endregion

        #region Triangle
        void DrawTriangle()
        {

            if (!_isShiftPress)
            {
                Point[] points = shapeTool.FormTriangle(areaRect);
                _g.DrawLine(_pen, points[0], points[1]);
                _g.DrawLine(_pen, points[0], points[2]);
                _g.DrawLine(_pen, points[1], points[2]);
                if (_resizeStage == 0)
                {
                    areaRect = shapeTool.FormRectangle(ptMouseDown, ptMouseMove);
                }
            }
            if (_isShiftPress)
            {
                Point[] points = shapeTool.FormTriangle(areaRect);
                _g.DrawLine(_pen, points[0], points[1]);
                _g.DrawLine(_pen, points[0], points[2]);
                _g.DrawLine(_pen, points[1], points[2]);
                if (_resizeStage == 0)
                    areaRect = shapeTool.FormSquare(ptMouseDown, ptMouseMove);
            }
        }
        #endregion

        #region Arrow
        void DrawArrow()
        {
            if (!_isShiftPress)
            {
                Point[] points = shapeTool.FormArrow(areaRect);
                _g.DrawLine(_pen, points[0], points[1]);
                _g.DrawLine(_pen, points[0], points[2]);
                _g.DrawLine(_pen, points[1], points[3]);
                _g.DrawLine(_pen, points[2], points[4]);
                _g.DrawLine(_pen, points[4], points[6]);
                _g.DrawLine(_pen, points[3], points[5]);
                _g.DrawLine(_pen, points[5], points[6]);
                if (_resizeStage == 0)
                {
                    areaRect = shapeTool.FormRectangle(ptMouseDown, ptMouseMove);
                }
            }
            if (_isShiftPress)
            {
                Point[] points = shapeTool.FormArrow(areaRect);
                _g.DrawLine(_pen, points[0], points[1]);
                _g.DrawLine(_pen, points[0], points[2]);
                _g.DrawLine(_pen, points[1], points[3]);
                _g.DrawLine(_pen, points[2], points[4]);
                _g.DrawLine(_pen, points[4], points[6]);
                _g.DrawLine(_pen, points[3], points[5]);
                _g.DrawLine(_pen, points[5], points[6]);
                if (_resizeStage == 0)
                    areaRect = shapeTool.FormSquare(ptMouseDown, ptMouseMove);
            }
        }


        #endregion

        #region Bucket
        //Thuật toán Flood Fill dùng stack - tìm Bitmap lớn nhất trùng màu tại điểm đã chọn và đổ màu mới
        void FloodFill(Point node, Color replaceColor)
        {
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
        #endregion
    }
}