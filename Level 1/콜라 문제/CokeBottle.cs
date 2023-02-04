using System;

public class Solution 
{
    public int solution(int a, int b, int n) 
    {
        int answer = 0;
        
        int reward = 0;
        int temp = n;
        int remainder = 0;
        int t = 0;
        int r = 0;
        
        while((temp+remainder)>=a)
        {
            // temp = ((temp+remainder)/a)*b;            
            // remainder = (temp+remainder)%a;
            t = ((temp+remainder)/a)*b;            
            r = (temp+remainder)%a;
            
            temp = t;
            remainder = r;
            
            reward += temp;
            
            //test
            Console.WriteLine("temp "+temp);
            Console.WriteLine("remainder "+remainder);
        }        
        
        answer = reward;
        
        return answer;
    }
}