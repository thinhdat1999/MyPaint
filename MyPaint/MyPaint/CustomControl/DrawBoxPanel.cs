using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    [ToolboxItem(true)]
    class DrawBoxPanel : Panel
    {
        int dragHandleIndex;
        Rectangle[] dragRects;
        DrawBox _drawBox;

        enum PanelStatus
        {
            Idle,
            Resize
        };
        PanelStatus panelStatus;

        public DrawBox DrawBox { get => _drawBox; }

        public DrawBoxPanel()
        {
            Controls.Add(_drawBox = new DrawBox());
        }

        #region Drawbox Resize
        // Tạo DragRectangles để Resize tại 3 vị trí (dưới, phải và phải dưới)
        void InitDragRectangles()
        {
            Point p1 = new Point(_drawBox.Right, _drawBox.Bottom);
            Point p2 = new Point(_drawBox.Left + _drawBox.Width / 2, _drawBox.Bottom);
            Point p3 = new Point(_drawBox.Right, _drawBox.Top + _drawBox.Height / 2);
            Point[] dragPoints = { p1, p2, p3 };

            dragRects = new Rectangle[3];

            for (int i = 0; i < 3; i++)
            {
                dragRects[i] = new Rectangle(dragPoints[i], new Size(5, 5));
            }
        }

        // Vẽ các hình chữ nhật tại 3 góc
        void DrawDragRects(Graphics _g)
        {
            InitDragRectangles();
            _g.FillRectangles(new SolidBrush(Color.White), dragRects);
            _g.DrawRectangles(new Pen(Color.Black), dragRects);
        }

        // Khi nhấn chuột, kiểm tra xem có dragRectangle nào được chọn hay không
        // Nếu có tức là bắt đầu Resize _drawBox, láy điểm bắt đầu tại điểm đặt chuột
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (dragHandleIndex != 4)
            {
                _drawBox.PushUndo(_drawBox.Image);
                panelStatus = PanelStatus.Resize;
            }
        }

        // Khi di chuyển chuột, thay đổi con trỏ chuột khi vào vùng hình chữ nhật Resize
        // Nếu đang kéo chuột để Resize thì cập nhật size mới
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            try
            {
                if (panelStatus == PanelStatus.Idle)
                {
                    dragHandleIndex = dragRects.TakeWhile(rect => !rect.Contains(e.Location)).Count() + 1;

                    switch (dragHandleIndex)
                    {
                        case 1:
                            Cursor = Cursors.SizeNWSE;
                            break;

                        case 2:
                            Cursor = Cursors.SizeNS;
                            break;

                        case 3:
                            Cursor = Cursors.SizeWE;
                            break;

                        case 4:
                            Cursor = Cursors.Default;
                            break;
                    }
                }

            }
            catch { }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawDragRects(e.Graphics);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                if (panelStatus == PanelStatus.Resize)
                {
                    panelStatus = PanelStatus.Idle;

                    switch (dragHandleIndex)
                    {
                        case 1:
                            _drawBox.Size = new Size(e.Location.X, e.Location.Y);
                            break;

                        case 2:
                            _drawBox.Size = new Size(_drawBox.Width, e.Location.Y);
                            break;

                        case 3:
                            _drawBox.Size = new Size(e.Location.X, _drawBox.Height);
                            break;
                    }

                    Image _oldImage = _drawBox.Image;
                    _drawBox.Image = new Bitmap(_drawBox.Width, _drawBox.Height);

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
                        SolidBrush brush = new SolidBrush(ColorPanel.RightColor);
                        g.FillRegion(brush, _newRegion);
                    }
                    _drawBox.PushRedo(_drawBox.Image);
                }
            }
            catch { }
            this.Invalidate();
        }
        #endregion
    }
}