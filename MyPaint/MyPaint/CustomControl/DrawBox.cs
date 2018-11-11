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

        private Graphics _g;
        private Pen MyPen;
        private Brush MyBrush;

        private Color _borderColor;
        private Color _fillColor;

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
                MyPen = new Pen(_borderColor);
                MyBrush = new SolidBrush(_borderColor);

                _isDrawing = true;
                ptCurrent = ptMouseDown = e.Location;

                UndoList.Push(new Bitmap(Image));
                RedoList.Clear();
            }
        }
        
        //Khi di chuyển chuột (và đè chuột trái - tức đang vẽ) trên vùng DrawBox
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDrawing)
            {
                if (shapeType == 0)
                {
                    Point ptNew = e.Location;
                    Graphics _g2 = CreateGraphics();
                    _g2.DrawLine(MyPen, ptCurrent, ptNew);
                    _g2.Dispose();
                    _g.DrawLine(MyPen, ptCurrent, ptNew);
                    ptCurrent = ptNew;
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