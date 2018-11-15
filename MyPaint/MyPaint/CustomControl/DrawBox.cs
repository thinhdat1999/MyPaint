using System;
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
        private Bitmap DrawBitmap;

        private Stack<Bitmap> UndoList;
        private Stack<Bitmap> RedoList;
        private Stack<Point> pixels;

        private Graphics _g;
        private Pen MyPen;
        private Brush MyBrush;
        private Brush Eraser;

        private Color _borderColor;
        private Color _fillColor;
        private Color _oldColor;

        private ShapeFormer shapeFormer;
        private PopupTextBox textBox;

        private Point ptMouseDown;
        private Point ptCurrent;

        private int shapeType = 0;
        private bool _isDrawing;
        private bool _isShiftPress;

        public Color BorderColor { set => _borderColor = value; }
        public Color FillColor { set => _fillColor = value; } 
        public int ShapeType { get => shapeType; set => shapeType = value; }
        public bool isShiftPress { set => _isShiftPress = value; }

        //Constructor tạo DrawBox
        public DrawBox(Size size)
        {
            Size = size;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;

            _isDrawing = false;
            _isShiftPress = false;

            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();
            shapeFormer = new ShapeFormer();

            DrawBitmap = new Bitmap(Width, Height);
            Image = (Image)DrawBitmap;
        }

        //Chèn văn bản vào vùng DrawBox
        public void AddText(string txt, Point location)
        {
            _g.DrawString(txt, DefaultFont, MyBrush, location);
            UndoList.Push(new Bitmap(Image));
        }

        //Khởi tạo các thuộc tính khi nhấn chuột trái vào vùng DrawBox
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                if (shapeType == -2)
                {
                    ptMouseDown = e.Location;
                    FloodFill(ptMouseDown, _oldColor, _fillColor);
                    Image = (Image)DrawBitmap;
                    UndoList.Push(new Bitmap(Image));
                }
                else
                {
                    MyPen = new Pen(_borderColor);
                    MyBrush = new SolidBrush(_borderColor);
                    Eraser = new SolidBrush(Color.White);

                    _isDrawing = true;
                    ptCurrent = ptMouseDown = e.Location;

                    UndoList.Push(new Bitmap(Image));
                    RedoList.Clear();
                }
            }

        }
        
        //Khi di chuyển chuột (và đè chuột trái - tức đang vẽ) trên vùng DrawBox
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDrawing)
            {
                //Scribble
                if (shapeType == 0)
                {
                    ptCurrent = e.Location;
                    _g = CreateGraphics();
                    _g.DrawLine(MyPen, ptMouseDown, ptCurrent);
                    _g = Graphics.FromImage(Image);
                    _g.DrawLine(MyPen, ptMouseDown, ptCurrent);
                    ptMouseDown = ptCurrent;
                }
                //Eraser
                else if (shapeType == -1)
                {
                    ptCurrent = e.Location;
                    _g = CreateGraphics();
                    _g.FillRectangle(Eraser, new Rectangle(ptMouseDown, new Size(5, 5)));
                    _g = Graphics.FromImage(Image);
                    _g.FillRectangle(Eraser, new Rectangle(ptMouseDown, new Size(5, 5)));
                    ptMouseDown = ptCurrent;
                }
                else
                {
                    ptCurrent = e.Location;
                    Refresh();
                }
            }
        }


        //Cập nhật lại DrawBox liên tục khi đang vẽ để tạo độ mượt
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_isDrawing)
            {
                _g = e.Graphics;
                switch (shapeType)
                {
                    case 1:
                    case 4:
                        {
                            if (!_isShiftPress) _g.DrawRectangle(MyPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (_isShiftPress) _g.DrawRectangle(MyPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }

                    case 2:
                        {
                            if (!_isShiftPress) _g.DrawEllipse(MyPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (_isShiftPress) _g.DrawEllipse(MyPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }

                    case 3:
                        {
                            _g.DrawLine(MyPen, ptMouseDown, ptCurrent);
                            break;
                        }
                }
            }
        }

        //Khi thả chuột
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _g = Graphics.FromImage(Image);
            switch (shapeType)
            {
                //Vẽ hình chữ nhật (đè shift sẽ vẽ hình vuông)
                case 1:
                    {
                        if (!_isShiftPress) _g.DrawRectangle(MyPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                        if (_isShiftPress) _g.DrawRectangle(MyPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                        break;
                    }

                //Vẽ hình elip (đè shift sẽ vẽ hình tròn)
                case 2:
                    {
                        if (!_isShiftPress) _g.DrawEllipse(MyPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                        if (_isShiftPress) _g.DrawEllipse(MyPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                        break;
                    }

                //Vẽ đường thẳng
                case 3:
                    {
                        _g.DrawLine(MyPen, ptMouseDown, ptCurrent);
                        break;
                    }

                //Vẽ chữ - tạo textBox để nhập chữ, chèn sự kiện vẽ chuỗi khi TextBox biến mất
                //do nhấn Escape nhấn chuột ngoài textBox
                case 4:
                    {
                        Rectangle rect = !_isShiftPress ? shapeFormer.FormRectangle(ptMouseDown, ptCurrent) : shapeFormer.FormSquare(ptMouseDown, ptCurrent);
                        textBox = new PopupTextBox(rect.Size, rect.Location);
                        textBox.Leave += DrawString_WhenLeave;
                        textBox.KeyDown += DrawString_WhenPressEscape;
                        this.Controls.Add(textBox);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            _isDrawing = false;
            RedoList.Push(new Bitmap(Image));
        }

        
        private void DrawString_WhenPressEscape(object sender, KeyEventArgs e)
        {
            PopupTextBox s = sender as PopupTextBox;
            if (e.KeyCode == Keys.Escape)
            {
                _g.DrawString(s.Text, DefaultFont, MyBrush, s.Location);
                UndoList.Push(new Bitmap(Image));
                s.Dispose();
            }
        }


        private void DrawString_WhenLeave(object sender, EventArgs e)
        {
            PopupTextBox s = sender as PopupTextBox;
            _g.DrawString(s.Text, DefaultFont, MyBrush, s.Location);
            UndoList.Push(new Bitmap(Image));
            s.Dispose();
        }

        //Đổ màu 
        private void FloodFill(Point node, Color oldColor, Color fillColor)
        {
            oldColor = DrawBitmap.GetPixel(node.X, node.Y);
            Color curColor;
            if (oldColor.A == fillColor.A && oldColor.G == fillColor.G && oldColor.R == fillColor.R && oldColor.B == fillColor.B)
                return;
            pixels = new Stack<Point>();
            pixels.Push(node);

            while (pixels.Count > 0)
            {
                Point popped = pixels.Pop();
                if (popped.X < DrawBitmap.Width && popped.X > 0 && popped.Y < DrawBitmap.Height && popped.Y > 0)
                {
                    curColor = DrawBitmap.GetPixel(popped.X, popped.Y);
                    if (curColor == oldColor)
                    {
                        DrawBitmap.SetPixel(popped.X, popped.Y, fillColor);
                        if (popped.X - 1 < DrawBitmap.Width && popped.X -1 > 0)
                            pixels.Push(new Point(popped.X - 1, popped.Y));
                        if (popped.X +1 < DrawBitmap.Width && popped.X + 1 > 0)
                            pixels.Push(new Point(popped.X + 1, popped.Y));
                        if(popped.Y - 1 < DrawBitmap.Height && popped.Y - 1 > 0)
                            pixels.Push(new Point(popped.X, popped.Y - 1));
                        if(popped.Y + 1 < DrawBitmap.Height && popped.Y + 1 > 0)
                            pixels.Push(new Point(popped.X, popped.Y + 1));
                    }
                }
            }
        
        }

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
    }
}