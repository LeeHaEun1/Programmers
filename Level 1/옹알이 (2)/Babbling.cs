using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(string[] babbling) 
    {
        int answer = 0;
        
        
        // [1. "aya", "ye", "woo", "ma"를 "1", "2", "3", "4"로 치환(Replace)]
        for(int i = 0; i < babbling.Length; i++)
        {
            babbling[i] = babbling[i].Replace("aya", "1");
            babbling[i] = babbling[i].Replace("ye", "2");
            babbling[i] = babbling[i].Replace("woo", "3");
            babbling[i] = babbling[i].Replace("ma", "4");
        }
              
        
        // [2. 발음 불가 단어 제거]
        // (1) 알파벳(a~z) 한 개 이상 포함한 것
        // (2) (1)에서 제외하고 남은 것 중 "11", "22", "33", "44" 포함 한 것
        string az = "abcdefghijklmnopqrstuvwxyz";
        string[] azArray = new string[26];
        for(int i = 0; i < az.Length; i++)
        {
            azArray[i] = az.Substring(i, 1);
        }
        
        // (1)이 아닌 것들 남기기
        // *** 알파벳 중 하나가 아니라, 알파벳 전체를 포함하지 않아야 함!
        List<string> first = new List<string>();
        int[] count = new int[babbling.Length];
        for(int i = 0; i < babbling.Length; i++)
        {
            for(int j = 0; j < azArray.Length; j++)
            {             
                if(!babbling[i].Contains(azArray[j]))
                {
                    // first.Add(babbling[i]);
                    count[i]++;
                }
            }
            if(count[i] == 26)
            {
                first.Add(babbling[i]);
            }
        }
                
        // (1) & (2) 모두 아닌 것들 남기기
        string[] doubleArray = new string[4]{"11", "22", "33", "44"};
        List<string> second = new List<string>();
        int[] count2 = new int[first.Count];
        for(int i = 0; i < first.Count; i++)
        {
            for(int j = 0; j < doubleArray.Length; j++)
            {
                if(!first[i].Contains(doubleArray[j]))
                {
                    // second.Add(first[i]);                    
                    count2[i]++;
                }
            }
            if(count2[i] == 4)
            {
                second.Add(first[i]); 
            }
        }        
        
        
        // [3. 남은 단어 개수 Count]
        answer = second.Count;
        

        return answer;
    }
}