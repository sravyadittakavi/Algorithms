using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfPointsAreInStraightLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        public static bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length <= 2)
                return true;

            // Three points P(x,y), P1(x1,y1), P2(x2,y2) are in a straight line if any two pairs have same slopes.
            // Slope of P and P1 = (y-y1)/(x-x1). Slope of P1 and P2 = (y2-y1)/(x2-x1)
            // Slope 1 = Slope 2, that means (y-y1)/(x-x1) = (y2-y1)/(x2-x1) => (y-y1)*(x2-x1) = (y2-y1)*(x-x1)

            for (int i = 2; i < coordinates.Length; i++)
            {
                int x = coordinates[i][0];
                int y = coordinates[i][1];

                int x1 = coordinates[0][0];
                int y1 = coordinates[0][1];

                int x2 = coordinates[1][0];
                int y2 = coordinates[1][1];

                if ((y - y1) * (x2 - x1) != (y2 - y1) * (x - x1))
                    return false;
            }

            return true;
        }
    }
}
