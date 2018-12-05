using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class DrawBoxPanel : Panel
    {
        private DrawBox _drawBox;
        private Color _backColor;

        public DrawBox drawBox { get => _drawBox; }
        public Color _BackColor { set => _backColor = value; }
        public DrawBoxPanel(Size size)
        {
            AutoScroll = true;
            Size = size;
            Dock = System.Windows.Forms.DockStyle.Fill;
            _drawBox = new DrawBox(Size);
            Controls.Add(_drawBox);
        }

        #region Drawbox Resize
        bool isResizing;
        Point dragPoint;
        int _dragHandle;
        Size newSize;


        Point GetDrawBoxHandlePoint(int value)
        {
            Point result = Point.Empty;

            if (value == 1)
                result = new Point(_drawBox.Left + _drawBox.Width / 2, _drawBox.Bottom);
            else if (value == 2)
                result = new Point(_drawBox.Right, _drawBox.Top + _drawBox.Height / 2);
            else if (value == 3)
                result = new Point(_drawBox.Right, _drawBox.Bottom);
            return result;
        }
        Rectangle GetDrawBoxHandleRect(int value)
        {
            Point p = GetDrawBoxHandlePoint(value);
            return new Rectangle(p, new Size(5, 5));
        }

        //Vẽ 3 dragPoint 
        void PaintDragPoint(Graphics _g)
        {

            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.White);
            for (int i = 1; i <= 3; i++)
            {
                _g.FillRectangle(brush, GetDrawBoxHandleRect(i));
                _g.DrawRectangle(pen, GetDrawBoxHandleRect(i));
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            for (int i = 1; i <= 3; i++)
            {
                if (GetDrawBoxHandleRect(i).Contains(e.Location))
                {
                    _dragHandle = i;
                    dragPoint = GetDrawBoxHandlePoint(i);
                    newSize = _drawBox.Size;
                    isResizing = true;               
                    //Lưu vào UndoList và clear RedoList
                    //_drawBox.UndoList.Push(new Bitmap(_drawBox.Image));
                    //_drawBox.RedoList.Clear();
                    break;
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //Check xem có trỏ tới vị trí drag point không và đổi icon của con trỏ tuỳ theo drag point
            int MousePos = 0;
            for (int i = 1; i <= 3; i++)
            {
                if (GetDrawBoxHandleRect(i).Contains(e.Location))
                {
                    MousePos = i;
                }
            }
            switch (MousePos)
            {
                case 1:
                    Cursor = Cursors.SizeNS;
                    break;
                case 2:
                    Cursor = Cursors.SizeWE;
                    break;
                case 3:
                    Cursor = Cursors.SizeNWSE;
                    break;
                default:
                    Cursor = Cursors.Default;
                    break;
            }

            if (isResizing)
            {
                switch (_dragHandle)
                {
                    case 1:
                        int diff = dragPoint.Y - e.Location.Y;
                        if (_drawBox.Height - diff > 1)
                            newSize = new Size(_drawBox.Width, _drawBox.Height - diff);
                        break;

                    case 2:
                        diff = dragPoint.X - e.Location.X;
                        if (_drawBox.Width - diff > 1)
                            newSize = new Size(_drawBox.Width - diff, _drawBox.Height);
                        break;

                    case 3:
                        int diffX = dragPoint.X - e.Location.X;
                        int diffY = dragPoint.Y - e.Location.Y;
                        if (_drawBox.Width - diffX > 1 && _drawBox.Height - diffY > 1)
                            newSize = new Size(_drawBox.Width - diffX, _drawBox.Height - diffY);
                        break;
                }
                Refresh();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isResizing)
            {
                isResizing = false;
                _drawBox.Size = newSize;
                Image _oldImage = _drawBox.Image;
                _drawBox.Image = (Image)new Bitmap(_drawBox.Width, _drawBox.Height);
                Graphics g = Graphics.FromImage(_drawBox.Image);
                g.DrawImage(_oldImage, 0, 0);

                // Đổi màu nền của phần resize theo Right Color của Color Panel
                if (_drawBox.Image.Width > _oldImage.Width || _drawBox.Image.Height > _oldImage.Height)
                {
                    Rectangle _oldSize = new Rectangle(0, 0, _oldImage.Width, _oldImage.Height);
                    Rectangle _newSize = new Rectangle(0, 0, _drawBox.Width, _drawBox.Height);
                    Region _oldRegion = new Region(_oldSize);
                    Region _newRegion = new Region(_newSize);
                    _newRegion.Exclude(_oldRegion);
                    SolidBrush brush = new SolidBrush(_backColor);
                    g.FillRegion(brush, _newRegion);
                }
                //_drawBox.RedoList.Push(new Bitmap(_drawBox.Image));
                Refresh();
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Vẽ các drag point khi redraw Panel
            Graphics _g = e.Graphics;
            PaintDragPoint(_g);

            // Vẽ hình chữ nhật nét đứt thể hiện kích cỡ mới của DrawBox khi đang resize
            if (isResizing)
            {
                Pen _dragBorderPen = new Pen(Color.Black);
                _dragBorderPen.DashStyle = DashStyle.Dot;
                _g.DrawRectangle(_dragBorderPen, new Rectangle(_drawBox.Location, newSize));
            }
        }

        #endregion


    }
}
