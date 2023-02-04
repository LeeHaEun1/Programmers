using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public string solution(string X, string Y) 
    {
        string answer = "";
        

        // [1. (1) 숫자(char)별 개수 담는 딕셔너리 && (2) 숫자별 개수의 Min값 담는 딕셔너리]
        // (1) 숫자(char)별 개수 담는 딕셔너리
        Dictionary<char, int> Xcount = new Dictionary<char, int>();
        Dictionary<char, int> Ycount = new Dictionary<char, int>();
        Dictionary<char, int> minCount = new Dictionary<char, int>();

        char[] numbers = new char[] { '9', '8', '7', '6', '5', '4', '3', '2', '1', '0' };
        for(int i = 0; i < numbers.Length; i++)
        {
            Xcount.Add(numbers[i], 0);
            Ycount.Add(numbers[i], 0);
            minCount.Add(numbers[i], 0);
        }

        foreach(char c in X)
        {
            Xcount[c]++;
        }
        foreach (char c in Y)
        {
            Ycount[c]++;
        }

        // (2) 숫자별 개수의 Min값 담는 딕셔너리
        foreach(char c in numbers)
        {
            minCount[c] = Math.Min(Xcount[c], Ycount[c]);
        }
 

        // [2. 숫자별 min값만큼 이어준 문자열 반환(3 Cases)]
        // (1) 동일 문자가 아예 없는 경우
        // (2) 동일 문자가 0뿐인 경우(0만 2개 이상인 경우도 포함)
        // (3) 0이 아닌 동일 문자 있는 경우
        int count = 0;
        for(int i = 0; i < numbers.Length-1; i++)
        {
            if (minCount[numbers[i]] == 0)
            {
                count++;
            }
        }

        if(count == 9)
        {
            // (1)
            if(minCount['0'] == 0)
            {
                answer = "-1";
            }
            // (2)
            else
            {
                answer = "0";
            }
        }
        // (3)
        else
        {
            foreach (char c in numbers)
            {
                answer += new string(c, minCount[c]); // 552
            }
        }

        
        return answer;
    }
}