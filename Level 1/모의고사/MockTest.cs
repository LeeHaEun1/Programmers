using System;
using System.Collections;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(int[] answers) 
    {
        int[] answer = new int[] {};
        
        int length = answers.Length;
        
        int[] student1 = new int[length];
        int[] student2 = new int[length];
        int[] student3 = new int[length];
        
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
                     
        // 수포자1
        for(int i = 0; i < length; i++)
        {
            if(i%5 == 0)
            {
                student1[i] = 1;
            }
            else if(i%5 == 1)
            {
                student1[i] = 2;
            }
            else if(i%5 == 2)
            {
                student1[i] = 3;
            }
            else if(i%5 == 3)
            {
                student1[i] = 4;
            }
            else if(i%5 == 4)
            {
                student1[i] = 5;
            }
        }
        
        // 수포자2
        for(int i = 0; i < length; i++)
        {
            if(i%2 == 0)
            {
                student2[i] = 2;
            }
            else if(i%8 == 1)
            {
                student2[i] = 1;
            }
            else if(i%8 == 3)
            {
                student2[i] = 3;
            }
            else if(i%8 == 5)
            {
                student2[i] = 4;
            }
            else if(i%8 == 7)
            {
                student2[i] = 5;
            }
        }
        
        // 수포자3
        for(int i = 0; i < length; i++)
        {
            if(i%10 == 0 || i%10 == 1)
            {
                student3[i] = 3;
            }
            else if(i%10 == 2 || i%10 == 3)
            {
                student3[i] = 1;
            }
            else if(i%10 == 4 || i%10 == 5)
            {
                student3[i] = 2;
            }
            else if(i%10 == 6 || i%10 == 7)
            {
                student3[i] = 4;
            }
            else if(i%10 == 8 || i%10 == 9)
            {
                student3[i] = 5;
            }            
        }
        
        //비교
        for(int i = 0; i < length; i++)
        {
            if(student1[i] == answers[i])
            {
                count1++;
            }
            if(student2[i] == answers[i])
            {
                count2++;
            }           
            if(student3[i] == answers[i])
            {
                count3++;
            }
        }
        
        //answer에 답 입력
        if(count1>count2 && count1>count3)
        {
            answer = new int[]{1};
        }
        else if(count2>count1 && count2>count3)
        {
            answer = new int[]{2};
        }
        else if(count3>count1 && count3>count2)
        {
            answer = new int[]{3};
        }
        else if(count1==count2 && count1>count3)
        {
            answer = new int[]{1, 2};
        }
        else if(count1==count3 && count1>count2)
        {
            answer = new int[]{1, 3};
        }
        else if(count2==count3 && count2>count1)
        {
            answer = new int[]{2, 3};
        }
        else if(count1==count2 && count2==count3)
        {
            answer = new int[]{1, 2, 3};
        }
   
        return answer;
    }
}