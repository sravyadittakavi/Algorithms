public class Solution {
    public int CountElements(int[] arr) {
        List<int> elements = new List<int>();
        for(int i=0;i<arr.Length;i++){
            if(!elements.Contains(arr[i])){
                elements.Add(arr[i]);
            }
        }
        int counter = 0;
        for(int i=0;i<arr.Length;i++){
            if(elements[i].Contains(arr[i]+1))
                counter++;
        }
        return counter;
    }
}