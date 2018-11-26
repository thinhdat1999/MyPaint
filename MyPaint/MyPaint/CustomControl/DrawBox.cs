﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class DrawBox : PictureBox
    {
        private Stack<Bitmap> UndoList;
        private Stack<Bitmap> RedoList;
        private Bitmap temp;

        private Graphics _g;
        private Pen _pen;
        private Brush _brush;
        private Color _drawColor;

        private ShapeFormer shapeFormer;
        private PopupTextBox textBox;

        private Point ptMouseDown;
        private Point ptCurrent;
        private Point dragPoint;

        private Rectangle oldRect;
        private Rectangle areaRect;

        private int dragHandle = 0;
        private int shapeType;
        private bool _isResizing = false;
        private bool _isDrawing;
        private bool _isShiftPress;

        public Color DrawColor { set => _drawColor = value; }
        public int ShapeType { set => shapeType = value; }
        public bool isShiftPress { set => _isShiftPress = value; }

        #region Constructor
        //Constructor tạo DrawBox
        public DrawBox(Size size)
        {
            Size = size;
            BackColor = Color.White;

            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();

            shapeFormer = new ShapeFormer();
            Image = (Image)(new Bitmap(Width, Height));
            // bitmap tạm dùng để vẽ hình chữ nhật chứ các point resize 
            // Sau khi resize xong sẽ clear tất cả ( đang để ở OnPaint chưa xoá)
            // NOTE: Cần sửa lại
            temp = new Bitmap(Width, Height);
        }
        #endregion

        #region Mouse Down
        //Khởi tạo các thuộc tính khi nhấn chuột trái vào vùng DrawBox
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                // Nếu đang resize thì lấy thông tin tại điểm click
                if (_isResizing)
                {
                    bool isDragPointClicked = false;
                    for (int i = 1; i < 9; i++)
                    {
                        //Check xem vị trí đặt chuột có trùng với dragPoint nào không
                        // Nếu có thì isDragPointClicked = true và break
                        if (GetHandleRect(i).Contains(e.Location))
                        {
                            dragHandle = i;
                            oldRect = areaRect;
                            dragPoint = GetHandlePoint(i);
                            isDragPointClicked = true;
                            break;
                        }

                    }
                    // Check xem có dragPoint nào được click hay không
                    // Nếu không thì kết thúc resize và vẽ hình mới vào Image
                    if (isDragPointClicked == false)
                    {
                        _isResizing = false;
                        _g = Graphics.FromImage(Image);
                        switch (shapeType)
                        {
                            case 1:
                                {
                                    _g.DrawRectangle(_pen, areaRect);
                                    break;
                                }
                            case 2:
                                {
                                    _g.DrawEllipse(_pen, areaRect);
                                    break;
                                }
                        }

                    }
                }
                if (!_isResizing)
                {
                    UndoList.Push(new Bitmap(Image));
                    RedoList.Clear();

                    switch (shapeType)
                    {
                        //Tô màu (Bucket)
                        case -2:
                            {
                                ptMouseDown = e.Location;
                                FloodFill(ptMouseDown, _drawColor);
                                break;
                            }

                        //Xóa (Erase - note: nhớ chỉnh lại màu backcolor)
                        case -1:
                            {
                                _brush = new SolidBrush(Color.White);
                                break;
                            }

                        //Vẽ pen, line, rectangle, circle
                        default:
                            {
                                _pen = new Pen(_drawColor);
                                break;
                            }
                    }
                    
                    _isDrawing = true;
                    ptCurrent = ptMouseDown = e.Location;
                }
                
            }
        }
        #endregion

        #region Mouse Move
        //Khi di chuyển chuột (và đè chuột trái - tức đang vẽ) trên vùng DrawBox
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDrawing)
            {
                ptCurrent = e.Location;
                switch (shapeType)
                {
                    case 0:
                        {
                            DrawPen();
                            ptMouseDown = ptCurrent;
                            break;
                        }

                    case -1:
                        {
                            DrawErase();
                            ptMouseDown = ptCurrent;
                            break;
                        }

                    default:
                        {
                            Refresh();
                            break;
                        }
                }
            }
            // nếu _isResizing true thì check vị trí dragHandle và chỉnh sửa theo mouseMove
            if (_isResizing == true)
            {
                if (dragHandle == 1)
                {
                    // to do
                }
                // Những điểm khác tương tự ( từ 1 - 8)
                /* Các drag Point trên hình chữ nhật như sau:
                    1--4--6
                    2-----7
                    3--5--8
                */
                else if (dragHandle == 2)
                {
                    int diff = dragPoint.X - e.Location.X;
                    areaRect = new Rectangle(oldRect.Left - diff, oldRect.Top, oldRect.Width + diff, oldRect.Height);
                }
                else if (dragHandle == 7)
                {
                    int diff = dragPoint.X - e.Location.X;
                    areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diff, oldRect.Height);
                }

                if (dragHandle > 0)
                    this.Invalidate();
            }
        }
        #endregion

        #region OnPaint
        //Cập nhật lại DrawBox liên tục khi đang vẽ để tạo độ mượt
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_isDrawing)
            {
                _g = Graphics.FromImage(temp);
                switch (shapeType)
                {
                    case 1: { DrawRectangle(_pen); break; }
                    case 2: { DrawEllipse(); break; }
                    case 3: { DrawLine(); break; }
                    case 4: { DrawRectangle(_pen); break; }
                }
               
            }
            
            if (_isResizing)
            {
                _g = e.Graphics;
                //Vẽ lại hình  cần resize 
                switch (shapeType)
                {
                    case 1: { _g.DrawRectangle(_pen, areaRect); break; }
                    case 2: { _g.DrawEllipse(_pen, areaRect); break; }
                }
                
                //set lại 9 điểm drag point dựa trên hình mới
                for (int i = 1; i < 9; i++)
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
            
            //_g = Graphics.FromImage(Image);
            _g = CreateGraphics();
            if (!_isResizing)
            {
                switch (shapeType)
                {
                    case 1:
                        {
                            Rectangle rec = shapeFormer.FormRectangle(ptMouseDown, ptCurrent);
                            // Check xem hình chữ nhật vẽ có lớn hơn 1x1 px không
                            if (rec.Width > 1 || rec.Height > 1)
                            {
                                // NOTE: cần sửa đoạn này
                                Pen pen = new Pen(Color.Black);
                                pen.Width = 2;
                                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                                DrawRectangle(pen);
                                _isResizing = true;
                                for (int i = 1; i < 9; i++)
                                {
                                    _g.DrawRectangle(new Pen(Color.Black), GetHandleRect(i));

                                }
                            }
                            
                            break;
                        }
                    case 2: {
                            DrawEllipse();
                            _isResizing = true;
                            for (int i = 1; i < 9; i++)
                            {
                                _g.DrawRectangle(new Pen(Color.Black), GetHandleRect(i));

                            }
                            break;

                        }
                    case 3: { DrawLine(); break; }
                    case 4: { DrawTextBox(); break; }
                }

                _isDrawing = false;
                RedoList.Push(new Bitmap(Image));
            }
            if (_isResizing)
            {
                dragHandle = 0;
                //_isResizing = false;
            }

        }
        #endregion

        #region Pen
        private void DrawPen()
        {
            _g = CreateGraphics();
            _g.DrawLine(_pen, ptMouseDown, ptCurrent);
            _g = Graphics.FromImage(Image);
            _g.DrawLine(_pen, ptMouseDown, ptCurrent);
        }
        #endregion

        #region Line
        private void DrawLine()
        {
            _g.DrawLine(_pen, ptMouseDown, ptCurrent);
        }
        #endregion

        #region Erase
        private void DrawErase()
        {
            _g = CreateGraphics();
            _g.FillRectangle(_brush, new Rectangle(ptMouseDown, new Size(5, 5)));
            _g = Graphics.FromImage(Image);
            _g.FillRectangle(_brush, new Rectangle(ptMouseDown, new Size(5, 5)));
        }
        #endregion

        #region Rectangle
        private void DrawRectangle(Pen _pen)
        {
            if (!_isShiftPress) {
                _g.DrawRectangle(_pen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                areaRect = shapeFormer.FormRectangle(ptMouseDown, ptCurrent);
            }
            if (_isShiftPress) {
                _g.DrawRectangle(_pen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                areaRect = shapeFormer.FormSquare(ptMouseDown, ptCurrent);
            }
        }
        #endregion

        #region Ellipse
        private void DrawEllipse()
        {
            if (!_isShiftPress)
            {
                _g.DrawEllipse(_pen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                areaRect = shapeFormer.FormRectangle(ptMouseDown, ptCurrent);
            }

            if (_isShiftPress) {
                _g.DrawEllipse(_pen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                areaRect = shapeFormer.FormSquare(ptMouseDown, ptCurrent);
            }
        }
        #endregion

        #region Bucket
        //Thuật toán Flood Fill dùng stack - tìm Bitmap lớn nhất trùng màu tại điểm đã chọn và đổ màu mới
        private void FloodFill(Point node, Color replaceColor)
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
        private void DrawTextBox()
        {
            Rectangle rect = !_isShiftPress ? shapeFormer.FormRectangle(ptMouseDown, ptCurrent) : shapeFormer.FormSquare(ptMouseDown, ptCurrent);
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

        private void DrawString_WhenPressEscape(object sender, KeyEventArgs e)
        {
            PopupTextBox s = sender as PopupTextBox;
            if (e.KeyCode == Keys.Escape)
            {
                AddText(s.Text, s.Location);
                s.Dispose();
            }
        }

        private void DrawString_WhenLeave(object sender, EventArgs e)
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
        private Point GetHandlePoint(int value)
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

        private Rectangle GetHandleRect(int value)
        {
            Point p = GetHandlePoint(value);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(5, 5));
        }
        #endregion
    }
}