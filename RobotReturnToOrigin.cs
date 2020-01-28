using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotReturnToOrigin
{
    class RobotReturnToOrigin
    {
        static void Main(string[] args)
        {
            Console.WriteLine(JudgeCircle("LL"));
            Console.ReadLine();
        }

        public static bool JudgeCircle(string moves)
        {
            int lCount = 0, rCount = 0, uCount = 0, dCount = 0;
            foreach(var a in moves)
            {
                if (a == 'L') lCount++;
                else if (a == 'R') rCount++;
                else if (a == 'U') uCount++;
                else if (a == 'D') dCount++;
                else return false;
            }
            if (lCount == rCount && uCount == dCount)
                return true;
            else
                return false;                   
        }
    }
}
