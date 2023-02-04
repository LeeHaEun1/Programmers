using System;
using System.Linq;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(string[] id_list, string[] report, int k) 
    {
        int[] answer = new int[id_list.Length];
        
        // (1) report 배열의 원소 중복 제거
        string[] report_distinct = report.Distinct().ToArray();
        
        
        // (2) report_distinct의 원소들을 공백을 기준으로 자르고, 각 원소의 자른 뒤 [0], [1]을 담는 다차원 배열 table 생성
        string[,] table = new string[report_distinct.Length,2];
        
        for(int i = 0; i < report_distinct.Length; i++)
        {
            if(report_distinct[i].Contains(" "))
            {
                string[] split = report_distinct[i].Split(" ");
                table[i,0] = split[0];
                table[i,1] = split[1];
            }
            else
            {
                table[i,0] = report_distinct[i];
                table[i,1] = "no_report";
            }
        }
        
        
        // (3) table[i,1]에 대해 중복을 제거한 배열 생성(신고 한 번 이상 당한 유저들 목록)
        string[] reported = new string[report_distinct.Length];
        for(int i = 0; i < report_distinct.Length; i++)
        {
            reported[i] = table[i,1];
        }
        string[] reportedNet = reported.Distinct().ToArray();
        
        
        // (4) reportedNet의 원소들에 대해 reported에 k개 이상 포함된 유저(=정지 대상)들 추출 (단, table[i,1] == "no_report"일 경우 집계하지 않음)
        List<string> reportedK = new List<string>();
        int[] reportedNum = new int[reportedNet.Length];
        
        for(int i = 0; i < reportedNet.Length; i++)
        {
            for(int j = 0; j < reported.Length; j++)
            {
                if(reportedNet[i] == reported[j] && reportedNet[i] != "no_report")
                {
                    reportedNum[i]++;
                }
            }
        }
        for(int i = 0; i < reportedNet.Length; i++)
        {
            if(reportedNum[i] >= k)
            {
                reportedK.Add(reportedNet[i]);
            }
        }
        
        
        // (5) table 2열의 원소가 reportedK의 원소라면 3열에 +1
        int[] suspended = new int[report_distinct.Length];
        for(int i = 0; i < reportedK.Count; i++)
        {
            for(int j = 0; j < report_distinct.Length; j++)
            {
                if(reportedK[i] == table[j, 1])
                {
                    suspended[j]++;
                }
            }
        }
        
        
        // (6) id_list에 대하여 table의 1열 매칭 및 suspended 집계
        for(int i = 0; i < id_list.Length; i++)
        {
            for(int j = 0; j < report_distinct.Length; j++)
            {
                if(id_list[i] == table[j,0])
                {
                    answer[i] += suspended[j];
                }
            }
        }
                        
        return answer;
    }
}
