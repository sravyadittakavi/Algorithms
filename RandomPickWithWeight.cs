using System;

public class Solution
{
    int[] cumWeights;
    int sum;
    public Solution(int[] w)
    {
        cumWeights = new int[w.Length];
        sum = 0;
        for (int i = 0; i < w.Length; i++)
        {
            sum += w[i];
            cumWeights[i] = sum;
        }
    }

    public int PickIndex()
    {
        Random r = new Random();
        int rand = r.Next(sum);
        return BinarySearch(rand + 1);
    }

    public int BinarySearch(int val)
    {
        int low = 0, high = cumWeights.Length - 1;
        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (cumWeights[mid] < val)
                low = mid + 1;
            else
                high = mid;
        }
        return low;
    }
}
