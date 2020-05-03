class Solution {
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix) {
        List<int> dim = binaryMatrix.Dimensions().ToList();

        int rows = dim[0], columns = dim[1];
        int x = 0, y = columns-1;
        
        if(rows == 0 || columns == 0)
            return -1;
        int result = -1;
        
        while(x < rows && y >=0){
            int val = binaryMatrix.Get(x,y);
            if(val == 1){
                result = y;
                y--;
            }
            else
                x++;
        }
        return result;
    }
}