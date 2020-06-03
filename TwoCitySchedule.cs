using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoCitySchedule
{
    class TwoCitySchedule
    {
        static void Main(string[] args)
        {
            int[][] costs = new int[4][];
            costs[0] = new int[2] { 10, 20 };
            costs[1] = new int[2] { 30, 200 };
            costs[2] = new int[2] { 400, 50 };
            costs[3] = new int[2] { 30, 20 };

            Console.WriteLine(TwoCitySchedCost(costs));
            Console.ReadLine();
        }

        /// <summary>
        /// We arrived at below logic with this reason -
        /// To find the optimal cost to send people to 2 cities,
        /// first send all people to city A or B (depending on which will cost higher)
        /// In given eg. say sending all of them to A costs 470.. now we should eliminate 
        ///  2 ppl, because we can only send 2 of them to A and other 2 to B as per the
        ///  problem stmt. So, we eliminate that person whose cost is higher, so that total
        ///  cost of A is reduced. Going by this, we remove P3 who has 400 cost to A and
        ///  and send him to B. We calculate the profits we get for each person, if they are
        ///  sent to B. So, this can be achieved by, A-B for each person, so we get, -10, 170,
        ///  350, and 10. Max profit is achieved by sending P3 and P4. This can be achieved
        ///  by sorting the given array on custom condition of (A-B) for each person 
        ///  and sending first half to A and second half to B.
        /// </summary>
        public static int TwoCitySchedCost(int[][] costs)
        {
            int cost = 0;
            List<List<int>> costList = new List<List<int>>();
            for(int i = 0; i < costs.Length; i++)
            {
                costList.Add(new List<int>());
                for(int j = 0; j < costs[i].Length; j++)
                {
                    costList[i].Add(costs[i][j]);
                }
            }

            costList.Sort((a, b) => (a[0] - a[1]).CompareTo(b[0] - b[1]));

            for (int i = 0; i < costList.Count / 2; i++)
                cost += costList[i].Count > 0?costList[i][0]:0;
            for (int i = costList.Count / 2; i < costList.Count; i++)
                cost += costList[i].Count > 1 ? costList[i][1]:0;

            return cost;
        }
    }
}
