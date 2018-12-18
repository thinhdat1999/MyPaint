using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    [ToolboxItem(true)]
    class DrawBox : PictureBox
    {
        Stack<Image> UndoList;
        Stack<Image> RedoList;

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
        bool _isOpenYet;

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

        public bool IsOpen { set => _isOpenYet = value; }

        #region Constructor
        //Constructor tạo DrawBox
        public DrawBox()
        {
            UndoList = new Stack<Image>();
            RedoList = new Stack<Image>();
            Size = new Size(700, 300);
            Image = new Bitmap(Width, Height);

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

            switch (_drawStatus)
            {
                case DrawStatus.Idle:
                    if (e.Button == MouseButtons.Left)
                    {
                        _drawColor = MyPaint.LeftColor;
                    }

                    else if (e.Button == MouseButtons.Right)
                    {
                        _drawColor = MyPaint.RightColor;
                    }
                    UndoList.Push(Image);
                    RedoList.Clear();
                    SetGraphics();
                    break;

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
                            AddText(TextToDraw, areaRect);
                            textBoxPopUp.Dispose();
                        }
                        else ShapePaint.DrawShape(_g, _pen, areaRect, MyPaint.DrawType);
                        RedoList.Push(Image);
                        this.Invalidate();
                    }
                    break;
            }
        }

        private DashStyle PenStyle()
        {
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
            switch (MyPaint.DrawType)
            {
                case "Pen":
                    _pen = new Pen(_drawColor, MyPaint.PenWidth);
                    _pen.DashStyle = PenStyle();
                    _drawStatus = DrawStatus.ToolDrawing;
                    break;

                case "Bucket":
                    FloodFill(ptMouseDown, _drawColor);
                    RedoList.Push(Image);
                    break;

                case "Eraser":
                    _pen = new Pen(MyPaint.RightColor, 10);
                    _drawStatus = DrawStatus.ToolDrawing;
                    break;

                case "Brush":
                    _pen = new Pen(_drawColor, 5);
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
        //Khi di chuyển chuột (và đè chuột trái - tức đang vẽ) trên vùng DrawBox
        protected override void OnMouseMove(MouseEventArgs e)
        {
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
            base.OnMouseUp(e);

            switch (_drawStatus)
            {
                case DrawStatus.LineDrawing:
                    _g = Graphics.FromImage(Image);
                    _g.DrawLine(_pen, ptMouseDown, ptMouseMove);
                    _drawStatus = DrawStatus.Idle;
                    RedoList.Push(Image);
                    break;

                case DrawStatus.ToolDrawing:
                    _drawStatus = DrawStatus.Idle;
                    RedoList.Push(Image);
                    break;

                case DrawStatus.TextDrawing:
                    _drawStatus = DrawStatus.EditDrawing;
                    DrawTextBox(null);
                    break;

                case DrawStatus.ShapeDrawing:
                    _g = CreateGraphics();
                    if (areaRect.Width > 1 && areaRect.Height > 1 && ptMouseDown != e.Location)
                    {
                        UndoList.Push(Image);
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
            _isOpenYet = false;
            CheckOpen();
            if (_drawStatus == DrawStatus.EditDrawing)
            {
                _drawStatus = DrawStatus.Idle;
                _g = Graphics.FromImage(Image);
                ShapePaint.DrawShape(_g, _pen, areaRect, MyPaint.DrawType);
                RedoList.Push(Image);
                this.Invalidate();
            }

            if (UndoList.Count > 0)
            {
                RedoList.Push(UndoList.Peek());
                Image = UndoList.Pop();
                Size = Image.Size;
                this.Invalidate();
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

        public void Redo()
        {
            CheckOpen();
            if (RedoList.Count > 1)
            {
                UndoList.Push(RedoList.Pop());
                Image = RedoList.Peek();
                Size = Image.Size;
            }
        }

        public void PushUndo(Image image)
        {
            UndoList.Push(image);
        }

        public void PushRedo(Image image)
        {
            RedoList.Push(image);
        }
        #endregion
    }
}