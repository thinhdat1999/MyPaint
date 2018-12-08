using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class ResizePaint
    {
        public static void DrawDragRectangle(Graphics g, Rectangle rect)
        {
            Pen _pen = new Pen(Color.LightBlue);
            _pen.DashStyle = DashStyle.Dash;
            g.DrawRectangle(_pen, rect);

            Rectangle[] rects = DragRects(rect);

            foreach (Rectangle r in rects)
            {
                g.DrawRectangle(new Pen(Color.Black), r);
            }
        }

        public static int GetDragHandle(Point ptMouseDown, Rectangle rect)
        {
            Rectangle[] rects = DragRects(rect);
            int index = rects.TakeWhile(r => !r.Contains(ptMouseDown)).Count() + 1;
            return index < 9 ? index : -1;
        }

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
                pts[i].Offset(-2,-2);
                rects[i] = new Rectangle(pts[i], new Size(5, 5));
            }
            return rects;
        }
    }
}
