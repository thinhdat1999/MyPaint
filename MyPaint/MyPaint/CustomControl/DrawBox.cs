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
        bool _isOpenYet;

        enum DrawStatus
        {
            Idle,
            LineDrawing,
            TextDrawing,
            ToolDrawing,
            ShapeDrawing,
            Resize
        };
        DrawStatus _drawStatus;
        public bool IsOpen { set => _isOpenYet = value; }

        #region Constructor
        //Constructor tạo DrawBox
        public DrawBox()
        {
            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();
            Size = new Size(700, 300);
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
                if (e.Button == MouseButtons.Left)
                {
                    _drawColor = MyPaint.LeftColor;
                }

                else if (e.Button == MouseButtons.Right)
                {
                    _drawColor = MyPaint.RightColor;
                }

                SetGraphics();
                UndoList.Push(new Bitmap(Image));
                RedoList.Clear();
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
                    if(MyPaint.DrawType != "Text")
                    {
                        ShapePaint.DrawShape(_g, _pen, areaRect, MyPaint.DrawType);
                        RedoList.Push(new Bitmap(Image));
                    }
                    else
                    {
                        if (TextToDraw != null)
                        {
                            AddText(TextToDraw, areaRect);
                            textBoxPopUp.Dispose();
                            RedoList.Push(new Bitmap(Image));
                        }
                        TextToDraw = "";

                    }
                    this.Invalidate();
                }
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
                    _pen = new Pen(_drawColor, 1);
                    _pen.DashStyle = PenStyle();
                    _drawStatus = DrawStatus.ToolDrawing;
                    break;

                case "Bucket":
                    FloodFill(ptMouseDown, _drawColor);
                    RedoList.Push(new Bitmap(Image));
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
                    _pen = new Pen(_drawColor);
                    _pen.DashStyle = PenStyle();
                    _drawStatus = DrawStatus.LineDrawing;
                    break;

                case "Text":
                    _pen = new Pen(_drawColor);               
                    _drawStatus = DrawStatus.TextDrawing;
                    break;

                default:
                    _pen = new Pen(_drawColor);
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

            if (_drawStatus == DrawStatus.LineDrawing)
            {
                ptMouseMove = e.Location;
                this.Invalidate();
            }

            else if (_drawStatus == DrawStatus.ToolDrawing)
            {
                DrawDrag(ptMouseDown, e.Location, MyPaint.DrawType);
                ptMouseDown = e.Location;
            }

            else if (_drawStatus == DrawStatus.TextDrawing)
            {
                areaRect = ShapePaint.CreateRectangle(ptMouseDown, e.Location);
                this.Invalidate();
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

            else if (_drawStatus == DrawStatus.TextDrawing)
            {
                Pen pen = new Pen(Color.LightBlue);
                pen.DashStyle = DashStyle.Dash;
                ShapePaint.DrawShape(e.Graphics, pen, areaRect, "Rectangle");
            }

            else if (_drawStatus == DrawStatus.ShapeDrawing)
            {
                ShapePaint.DrawShape(e.Graphics, _pen, areaRect, MyPaint.DrawType);
            }

            else if (_drawStatus == DrawStatus.Resize)
            {
                if (MyPaint.DrawType != "Text")
                {
                    ShapePaint.DrawShape(e.Graphics, _pen, areaRect, MyPaint.DrawType);
                }
                else
                {
                    if(areaRect.Height < textRect.Height)
                    {
                        areaRect.Height = textRect.Height;
                    }
                    Pen pen = new Pen(Color.LightBlue);
                    pen.DashStyle = DashStyle.Dash;
                    ShapePaint.DrawShape(e.Graphics, pen, areaRect, "Rectangle");
                }
                
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

            else if (_drawStatus == DrawStatus.TextDrawing)
            {
                _drawStatus = DrawStatus.Resize;
                DrawTextBox("");
                Refresh();
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
                    ShapePaint.DrawShape(_g, _pen, areaRect, MyPaint.DrawType);
                    ResizePaint.DrawDragRectangle(_g, areaRect);
                    _drawStatus = DrawStatus.Resize;
                }
                else _drawStatus = DrawStatus.Idle;
            }

            else if (_drawStatus == DrawStatus.Resize)
            {
                oldRect = Rectangle.Empty;
                if (MyPaint.DrawType == "Text")
                {
                    textBoxPopUp.Dispose();
                    DrawTextBox(TextToDraw);
                }
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
        void DrawTextBox(string curText)
        {
            Point location = this.PointToScreen(areaRect.Location);
            textRect = areaRect;
            textRect.Inflate(-1, -1);
            textBoxPopUp = new PopupTextBox(curText, textRect, location,
                                            () => { textRect.Size = textBoxPopUp.Size; this.Refresh(); },
                                            () => TextToDraw = textBoxPopUp.TextToDraw);
            textBoxPopUp.Show();
            textBoxPopUp.KeyDown += DrawString_WhenPressEscape;
        }

        //Chèn văn bản vào vùng DrawBox
        public void AddText(string txt, Rectangle layoutRectangle)
        {
            SolidBrush _brush = new SolidBrush(Color.Black);
            _g.DrawString(txt, DefaultFont, _brush, layoutRectangle);
            this.Refresh();
        }

        void DrawString_WhenPressEscape(object sender, KeyEventArgs e)
        {
            PopupTextBox s = sender as PopupTextBox;
            if (e.KeyCode == Keys.Escape)
            {
                s.Dispose();
                _drawStatus = DrawStatus.Idle;
                this.Invalidate();
            }
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
                ShapePaint.DrawShape(_g, _pen, areaRect, MyPaint.DrawType);
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

        public void PushUndo(Image image)
        {
            UndoList.Push(new Bitmap(image));
        }

        public void PushRedo(Image image)
        {
            RedoList.Push(new Bitmap(image));
        }
        #endregion
    }
}