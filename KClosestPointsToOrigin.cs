public class Solution {
    public int[][] KClosest(int[][] points, int K) {
        Dictionary<int[], double> distances = new Dictionary<int[], double>();
        foreach(int[] p in points){
            distances.Add(p, GetDistance(p[0],p[1]));
        }
       
        int[][] result = new int[K][];
        int count = 0;
        foreach(var p in distances.OrderBy(x=>x.Value))
        {
            result[count] = new int[2]{p.Key[0], p.Key[1]};
            count++;
            if(count == K)
                break;
        }
        return result;
    }
    
    // Distance = Sqrt((x2-x1)(x2-x1) + (y2-y1)(y2-y1))
    public double GetDistance(int x1, int y1){
        return Math.Sqrt(Math.Pow(x1,2)+Math.Pow(y1,2));
    }
}