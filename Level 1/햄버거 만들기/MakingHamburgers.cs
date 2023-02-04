using System;
using System.Linq;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int[] ingredient) 
    {
        int answer = 0;

        Stack<int> stack = new Stack<int>();

        foreach(int i in ingredient)
        {
            stack.Push(i);

            if (stack.Count >= 4)
            {
                answer += Cook(stack);
            }
        }

        return answer;
    }
    
    public int Cook(Stack<int> stck)
    {
        int stck4 = stck.Peek(); stck.Pop();
        int stck3 = stck.Peek(); stck.Pop();
        int stck2 = stck.Peek(); stck.Pop();
        int stck1 = stck.Peek(); stck.Pop();

        if(stck4 == 1 && stck3 == 3 && stck2 == 2 && stck1 == 1)
        {
            return 1;
        }
        else
        {
            stck.Push(stck1);
            stck.Push(stck2);
            stck.Push(stck3);
            stck.Push(stck4);
            return 0;
        }
    }
}