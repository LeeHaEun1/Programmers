using System;

public class Solution 
{
    public int solution(int[] absolutes, bool[] signs) 
    {
        int answer = 0;
        
        int length = absolutes.Length;
        
        for(int i = 0; i < length; i++)
        {
            if(signs[i] == true)
            {
                answer += absolutes[i];
            }
            else
            {
                answer -= absolutes[i];
            }
        }
        
        return answer;
    }
}