using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatenningAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            dynamic array = new dynamic[random.Next(3, 10)];
            for (int i = 0; i < array.Length; i++)
            {
                if (random.NextBool())
                {
                    array[i] = new dynamic[random.Next(3, 10)];

                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (random.NextBool())
                        {
                            array[i][j] = random.Next(1, 100);
                        }
                        else
                        {
                            array[i][j] = new int[random.Next(3, 10)];

                            for (int k = 0; k < array[i][j].Length; k++)
                            {
                                array[i][j][k] = random.Next(1000);
                            }
                        }
                    }
                }
                else
                {
                    array[i] = random.Next(1, 100);
                }
            }
            List<int> output = FlattenArray(array, new List<int>());
            Console.WriteLine(string.Join(",", output));
            Console.ReadKey();
        }

        public static List<int> FlattenArray(dynamic array, List<int> output)
        {
            if (array.GetType() == typeof(int))
            {
                output.Add(array);
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].GetType() == typeof(int))
                    {
                        output.Add(array[i]);
                    }
                    else
                    {
                        FlattenArray(array[i], output);
                    }
                }
            }
            return output;
        }
    }

    public static class MyExtensions
    {
        public static bool NextBool(this Random random)
        {
            return random.Next(0, 1) == 0;
        }
    }
}
