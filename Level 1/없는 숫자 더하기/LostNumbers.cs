using System;

public class Solution 
{
    public int solution(int[] numbers) 
    {
        int answer = -1;
        
        for(int i = 0; i < 10; i++)
        {
            int index = Array.IndexOf(numbers, i);
            
            if(index == -1)
            {
                answer += i;
            }
        }

        answer += 1;
        
        return answer;
    }
}