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
        private Bitmap DrawArea;
        private Stack<Bitmap> UndoList;
        private Stack<Bitmap> RedoList;

        private Graphics g;
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
        private bool _isClear;
        private bool _isShiftPress;

        public Color BorderColor { get => _borderColor; set => _borderColor = value; }
        public Color FillColor { get => _fillColor; set => _fillColor = value; }
        public int ShapeType { get => shapeType; set => shapeType = value; }
        public bool isShiftPress { get => isShiftPress; set => isShiftPress = value; }

        //Constructor tạo DrawBox
        public DrawBox(Size size)
        {
            Size = size;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;

            _isDrawing = false;
            _isClear = true;
            _isShiftPress = false;

            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();
            shapeFormer = new ShapeFormer();

            DrawArea = new Bitmap(Width, Height);
            Image = (Image)DrawArea;
            g = Graphics.FromImage(Image);
        }

        //PictureBox sẽ tải lại hình cũ khi cập nhật vẽ hình mới liên tục
        public void UpdatePictureBox()
        {
            if (DrawArea != null)
            {
                Image = DrawArea.Clone(new Rectangle(0, 0, Width, Height), DrawArea.PixelFormat);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MyPen = new Pen(_borderColor);
            MyBrush = new SolidBrush(_fillColor);

            if (e.Button == MouseButtons.Left)
            {
                ptCurrent = ptMouseDown = e.Location;
                _isDrawing = true;
                _isClear = false;
                RedoList.Clear();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            switch (shapeType)
            {
                //Vẽ hình chữ nhật (đè shift sẽ vẽ hình vuông)
                case 1:
                    {
                        if (!_isShiftPress) g.DrawRectangle(MyPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                        if (_isShiftPress) g.DrawRectangle(MyPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                        break;
                    }

                //Vẽ hình elip (đè shift sẽ vẽ hình tròn)
                case 2:
                    {
                        if (!_isShiftPress) g.DrawEllipse(MyPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                        if (_isShiftPress) g.DrawEllipse(MyPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                        break;
                    }

                //Vẽ đường thẳng
                case 3:
                    {
                        g.DrawLine(MyPen, ptMouseDown, ptCurrent);
                        break;
                    }

                //Vẽ chữ - tạo textBox để nhập chữ, chèn sự kiện vẽ chuỗi khi TextBox biến mất
                //do nhấn Escape nhấn chuột ngoài textBox
                case 4:
                    {
                        Rectangle rect = !_isShiftPress ? shapeFormer.FormRectangle(ptMouseDown, ptCurrent) : shapeFormer.FormSquare(ptMouseDown, ptCurrent);
                        textBox = new PopupTextBox(rect);
                        this.Controls.Add(textBox);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            _isDrawing = false;
            UndoList.Push(DrawArea);
            UpdatePictureBox();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDrawing)
            {
                if (shapeType == 0)
                {
                    Point ptNew = e.Location;
                    Graphics g2 = CreateGraphics();
                    g2.DrawLine(MyPen, ptCurrent, ptNew);
                    g2.Dispose();
                    g.DrawLine(MyPen, ptCurrent, ptNew);
                    ptCurrent = ptNew;
                }
                else
                {
                    ptCurrent = e.Location;
                    Refresh();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            switch (shapeType)
            {
                case 1:
                case 4:
                    {
                        if (!_isShiftPress) e.Graphics.DrawRectangle(MyPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                        if (_isShiftPress) e.Graphics.DrawRectangle(MyPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                        break;
                    }

                case 2:
                    {
                        if (!_isShiftPress) e.Graphics.DrawEllipse(MyPen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                        if (_isShiftPress) e.Graphics.DrawEllipse(MyPen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                        break;
                    }

                case 3:
                    {
                        e.Graphics.DrawLine(MyPen, ptMouseDown, ptCurrent);
                        break;
                    }
            }
        }

        //Thực hiện Undo, nếu DrawBox chưa trống thì chèn Bitmap hiện tại vào Redo để có thể hoàn tác
        public void Undo()
        {
            if (!_isClear)
            {
                RedoList.Push(new Bitmap(Image));
            }

            if (UndoList.Count > 0 && UndoList.Peek() != null)
            {
                DrawArea = new Bitmap(UndoList.Pop(), Size);
            }
            else
            {
                DrawArea = new Bitmap(Width, Height);
                _isClear = true;
            }
        }

        //Thực hiện Redo, nếu DrawBox chưa trống thì chèn Bitmap hiện tại vào Redo để có thể hoàn tác
        public void Redo()
        {
            if (!_isClear)
            {
                UndoList.Push(new Bitmap(Image));
            }

            if (RedoList.Count > 0 && RedoList.Peek() != null)
            {
                DrawArea = new Bitmap(RedoList.Pop(), Size);
                _isClear = false;
            }
        }
    }
}
