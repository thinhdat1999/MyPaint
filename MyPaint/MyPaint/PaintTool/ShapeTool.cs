using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class ShapeTool
    {
        //Tạo hình chữ nhật tại các tọa độ chuột
        public Rectangle FormRectangle(Point ptMouseDown, Point ptCurrent)
        {
            return new Rectangle(
                Math.Min(ptMouseDown.X, ptCurrent.X),
                Math.Min(ptMouseDown.Y, ptCurrent.Y),
                Math.Abs(ptMouseDown.X - ptCurrent.X),
                Math.Abs(ptMouseDown.Y - ptCurrent.Y));
        }

        //Tạo hình vuông tại các tọa độ chuột
        public Rectangle FormSquare(Point ptMouseDown, Point ptCurrent)
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

        public Point[] FormTriangle(Rectangle areaRect)
        {
            Point[] points = new Point[3];
            
            points[0] = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Top);
            points[1] = new Point(areaRect.Left, areaRect.Bottom);
            points[2] = new Point(areaRect.Right, areaRect.Bottom);
            return points;
        }
        
        public Point[] FormArrow(Rectangle areaRect)
        {
            Point[] points = new Point[7];
            points[0] = new Point(areaRect.Right, areaRect.Top + (areaRect.Height / 2));
            points[1] = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Top); 
            points[2] = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Bottom);
            points[3] = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Top + (areaRect.Height / 4));
            points[4] = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Bottom - (areaRect.Height / 4));
            points[5] = new Point(areaRect.Left, areaRect.Top + (areaRect.Height / 4));
            points[6] = new Point(areaRect.Left, areaRect.Bottom - (areaRect.Height / 4));
            return points;
        }
    }
}
