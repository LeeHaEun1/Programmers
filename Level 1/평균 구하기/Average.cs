public class Solution 
{
    public double solution(int[] arr) 
    {
        double answer = 0;
        
        int length = arr.Length;

        for(int i = 0; i < length; i++)
        {
            answer += arr[i];
        }
        
        answer = answer/length;
        
        return answer;
    }
}