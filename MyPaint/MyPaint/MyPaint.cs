using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class MyPaint : Form
    {
        public Graphics _g;
        public Pen _pen;
        public Brush _brush;

        private Point ptMouseDown;
        private Point ptCurrent;

        private Bitmap DrawArea;
        private bool isDrawing = false;
        private bool isShifting = false;
        private bool isPictureClear = true;

        private int shapes = 0;

        private ShapeFormer shapeFormer;
        private Stack<Image> UndoList;
        private Stack<Image> RedoList;
        private PopupTextBox textBox;

        //Khởi tạo các giá trị khi load form
        public MyPaint()
        {
            InitializeComponent();
            Text = "MY PAINT :\">";
            KeyPreview = true;
            ActiveControl = PenButton;

            DrawArea = new Bitmap(DrawBox.Size.Width, DrawBox.Size.Height);
            UndoList = new Stack<Image>();
            RedoList = new Stack<Image>();
            shapeFormer = new ShapeFormer();
            _g = Graphics.FromImage(DrawArea);
        }

        //Tải lại màn hình mỗi lần vẽ hình, phần pictureBox sẽ tải lại hình cũ khi cập nhật vẽ hình mới liên tục
        public void UpdatePictureBox()
        {
            if (DrawArea != null)
            {
                DrawBox.BackgroundImage = DrawArea.Clone(new Rectangle(0, 0, DrawBox.Width, DrawBox.Height), DrawArea.PixelFormat);
            }
        }

        #region Draw Events
        private void PictureBox_MouseDown(object sender, MouseEventArgs mea)
        {
            if (mea.Button == MouseButtons.Left)
            {
                _pen = new Pen(PaintColorPanel.GetCurrentColor());
                _brush = new SolidBrush(PaintColorPanel.GetCurrentColor());

                ptCurrent = ptMouseDown = mea.Location;
                isDrawing = true;
                isPictureClear = false;
                RedoList.Clear();
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs mea)
        {
            if (isDrawing)
            {
                if (shapes >= 1 && shapes <= 4)
                {
                    ptCurrent = mea.Location;
                    Refresh();
                }

                else if (shapes == 0)
                {
                    Point ptNew = mea.Location;
                    Graphics _gpb = DrawBox.CreateGraphics();
                    _gpb.DrawLine(_pen, ptCurrent, ptNew);
                    _gpb.Dispose();
                    _g.DrawLine(_pen, ptCurrent, ptNew);
                    ptCurrent = ptNew;
                }
            }
        }
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing)
            {
                switch (shapes)
                {
                    case 1:
                    case 4:
                        {
                            if (!isShifting) e.Graphics.DrawRectangle(_pen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (isShifting) e.Graphics.DrawRectangle(_pen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }

                    case 2:
                        {
                            if (!isShifting) e.Graphics.DrawEllipse(_pen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (isShifting) e.Graphics.DrawEllipse(_pen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }
                    case 3:
                        {
                            e.Graphics.DrawLine(_pen, ptMouseDown, ptCurrent);
                            break;
                        }
                }
            }
        }

        //Lưu lại các hình vẽ sau khi thả chuột lên PictureBox
        private void PictureBox_MouseUp(object sender, MouseEventArgs mea)
        {
            if (isDrawing)
            {
                switch (shapes)
                {
                    //Vẽ hình chữ nhật (đè shift sẽ vẽ hình vuông)
                    case 1:
                        {
                            if (!isShifting) _g.DrawRectangle(_pen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (isShifting) _g.DrawRectangle(_pen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }

                    //Vẽ hình elip (đè shift sẽ vẽ hình tròn)
                    case 2:
                        {
                            if (!isShifting) _g.DrawEllipse(_pen, shapeFormer.FormRectangle(ptMouseDown, ptCurrent));
                            if (isShifting) _g.DrawEllipse(_pen, shapeFormer.FormSquare(ptMouseDown, ptCurrent));
                            break;
                        }

                    //Vẽ đường thẳng
                    case 3:
                        {
                            _g.DrawLine(_pen, ptMouseDown, ptCurrent);
                            break;
                        }

                    //Vẽ chữ - tạo textBox để nhập chữ, chèn sự kiện vẽ chuỗi khi TextBox biến mất
                    //do nhấn Escape nhấn chuột ngoài textBox
                    case 4:
                        {
                            Rectangle rect = !isShifting ? shapeFormer.FormRectangle(ptMouseDown, ptCurrent) : shapeFormer.FormSquare(ptMouseDown, ptCurrent);
                            textBox = new PopupTextBox(rect);
                            this.DrawBox.Controls.Add(textBox);
                            this.ActiveControl = textBox;
                            textBox.VisibleChanged += textBox_DrawString;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                UndoList.Push(DrawBox.BackgroundImage);
                UpdatePictureBox();
                isDrawing = false;
            }
        }

        //Vẽ chuỗi lên PictureBox và hủy textBox khi TextBox bị ẩn
        private void textBox_DrawString(object sender, EventArgs e)
        {
            PopupTextBox s = sender as PopupTextBox;
            _g.DrawString(s.Text, DefaultFont, _brush, new Rectangle(s.Location, s.Size));
            UndoList.Push(DrawBox.BackgroundImage);
            UpdatePictureBox();
            textBox.Dispose();
        }
        #endregion

        #region Click Button

        private void PenButton_Click(object sender, EventArgs e)
        {
            shapes = 0;
        }
        private void RectangleButton_Click(object sender, EventArgs e)
        {
            shapes = 1;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            shapes = 2;
        }
        private void LineButton_Click(object sender, EventArgs e)
        {
            shapes = 3;
        }
        private void TextBoxButton_Click(object sender, EventArgs e)
        {
            shapes = 4;
        }
        #endregion

        #region Undo & Redo
        //Tạo sự kiện Undo, Redo khi nhấn các tổ hợp phím Ctrl + Z, Ctrl + Y, Shift
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    Undo();
                }

                else if (e.KeyCode == Keys.Y)
                {
                    Redo();
                }
                UpdatePictureBox();
            }

            else if (e.Shift)
            {
                isShifting = true;
            }
        }

        //Khi thả nút shift
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!e.Shift) isShifting = false;
        }

        //Thực hiện Undo - Đưa các trạng thái ảnh vào Stack
        public void Undo()
        {
            if (!isPictureClear)
            {
                RedoList.Push(DrawBox.BackgroundImage);
            }

            if (UndoList.Count > 0 && UndoList.Peek() != null)
            {
                DrawArea = new Bitmap(UndoList.Pop(), DrawBox.Size);
            }
            else
            {
                DrawArea = new Bitmap(DrawBox.Size.Width, DrawBox.Size.Height);
                isPictureClear = true;
            }
        }

        public void Redo()
        {
            if (!isPictureClear)
            {
                UndoList.Push(DrawBox.BackgroundImage);
            }

            if (RedoList.Count > 0 && RedoList.Peek() != null)
            {
                DrawArea = new Bitmap(RedoList.Pop(), DrawBox.Size);
                isPictureClear = false;
            }
        }
        #endregion
    }
}
