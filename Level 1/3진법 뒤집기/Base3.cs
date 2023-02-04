using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int n) 
    {
        int answer = 0;
        double answer_ = 0;
        
        List<int> list = new List<int>();
        
        if(n>=3)
        {
             while(true)
            {
                list.Add(n%3);
                n = n/3;

                if(n<3)
                {
                    //list.Add(n%3);
                    //list.Add(n/3);
                    list.Add(n);
                    break;
                }
            }
        }
        else
        {
            list.Add(n);
        }
       
        
        int count = list.Count;
        
        for(int i = 0; i < count; i++)
        {
            answer_ += list[i] * Math.Pow(3, (count-1)-i);
        }
        
        answer = (int)answer_;
        
        return answer;
    }
}