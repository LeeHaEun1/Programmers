using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public string solution(string[] survey, int[] choices) 
    {
        string answer = "";
        
        
        // 유형별 점수 담는 다차원 배열
        int[,] table = new int[4, 2];
        
        
        // Dictionary 정의(key, value)
        var match = new Dictionary<string, int[]>();
        match.Add("R", new int[]{0, 0});
        match.Add("T", new int[]{0, 1});
        match.Add("C", new int[]{1, 0});
        match.Add("F", new int[]{1, 1});
        match.Add("J", new int[]{2, 0});
        match.Add("M", new int[]{2, 1});
        match.Add("A", new int[]{3, 0});
        match.Add("N", new int[]{3, 1});
              
        
        // (1) choices 점수 case에 따른 table 점수 부여
        for(int i = 0; i < choices.Length; i++)
        {
            //if(choices[i] <= 3)
            if(choices[i] < 4)
            {                               
                if(match.TryGetValue(survey[i].Substring(0, 1), out int[] idx))
                {
                    //Console.WriteLine(idx); // 출력값: System.Int32[]
                    //Console.WriteLine(string.Join(",", idx)); // 1, 0
                    
                    //Console.WriteLine("3점 이하"+table[idx[0], idx[1]]);
                    // test
                    Console.WriteLine("3점 이하 "+idx[0]+" "+idx[1]);
                                        
                    table[idx[0], idx[1]] += (4-choices[i]);
                }
            }
            //else if(choices[i] >= 5)
            else if(choices[i] > 4)
            {
                if(match.TryGetValue(survey[i].Substring(1, 1), out int[] idx))
                {
                    //Console.WriteLine("5점 이상"+table[idx[0], idx[1]]);
                    // test
                    Console.WriteLine("5점 이상 "+idx[0]+" "+idx[1]);
                    
                    table[idx[0], idx[1]] += (choices[i]-4);
                }
            }
            
        }
        
        
        // (2) table의 모든 행에 대해 열끼리 비교해 우위 타입 산정
        string[] superior = new string[4];
        for(int i = 0; i < 4; i++)
        {
            // table[i, 0] 해당 타입
            if(table[i, 0] >= table[i, 1])
            {
                superior[i] = match.FirstOrDefault(x => x.Value[0] == i && x.Value[1] == 0).Key;
                
                // test
                Console.WriteLine("first sup "+match.FirstOrDefault(x => x.Value[0] == i && x.Value[1] == 0).Key);
            }
            // table[i, 1] 해당 타입
            else
            {
                superior[i] = match.FirstOrDefault(x => x.Value[0] == i && x.Value[1] == 1).Key;
                
                // test
                Console.WriteLine("second sup "+match.FirstOrDefault(x => x.Value[0] == i && x.Value[1] == 1).Key);
            }
        }
        
        
        // (3) answer 반환
        for(int i = 0; i < 4; i++)
        {
            answer += superior[i];
        }        
        //answer = superior[0]+superior[1]+superior[2]+superior[3];
        
        
        // Test
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                Console.WriteLine(match.FirstOrDefault(x => x.Value[0] == i && x.Value[1] == j).Key+" "+i+" "+j+" "+table[i, j]);
            }
        }
                   
                       
        return answer;
    }
}