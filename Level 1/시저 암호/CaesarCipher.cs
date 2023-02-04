using System;


public class Solution 
{
    public string solution(string s, int n) 
    {
        string answer = "";
        
        // (1) 대문자 소문자 배열 선언
        //string[] Upper = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        //string[] Lower = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
        string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string lower = "abcdefghijklmnopqrstuvwxyz";
        
        // (2) s의 문자들을 배열에 추가
        int length = s.Length;
        string[] array = new string[length];
        for(int i = 0; i < length; i++)
        {
            array[i] = s.Substring(i, 1);      
        }
            
        // (3) 변환
        for(int i = 0; i < length; i++)
        {
            if(upper.IndexOf(array[i]) != -1)
            {
                //array[i] = upper[(upper.IndexOf(array[i]) + n) % 26];
                array[i] = upper.Substring((upper.IndexOf(array[i]) + n) % 26, 1);
            }
            else if(lower.IndexOf(array[i]) != -1)
            {
                //array[i] = lower[(lower.IndexOf(array[i]) + n) % 26];
                array[i] = lower.Substring((lower.IndexOf(array[i]) + n) % 26, 1);
            }
            else
            {
                array[i] = " ";
            }
        }
        
        answer = string.Join("", array);
        
        return answer;
    }
}