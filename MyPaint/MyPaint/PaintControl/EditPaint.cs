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
    class EditPaint
    {
        static Point[] DragPoints(Rectangle rect)
        {
            Point p1 = new Point(rect.Left, rect.Top);
            Point p2 = new Point(rect.Left, rect.Top + (rect.Height / 2));
            Point p3 = new Point(rect.Left, rect.Bottom);
            Point p4 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p5 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point p6 = new Point(rect.Right, rect.Top);
            Point p7 = new Point(rect.Right, rect.Top + (rect.Height / 2));
            Point p8 = new Point(rect.Right, rect.Bottom);
            Point[] pts = { p1, p2, p3, p4, p5, p6, p7, p8 };
            return pts;
        }

        static Rectangle[] DragRects(Rectangle rect)
        {
            Rectangle[] rects = new Rectangle[8];
            Point[] pts = DragPoints(rect);

            for (int i = 0; i < 8; i++)
            {
                pts[i].Offset(-2, -2);
                rects[i] = new Rectangle(pts[i], new Size(5, 5));
            }
            return rects;
        }

        public static void DrawDragRectangle(Graphics g, Rectangle rect)
        {
            Pen pen = new Pen(Color.LightBlue);
            Rectangle[] dragRects = DragRects(rect);
            pen.DashStyle = DashStyle.Dash;
            g.DrawRectangle(pen, rect);
            g.DrawRectangles(new Pen(Color.Black), dragRects);
        }

        public static int GetDragHandle(Point ptMouseDown, Rectangle rect)
        {
            Rectangle[] rects = DragRects(rect);
            int index = rects.TakeWhile(r => !r.Contains(ptMouseDown)).Count() + 1;
            return index;
        }

        public static void UpdateResizeRect(ref Rectangle areaRect, Rectangle oldRect, Point ptMouseDown, Point ptMouseMove, int dragHandle)
        {
            switch (dragHandle)
            {
                case 1:
                    int diffX = ptMouseDown.X - ptMouseMove.X;
                    int diffY = ptMouseDown.Y - ptMouseMove.Y;
                    if (oldRect.Width + diffX > 8 && oldRect.Height + diffY > 8)
                        areaRect = new Rectangle(oldRect.Left - diffX, oldRect.Top - diffY, oldRect.Width + diffX, oldRect.Height + diffY);
                    break;

                case 2:
                    int diff = ptMouseDown.X - ptMouseMove.X;
                    if (oldRect.Width + diff > 8)
                        areaRect = new Rectangle(oldRect.Left - diff, oldRect.Top, oldRect.Width + diff, oldRect.Height);
                        break;

                case 3:
                    diffX = ptMouseDown.X - ptMouseMove.X;
                    diffY = ptMouseDown.Y - ptMouseMove.Y;
                    if (oldRect.Width + diffX > 8 && oldRect.Height - diffY > 8)
                        areaRect = new Rectangle(oldRect.Left - diffX, oldRect.Top, oldRect.Width + diffX, oldRect.Height - diffY);
                    break;

                case 4:
                    diff = ptMouseDown.Y - ptMouseMove.Y;
                    if (oldRect.Height + diff > 8)
                        areaRect = new Rectangle(oldRect.Left, oldRect.Top - diff, oldRect.Width, oldRect.Height + diff);
                    break;

                case 5:
                    diff = ptMouseDown.Y - ptMouseMove.Y;
                    if (oldRect.Height - diff > 8)
                        areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width, oldRect.Height - diff);
                    break;

                case 6:
                    diffX = ptMouseDown.X - ptMouseMove.X;
                    diffY = ptMouseDown.Y - ptMouseMove.Y;
                    if (oldRect.Width - diffX > 8 && oldRect.Height + diffY > 8)
                        areaRect = new Rectangle(oldRect.Left, oldRect.Top - diffY, oldRect.Width - diffX, oldRect.Height + diffY);
                    break;

                case 7:
                    diff = ptMouseDown.X - ptMouseMove.X;
                    if (oldRect.Width - diff > 8)
                        areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diff, oldRect.Height);
                    break;

                case 8:
                    diffX = ptMouseDown.X - ptMouseMove.X;
                    diffY = ptMouseDown.Y - ptMouseMove.Y;
                    if (oldRect.Width - diffX > 8 && oldRect.Height - diffY > 8)
                        areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diffX, oldRect.Height - diffY);
                    break;
            }
        }

        public static void UpdateMoveRect(ref Rectangle areaRect, Rectangle oldRect, Point ptMouseDown, Point ptMouseMove)
        {
            int diffX = ptMouseDown.X - ptMouseMove.X;
            int diffY = ptMouseDown.Y - ptMouseMove.Y;
            areaRect = new Rectangle(oldRect.Left - diffX, oldRect.Top - diffY, areaRect.Width, areaRect.Height);
        }
    }
}