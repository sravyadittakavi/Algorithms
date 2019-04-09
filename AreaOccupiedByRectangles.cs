using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOccupiedByRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(3, 3);
            Point p3 = new Point(2, 2);
            Point p4 = new Point(3, 3);

            Console.WriteLine("Total area occupied by rectangles = " + GetAreaOccupied(p1, p2, p3, p4));
            Console.ReadKey();
        }

        private static int GetAreaOccupied(Point p1, Point p2, Point p3, Point p4)
        {
            List<int> allX = new List<int>();
            allX.Add(p1.X);
            allX.Add(p2.X);
            allX.Add(p3.X);
            allX.Add(p4.X);

            List<int> allY = new List<int>();
            allY.Add(p1.Y);
            allY.Add(p2.Y);
            allY.Add(p3.Y);
            allY.Add(p4.Y);

            // Sort and check if 1st and 2nd elements belong to same rectangle
            // If not, they are intersecting and have common area
            allX.Sort();
            allY.Sort();

            int commonArea = 0;
            bool hasCommonArea = false;

            if(p1.X == allX[0] && p2.X != allX[1])
            {
                hasCommonArea = true;
            }

            if (p1.Y == allY[0] && p2.Y != allY[1])
            {
                hasCommonArea = true;
            }

            if (hasCommonArea)
            {
                commonArea = (allX[2] - allX[1]) * (allY[2] - allY[1]);
            }

            int totalArea = ((p2.X - p1.X) * (p2.Y - p1.Y)) +
                             ((p4.X - p3.X) * (p4.Y - p3.Y));
            return totalArea - commonArea;
        }
    }

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
