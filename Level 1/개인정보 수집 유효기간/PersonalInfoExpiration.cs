using System;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(string today, string[] terms, string[] privacies) 
    {
        int[] answer = new int[] {};
                
        // [1] privacies의 정보 분할
        // [1-1] 날짜와 약관 종류 분할
        string[] p_dates = new string[privacies.Length];
        string[] p_terms = new string[privacies.Length];
        for(int i = 0; i < privacies.Length; i++)
        {
            p_dates[i] = privacies[i].Split(" ")[0];
            p_terms[i] = privacies[i].Split(" ")[1];
        }
        // [1-2] 날짜의 년/월/일 분할
        // Console.WriteLine(int.Parse("07")); // 출력: 7
        int[] years = new int[p_dates.Length];
        int[] months = new int[p_dates.Length];
        int[] days = new int[p_dates.Length];
        for(int i = 0; i < p_dates.Length; i++)
        {
            years[i] = int.Parse(p_dates[i].Split(".")[0]);
            months[i] = int.Parse(p_dates[i].Split(".")[1]);
            days[i] = int.Parse(p_dates[i].Split(".")[2]);
        }
        
        
        // [2] terms의 정보를 Dictionary 형태로 변환
        var dict = new Dictionary<string, int>();
        for(int i = 0; i < terms.Length; i++)
        {
            dict.Add(terms[i].Split(" ")[0], int.Parse(terms[i].Split(" ")[1]));
        }
        
        
        // [3] 만료일자 산정
        int[] exp_days = new int[days.Length];
        int[] exp_months = new int[months.Length];
        int[] temp_months = new int[months.Length];
        int[] exp_years = new int[years.Length];
        for(int i = 0; i < days.Length; i++)
        {
            // [3-1] day에 따른 만료일자와 temp_month 계산법의 차이 (1일 vs 나머지)
            if(days[i] == 1)
            {
                exp_days[i] = 28;                
                temp_months[i] = months[i] + dict[p_terms[i]] - 1;                
            }
            else
            {
                exp_days[i] = days[i] - 1;                
                temp_months[i] = months[i] + dict[p_terms[i]];                
            }
            
            // [3-2] temp_month에 따른 만료 월, 년 계산법 차이 (>12 vs <=12)
            if(temp_months[i] > 12)
            {
                // [3-3] temp_month에 따른 만료 월, 년 계산법 차이 (12의 배수 vs 나머지)
                if(temp_months[i] % 12 != 0)
                {
                    exp_years[i] = years[i] + (temp_months[i]/12);
                    exp_months[i] = temp_months[i]%12;
                }
                else
                {
                    exp_years[i] = years[i] + (temp_months[i]/12) - 1;
                    exp_months[i] = 12;
                }
            }
            else
            {
                exp_months[i] = temp_months[i];
                exp_years[i] = years[i];
            }
        }
        
        
        // [4] today와 만료일자 비교 (년-월-일 순으로 비교)
        List<int> temp_answer = new List<int>();
        for(int i = 0; i < exp_years.Length; i++)
        {
            // [4-1] 년도가 지난 경우
            if(int.Parse(today.Split(".")[0]) > exp_years[i])
            {
                temp_answer.Add(i+1);
                Console.WriteLine("Y "+(i+1));
            }            
            else if(int.Parse(today.Split(".")[0]) == exp_years[i])
            {
                // [4-2] 년도는 같은데 월이 지난 경우
                if(int.Parse(today.Split(".")[1]) > exp_months[i])
                {
                    temp_answer.Add(i+1);
                    Console.WriteLine("M "+(i+1));
                }
                else if(int.Parse(today.Split(".")[1]) == exp_months[i])
                {
                    // [4-2] 월은 같은데 일자가 지난 경우
                    if(int.Parse(today.Split(".")[2]) > exp_days[i])
                    {
                        temp_answer.Add(i+1);
                        Console.WriteLine("D "+(i+1));
                    }
                }
            }
        }
        
        
        // [5] List의 값들을 배열에 담기
        // System.IndexOutOfRangeException
        // for(int i = 0; i < temp_answer.Count; i++)
        // {
        //     answer[i] = temp_answer[i];
        // }
        answer = temp_answer.ToArray();
        Array.Sort(answer);
        
        return answer;
    }
}
