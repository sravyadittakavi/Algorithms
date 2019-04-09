using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var output = ThreeSum(nums);
            foreach(var list in output)
            {
                Console.WriteLine(string.Join(",", list));
            }
            Console.ReadKey();
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < nums.Length-2; i++)
            {
                for(int j = i + 1; j < nums.Length-1; j++)
                {
                    for(int k = j + 1; k < nums.Length; k++)
                    {
                        if(nums[i]+nums[j]+nums[k] == 0)
                        {
                            IList<int> match = new List<int>();
                            match.Add(nums[i]);
                            match.Add(nums[j]);
                            match.Add(nums[k]);

                            if (result.Count == 0)
                            {
                                result.Add(match);
                            }
                            else
                            {
                                int exceptCounter = 0;
                                foreach (var li in result)
                                {
                                    if (!match.Except(li).Any())
                                    {
                                        exceptCounter++;
                                    }
                                }
                                if(exceptCounter == 0)
                                {
                                    result.Add(match);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
