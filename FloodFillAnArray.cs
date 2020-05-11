using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFill
{
    class FloodFillAnArray
    {
        static void Main(string[] args)
        {
            int[][] jArray = new int[3][];
            jArray[0] = new int[3] { 1, 1, 1 };
            jArray[1] = new int[3] { 1, 1, 0 };
            jArray[2] = new int[3] { 1, 0, 1 };

            jArray = FloodFill(jArray, 1, 1, 2);

            for(int i = 0; i < jArray.Length; i++)
            {
                int[] insideArray = jArray[i];
                for(int j = 0; j < insideArray.Length; j++)
                {
                    Console.Write(insideArray[j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int color = image[sr][sc];
            if (color != newColor)
                DFSAndFillPositionsWihColor(image, sr, sc, color, newColor);
            return image;
        }

        public static void DFSAndFillPositionsWihColor(int[][] image, int row, int col, int color, int newColor)
        {
            if(image[row][col] == color)
            {
                image[row][col] = newColor;
                if (row >= 1)
                    DFSAndFillPositionsWihColor(image, row - 1, col, color, newColor);
                if (col >= 1)
                    DFSAndFillPositionsWihColor(image, row, col - 1, color, newColor);
                if (row + 1 < image.Length)
                    DFSAndFillPositionsWihColor(image, row + 1, col, color, newColor);
                if (col + 1 < image[0].Length)
                    DFSAndFillPositionsWihColor(image, row, col + 1, color, newColor);
            }
        }
    }
}
