using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paint
{
    [ToolboxItem(true)]
    class DrawBox : PictureBox
    {
        Stack<Bitmap> UndoList;
        Stack<Bitmap> RedoList;

        Graphics _g;
        Pen _pen;
        Color _drawColor;

        PopupTextBox textBoxPopUp;
        string TextToDraw;

        Point ptMouseDown;
        Point ptMouseMove;

        Rectangle oldRect;
        Rectangle areaRect;
        Rectangle textRect;

        int _dragHandle = 0;

        // Các trạng thái vẽ hình trên DrawBox
        enum DrawStatus
        {
            Idle,
            LineDrawing,
            TextDrawing,
            ToolDrawing,
            ShapeDrawing,
            EditDrawing,
            ResizingShape,
            MovingShape
        };
        DrawStatus _drawStatus;

        #region Constructor
        //Constructor tạo DrawBox
        public DrawBox()
        {
            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();
            Size = new Size(700, 300);
            Image = new Bitmap(Width, Height);

            Region region = new Region(new Rectangle(0, 0, Width, Height));
            _g = Graphics.FromImage(Image);
            _g.FillRegion(new SolidBrush(Color.White), region);
        }
        #endregion

        #region Mouse Down
        // Khởi tạo các thuộc tính khi nhấn chuột trái vào vùng DrawBox
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ptMouseDown = ptMouseMove = e.Location;

            switch (_drawStatus)
            {
                // Trường hơp chưa vẽ: lấy màu vẽ
                case DrawStatus.Idle:
                    if (e.Button == MouseButtons.Left)
                    {
                        _drawColor = MyPaint.LeftColor;
                    }

                    else if (e.Button == MouseButtons.Right)
                    {
                        _drawColor = MyPaint.RightColor;
                    }

                    SetGraphics();
                    break;

                // Đang chỉnh hình (Edit, Resize): căn cứ con trỏ chuột đang trỏ chuột:
                // Trỏ chuột trên 8 ô Resize: chuyển sang trạng thái Resize hình
                // Trỏ chuột trong hình: Chuyển sang trạng thái Move hình
                // Trỏ chuột ngoài hình: Kết thúc và vẽ hình

                case DrawStatus.EditDrawing:
                    if (_dragHandle != 9)
                    {
                        oldRect = areaRect;
                        _drawStatus = DrawStatus.ResizingShape;
                    }

                    else if (areaRect.Contains(e.Location))
                    {
                        oldRect = areaRect;
                        _drawStatus = DrawStatus.MovingShape;
                    }

                    else
                    {
                        _drawStatus = DrawStatus.Idle;
                        _g = Graphics.FromImage(Image);

                        if (MyPaint.DrawType == "Text")
                        {
                            if (TextToDraw != null)
                            {
                                UndoList.Push(new Bitmap(Image));
                                RedoList.Clear();
                                AddText(TextToDraw, areaRect);
                                RedoList.Push(new Bitmap(Image));
                            }
                            textBoxPopUp.Dispose();
                        }
                        else
                        {
                            ShapePaint.DrawShape(_g, _pen, areaRect, MyPaint.DrawType);
                            RedoList.Push(new Bitmap(Image));
                        }
                        areaRect = Rectangle.Empty;
                        this.Invalidate();
                    }
                    break;
            }
        }

        private DashStyle PenStyle()
        {
            // Lấy kiểu vẽ dựa trên chuỗi thu được

            switch (MyPaint.DrawStyle)
            {
                case "Solid":
                    return DashStyle.Solid;

                case "Dash":
                    return DashStyle.Dash;

                case "Dot":
                    return DashStyle.Dot;

                case "Dash Dot":
                    return DashStyle.DashDot;

                case "Dash Dot Dot":
                    return DashStyle.DashDotDot;

                default:
                    return DashStyle.Solid;
            }
        }

        private void SetGraphics()
        {
            // Chuẩn bị các thông số cho từng loại Vẽ

            switch (MyPaint.DrawType)
            {
                case "Pen":
                    UndoList.Push(new Bitmap(Image));
                    RedoList.Clear();
                    _pen = new Pen(_drawColor);
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
                    _pen = new Pen(MyPaint.RightColor, 10 + MyPaint.PenWidth);
                    _drawStatus = DrawStatus.ToolDrawing;
                    break;

                case "Brush":
                    UndoList.Push(new Bitmap(Image));
                    RedoList.Clear();
                    _pen = new Pen(_drawColor, 5 + MyPaint.PenWidth);
                    _drawStatus = DrawStatus.ToolDrawing;
                    break;

                case "Line":
                    _pen = new Pen(_drawColor, MyPaint.PenWidth);
                    _pen.DashStyle = PenStyle();
                    _drawStatus = DrawStatus.LineDrawing;
                    break;

                case "Text":
                    _pen = new Pen(Color.LightBlue);
                    _pen.DashStyle = DashStyle.Dash;
                    _drawStatus = DrawStatus.TextDrawing;
                    break;

                case "Picker":
                    break;

                default:
                    _pen = new Pen(_drawColor, MyPaint.PenWidth);
                    _pen.DashStyle = PenStyle();
                    _drawStatus = DrawStatus.ShapeDrawing;
                    break;
            }
        }
        #endregion

        #region Mouse Move
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Khi di chuyển chuột (và đè chuột trái - tức đang vẽ) trên vùng DrawBox
            // Với các trường hợp vẽ hình: liên tục cập nhật lại DrawBox để tạo độ mượt 
            // (xét trường hợp có đè nút Shift tạo hình vuông) ở phần vẽ hình

            base.OnMouseMove(e);

            switch (_drawStatus)
            {
                case DrawStatus.LineDrawing:
                    ptMouseMove = e.Location;
                    break;

                case DrawStatus.ToolDrawing:
                    DrawDrag(ptMouseDown, e.Location, MyPaint.DrawType);
                    ptMouseDown = e.Location;
                    break;

                case DrawStatus.TextDrawing:
                    areaRect = ShapePaint.CreateRectangle(ptMouseDown, e.Location);
                    break;

                case DrawStatus.ShapeDrawing:
                    if (ModifierKeys == Keys.Shift)
                        areaRect = ShapePaint.CreateSquare(ptMouseDown, e.Location);
                    else areaRect = ShapePaint.CreateRectangle(ptMouseDown, e.Location);
                    break;

                case DrawStatus.EditDrawing:
                    _dragHandle = EditPaint.GetDragHandle(e.Location, areaRect);
                    if (_dragHandle < 9)
                        UpdateCursor();
                    else if (areaRect.Contains(e.Location))
                        Cursor = Cursors.SizeAll;
                    else Cursor = Cursors.Default;
                    break;

                case DrawStatus.ResizingShape:
                    EditPaint.UpdateResizeRect(ref areaRect, oldRect, ptMouseDown, e.Location, _dragHandle);
                    break;

                case DrawStatus.MovingShape:
                    EditPaint.UpdateMoveRect(ref areaRect, oldRect, ptMouseDown, e.Location);
                    break;
            }
            this.Invalidate();
        }

        private void UpdateCursor()
        {
            // Cập nhật hình ảnh con trỏ khi Resize hình

            switch (_dragHandle)
            {
                case 1:
                case 8:
                    Cursor = Cursors.SizeNWSE;
                    break;

                case 2:
                case 7:
                    Cursor = Cursors.SizeWE;
                    break;

                case 3:
                case 6:
                    Cursor = Cursors.SizeNESW;
                    break;

                case 4:
                case 5:
                    Cursor = Cursors.SizeNS;
                    break;
            }
        }
        #endregion

        #region OnPaint
        protected override void OnPaint(PaintEventArgs e)
        {
            // Vẽ liên tục các hình tạm trên DrawBox nhằm tạo độ mượt

            base.OnPaint(e);

            switch (_drawStatus)
            {
                case DrawStatus.LineDrawing:
                    e.Graphics.DrawLine(_pen, ptMouseDown, ptMouseMove);
                    break;

                case DrawStatus.TextDrawing:
                    ShapePaint.DrawShape(e.Graphics, _pen, areaRect, "Rectangle");
                    break;

                case DrawStatus.ShapeDrawing:
                    ShapePaint.DrawShape(e.Graphics, _pen, areaRect, MyPaint.DrawType);
                    break;

                case DrawStatus.ResizingShape:
                case DrawStatus.MovingShape:
                case DrawStatus.EditDrawing:
                    if (MyPaint.DrawType == "Text")
                    {
                        if (areaRect.Height < textRect.Height)
                        {
                            areaRect.Height = textRect.Height;
                            ShapePaint.DrawShape(e.Graphics, _pen, areaRect, "Rectangle");
                        }
                    }
                    else ShapePaint.DrawShape(e.Graphics, _pen, areaRect, MyPaint.DrawType);
                    EditPaint.DrawDragRectangle(e.Graphics, areaRect);
                    break;
            }
        }
        #endregion

        #region Mouse Up
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Nhấc chuột lên: Hoàn thành vẽ với vẽ đường thẳng, các trường hợp còn lại chuyển sang Resize

            base.OnMouseUp(e);

            switch (_drawStatus)
            {
                case DrawStatus.LineDrawing:
                    _g = Graphics.FromImage(Image);
                    if (ptMouseDown != ptMouseMove)
                    {
                        UndoList.Push(new Bitmap(Image));
                        RedoList.Clear();
                        _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                        RedoList.Push(new Bitmap(Image));
                    }
                    _drawStatus = DrawStatus.Idle;
                    break;

                case DrawStatus.ToolDrawing:
                    _drawStatus = DrawStatus.Idle;
                    RedoList.Push(new Bitmap(Image));
                    break;

                case DrawStatus.TextDrawing:          
                    if (areaRect != Rectangle.Empty)
                    {
                        _drawStatus = DrawStatus.EditDrawing;
                        DrawTextBox(null);
                    }
                    else _drawStatus = DrawStatus.Idle;
                    break;

                case DrawStatus.ShapeDrawing:
                    _g = CreateGraphics();
                    if (areaRect.Width > 1 && areaRect.Height > 1 && ptMouseDown != e.Location)
                    {
                        UndoList.Push(new Bitmap(Image));
                        RedoList.Clear();
                        ShapePaint.DrawShape(_g, _pen, areaRect, MyPaint.DrawType);
                        EditPaint.DrawDragRectangle(_g, areaRect);
                        _drawStatus = DrawStatus.EditDrawing;
                    }
                    else _drawStatus = DrawStatus.Idle;
                    break;

                case DrawStatus.ResizingShape:
                case DrawStatus.MovingShape:
                    if (MyPaint.DrawType == "Text")
                    {
                        textBoxPopUp.Dispose();
                        DrawTextBox(TextToDraw);
                    }
                    _drawStatus = DrawStatus.EditDrawing;
                    break;
            }
        }
        #endregion

        #region DrawDrag
        private void DrawDrag(Point ptMouseDown, Point ptMouseMove, string type)
        {
            // Một số dạng vẽ hình tự do (vẽ bút chì, tẩy, cọ)

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
            // Áp dụng thuật toán FloodFill nhằm tô màu vùng chọn cùng màu lớn nhất

            Bitmap DrawBitmap = new Bitmap(Image);
            Color targetColor = DrawBitmap.GetPixel(node.X, node.Y);

            if (targetColor.ToArgb() == replaceColor.ToArgb())
                return;

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(node);

            while (pixels.Count != 0)
            {
                Point floodNode = pixels.Pop();
                Color floodColor = DrawBitmap.GetPixel(floodNode.X, floodNode.Y);

                if (floodColor == targetColor)
                {
                    DrawBitmap.SetPixel(floodNode.X, floodNode.Y, replaceColor);

                    if (floodNode.X != 0)
                        pixels.Push(new Point(floodNode.X - 1, floodNode.Y));

                    if (floodNode.X + 1 < Width)
                        pixels.Push(new Point(floodNode.X + 1, floodNode.Y));

                    if (floodNode.Y != 0)
                        pixels.Push(new Point(floodNode.X, floodNode.Y - 1));

                    if (floodNode.Y + 1 < Height)
                        pixels.Push(new Point(floodNode.X, floodNode.Y + 1));
                }
            }
            Image = DrawBitmap;
        }
        #endregion

        #region TextBox
        void DrawTextBox(string curText)
        {
            // Trường hợp thêm Text: chuẩn bị form Popup chứa RichtextBox để nhận vùng nhập Text

            Point location = PointToScreen(areaRect.Location);
            textRect = areaRect;
            textRect.Inflate(-1, -1);
            textBoxPopUp = new PopupTextBox(curText, textRect, location,
                                            () => { textRect.Size = textBoxPopUp.Size; this.Refresh(); },
                                            () => TextToDraw = textBoxPopUp.TextToDraw);
            textBoxPopUp.Show();
            textBoxPopUp.KeyDown += DrawString_WhenPressEscape;
        }

        public void AddText(string txt, Rectangle layoutRectangle)
        {
            // Vẽ text lên màn hình (khi đã nhập xong)

            SolidBrush _brush = new SolidBrush(MyPaint.LeftColor);
            _g.DrawString(txt, DefaultFont, _brush, layoutRectangle);
            TextToDraw = null;
        }

        void DrawString_WhenPressEscape(object sender, KeyEventArgs e)
        {
            PopupTextBox s = sender as PopupTextBox;
            if (e.KeyCode == Keys.Escape)
            {
                s.Dispose();
                _drawStatus = DrawStatus.Idle;
            }
        }
        #endregion

        #region Undo & Redo
        public void Undo()
        {
            if (_drawStatus == DrawStatus.EditDrawing)
            {
                _drawStatus = DrawStatus.Idle;
                _g = Graphics.FromImage(Image);
                ShapePaint.DrawShape(_g, _pen, areaRect, MyPaint.DrawType);
                RedoList.Push(new Bitmap(Image));
            }

            if (UndoList.Count > 0)
            {
                RedoList.Push(UndoList.Peek());
                Image = UndoList.Pop();
                Size = Image.Size;
            }
        }

        public void Redo()
        {
            if (RedoList.Count > 1)
            {
                UndoList.Push(RedoList.Pop());
                Image = RedoList.Peek();
                Size = Image.Size;
            }
        }

        public void PushUndo(Image image)
        {
            UndoList.Push(new Bitmap(image));
        }

        public void PushRedo(Image image)
        {
            RedoList.Push(new Bitmap(image));
        }

        public void ClearUndoRedo()
        {
            UndoList.Clear();
            RedoList.Clear();
        }
        #endregion
    }
}