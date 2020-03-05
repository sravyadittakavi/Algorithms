using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class Program
    {
        public static void Main(string[] args)
        {
            DynamicArray array = new DynamicArray();
            array.AddElement(1);
            array.AddElement(2);
            array.AddElement(3);
            array.AddElement(4);
            array.AddElement(5);
            array.AddElement(6);
            array.AddElement(7);
            array.PrintArray();
            array.AddAt(8, 5);
            array.PrintArray();
            array.RemoveAt(4);
            array.PrintArray();
            Console.ReadKey();
        }
    }

    public class DynamicArray
    {
        private int[] array;
        private int size;
        private int count;

        public DynamicArray()
        {
            array = new int[1];
            size = 1;
            count = 0;
        }

        public void AddElement(int value)
        {
            if(count == size)
            {
                // Grow Array Size
                GrowArraySize();
            }

            array[count] = value;
            count++;
        }

        public void GrowArraySize()
        {
            if(count == size)
            {
                int[] temp = new int[size*2];
                for(int i = 0; i < count; i++)
                {
                    temp[i] = array[i];
                }
                size = size * 2;
                array = temp;
            }
        }

        public void ShrinkArraySize()
        {
            if (count > 0)
            {
                int[] temp = new int[count];
                for (int i = 0; i < count; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
                size = count;
            }
        }

        public void Remove()
        {
            if (count > 0)
            {
                array[count - 1] = 0;
                count--;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < count && count > 0) 
            {
                for (int i = index; i < count-1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[count - 1] = 0;
                count--;
            }
        }

        public void AddAt(int value, int index)
        {
            if (count == size)
            {
                // Grow Array Size
                GrowArraySize();
            }
            if (index < count)
            {
                for(int i=count-1;i >= index; i--)
                {
                    array[i + 1] = array[i];
                }
                array[index] = value;
            }
            else
            {
                array[count] = value;
            }
            count++;
        }

        public void PrintArray()
        {
            for(int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
