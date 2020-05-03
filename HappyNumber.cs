public class Solution {
    public bool IsHappy(int n) {
        List<int> values = new List<int>();
        while(1){
            n = SumOfSquaresOfDigits(n);
            if(n == 1)
                return true;
            if(values.Contains(n))
                return false;
            values.Add(n);
        }
    }

    public int SumOfSquaresOfDigits(int number){
        int sum = 0;
        while(number != 0){
            sum+= (number%10)*(number%10);
            n=n/10;
        }
        return sum;
    }
}