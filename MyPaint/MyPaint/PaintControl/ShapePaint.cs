using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public static class ShapePaint
    {
        #region Rectangle
        //Tạo hình chữ nhật tại các tọa độ chuột
        public static Rectangle CreateRectangle(Point ptMouseDown, Point ptCurrent)
        {
            return new Rectangle(
                Math.Min(ptMouseDown.X, ptCurrent.X),
                Math.Min(ptMouseDown.Y, ptCurrent.Y),
                Math.Abs(ptMouseDown.X - ptCurrent.X),
                Math.Abs(ptMouseDown.Y - ptCurrent.Y));
        }
        #endregion

        #region Square
        //Tạo hình vuông tại các tọa độ chuột
        public static Rectangle CreateSquare(Point ptMouseDown, Point ptCurrent)
        {
            if ((ptMouseDown.X - ptCurrent.X) > Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)))
                return new Rectangle(
                    ptMouseDown.X - Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                        Math.Min(ptMouseDown.Y, ptCurrent.Y),
                        Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                        Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));

            else if ((ptMouseDown.Y - ptCurrent.Y) > Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)))
                return new Rectangle(
                    Math.Min(ptMouseDown.X, ptCurrent.X),
                    ptMouseDown.Y - Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                    Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                    Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));

            return new Rectangle(
                Math.Min(ptMouseDown.X, ptCurrent.X),
                Math.Min(ptMouseDown.Y, ptCurrent.Y),
                Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));
        }
        #endregion

        #region Triangle
        private static Point[] TrianglePoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p1 = new Point(rect.Left, rect.Bottom);
            Point p2 = new Point(rect.Right, rect.Bottom);
            Point[] pts = { p0, p1, p2 };
            return pts;
        }
        #endregion

        #region SqrTriangle
        private static Point[] SqrTrianglePoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Right, rect.Top);
            Point p1 = new Point(rect.Left, rect.Bottom);
            Point p2 = new Point(rect.Right, rect.Bottom);
            Point[] pts = { p0, p1, p2 };
            return pts;
        }
        #endregion

        #region Arrows
        private static Point[] RightArrowPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Right, rect.Top + (rect.Height / 2));
            Point p1 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p2 = new Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 4));
            Point p3 = new Point(rect.Left, rect.Top + (rect.Height / 4));
            Point p4 = new Point(rect.Left, rect.Bottom - (rect.Height / 4));
            Point p5 = new Point(rect.Left + (rect.Width / 2), rect.Bottom - (rect.Height / 4));
            Point p6 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6 };
            return pts;
        }

        private static Point[] LeftArrowPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left, rect.Top + (rect.Height / 2));
            Point p1 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p2 = new Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 4));
            Point p3 = new Point(rect.Right, rect.Top + (rect.Height / 4));
            Point p4 = new Point(rect.Right, rect.Bottom - (rect.Height / 4));
            Point p5 = new Point(rect.Left + (rect.Width / 2), rect.Bottom - (rect.Height / 4));
            Point p6 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6 };
            return pts;
        }

        private static Point[] UpArrowPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p1 = new Point(rect.Left, rect.Top + (rect.Height / 2));
            Point p2 = new Point(rect.Left + (rect.Width / 4), rect.Top + (rect.Height / 2));
            Point p3 = new Point(rect.Left + (rect.Width / 4), rect.Bottom);
            Point p4 = new Point(rect.Right - (rect.Width / 4), rect.Bottom);
            Point p5 = new Point(rect.Right - (rect.Width / 4), rect.Bottom - (rect.Height / 2));
            Point p6 = new Point(rect.Right, rect.Bottom - (rect.Height / 2));
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6 };
            return pts;
        }

        private static Point[] DownArrowPoint(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point p1 = new Point(rect.Left, rect.Top + (rect.Height / 2));
            Point p2 = new Point(rect.Left + (rect.Width / 4), rect.Top + (rect.Height / 2));
            Point p3 = new Point(rect.Left + (rect.Width / 4), rect.Top);
            Point p4 = new Point(rect.Right - (rect.Width / 4), rect.Top);
            Point p5 = new Point(rect.Right - (rect.Width / 4), rect.Bottom - (rect.Height / 2));
            Point p6 = new Point(rect.Right, rect.Bottom - (rect.Height / 2));
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6 };
            return pts;
        }
        #endregion

        #region Rhombus
        private static Point[] RhombusPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Right, rect.Top + (rect.Height / 2));
            Point p1 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p2 = new Point(rect.Left, rect.Top + (rect.Height / 2));
            Point p3 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point[] pts = { p0, p1, p2, p3 };
            return pts;
        }
        #endregion

        #region Pentagon
        private static Point[] PentagonPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + rect.Width / 2, rect.Top);
            Point p1 = new Point(rect.Left, rect.Top + (11 * rect.Height / 30));
            Point p2 = new Point(rect.Left + rect.Width / 5, rect.Bottom);
            Point p3 = new Point(rect.Right - rect.Width / 5, rect.Bottom);
            Point p4 = new Point(rect.Right, rect.Top + (11 * rect.Height / 30));
            Point[] pts = { p0, p1, p2, p3, p4 };
            return pts;
        }
        #endregion

        #region Hexagon
        private static Point[] HexagonPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Right, rect.Top + (rect.Height / 4));
            Point p1 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p2 = new Point(rect.Left, rect.Top + (rect.Height / 4));
            Point p3 = new Point(rect.Left, rect.Bottom - (rect.Height / 4));
            Point p4 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point p5 = new Point(rect.Right, rect.Bottom - (rect.Height / 4));
            Point[] pts = { p0, p1, p2, p3, p4, p5 };
            return pts;
        }
        #endregion

        #region Star
        private static Point[] StarPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + rect.Width / 2, rect.Top);
            Point p1 = new Point(rect.Left + 3 * rect.Width / 8, rect.Top + rect.Height / 3);
            Point p2 = new Point(rect.Left, rect.Top + (11 * rect.Height / 30));
            Point p3 = new Point(rect.Left + rect.Width / 4, rect.Bottom - (2 * rect.Height / 5));
            Point p4 = new Point(rect.Left + rect.Width / 5, rect.Bottom);
            Point p5 = new Point(rect.Left + rect.Width / 2, rect.Bottom - (rect.Height / 5));
            Point p6 = new Point(rect.Right - rect.Width / 5, rect.Bottom);
            Point p7 = new Point(rect.Right - rect.Width / 4, rect.Bottom - (2 * rect.Height / 5));
            Point p8 = new Point(rect.Right, rect.Top + (11 * rect.Height / 30));
            Point p9 = new Point(rect.Right - 3 * rect.Width / 8, rect.Top + rect.Height / 3);
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 };
            return pts;
        }
        #endregion

        #region DrawShape
        public static void DrawShape(Graphics g, Pen pen, Rectangle rect, string type)
        {
            try
            {
                Point[] pts = null;

                switch (type)
                {
                    case "Rectangle":
                        g.DrawRectangle(pen, rect);
                        return;

                    case "Ellipse":
                        g.DrawEllipse(pen, rect);
                        return;

                    case "Triangle":
                        pts = TrianglePoints(rect);
                        break;

                    case "SqrTriangle":
                        pts = SqrTrianglePoints(rect);
                        break;

                    case "LeftArrow":
                        pts = LeftArrowPoints(rect);
                        break;

                    case "RightArrow":
                        pts = RightArrowPoints(rect);
                        break;

                    case "UpArrow":
                        pts = UpArrowPoints(rect);
                        break;

                    case "DownArrow":
                        pts = DownArrowPoint(rect);
                        break;

                    case "Rhombus":
                        pts = RhombusPoints(rect);
                        break;

                    case "Pentagon":
                        pts = PentagonPoints(rect);
                        break;

                    case "Hexagon":
                        pts = HexagonPoints(rect);
                        break;

                    case "Star":
                        pts = StarPoints(rect);
                        break;
                }
                g.DrawPolygon(pen, pts);
            }
            catch { }
        }
        #endregion
    }
}
