using System;

public class Solution 
{
    public int[] solution(int[] lottos, int[] win_nums) 
    {
        int[] answer = new int[2];
        
        int count = 0;
        int zeroCount = 0;
        
        // (1) 동일 숫자 개수 count
        for(int i = 0; i < lottos.Length; i++)
        {
            for(int j = 0; j < win_nums.Length; j++)
            {
                if(lottos[i] == win_nums[j])
                {
                   count++;
                }
            }
        }
        
        // (2) 0(알아볼 수 없는 숫자) 개수
        for(int i = 0; i < lottos.Length; i++)
        {
           if(lottos[i] == 0)
            {
                zeroCount++;
            }
        }
        
        // (3) 실제 순위 == 최저 순위
        if(count >= 2)
        {
            answer[1] = 7 - count;
        }
        else
        {
            answer[1] = 6;
        }
        
        // (4) 최고 순위 가정 
        if(count + zeroCount >= 2)
        {
            answer[0] = 7 - (count + zeroCount);
        }
        else
        {
            answer[0] = 6;
        }
            
        return answer;
    }
}