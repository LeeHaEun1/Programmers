using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int solution(int n, int[] lost, int[] reserve) 
    {
        int answer = 0;


        // [1. 여분 가져온 사람이 없는 경우]
        // => 잃어버린 학생 수 만큼 수업을 못들음
        if(reserve.Length == 0)
        {
            answer = n - lost.Length;
        }


        // [2. 잃어버린 사람들은 모두 여분을 가져온 경우(reserve⊃lost)]
        // => 모두 수업을 들을 수 있음
        int count = 0;
        for (int i = 0; i < lost.Length; i++)
        {
            if (Array.IndexOf(reserve, lost[i]) != -1)
            {
                count++;
            }
        }
        if(count == lost.Length)
        {
            answer = n;
        }


        // [3. 1, 2의 상황이 아닌 경우]
        // 여분 있는 사람이 읽어버린 경우 해당 사람을 제외한 reserve, lost의 새로운 배열(또는 리스트) 생성 (selfmatch)
        // 상기 배열에서 reserve에 속한 학생들이 빌려줄 수 있는 배열을 생성 (match)
        // answer = n - (lost.Length - selfmatch - match)

        int selfmatch = 0; // 여분 가져온 사람이 잃어버린 경우
        int match = 0; // 그렇지 않은데 빌려줄 수 있는 경우

        // (1)
        List<int> selfMatch = new List<int>(); // 여분 가져오고 && 잃어버린 사람들 담는 리스트

        for(int i = 0; i < lost.Length; i++)
        {
            for(int j = 0; j < reserve.Length; j++)
            {
                if(lost[i] == reserve[j])
                {
                    selfmatch++;
                    selfMatch.Add(lost[i]);
                }
            }
        }

        // (2)
        List<int> newLost = new List<int>(lost);
        List<int> newReserve = new List<int>(reserve);

        for(int i = 0; i < selfMatch.Count; i++)
        {
            for(int j = 0; j < newLost.Count; j++)
            {
                if(selfMatch[i] == newLost[j])
                {
                    newLost.Remove(newLost[j]);
                }
            }
        }
        for (int i = 0; i < selfMatch.Count; i++)
        {
            for (int j = 0; j < newReserve.Count; j++)
            {
                if (selfMatch[i] == newReserve[j])
                {
                    newReserve.Remove(newReserve[j]);
                }
            }
        }

        // (3)
        List<int> canBorrow = new List<int>();
        for(int i = 0; i < newLost.Count; i++)
        {
            canBorrow.Add(newLost[i] - 1);
            canBorrow.Add(newLost[i] + 1);
        }
        canBorrow = canBorrow.Distinct().ToList();

        for(int i = 0; i < newReserve.Count; i++)
        {
            if(canBorrow.IndexOf(newReserve[i]) != -1)
            {
                match++;
            }
        }
        // 대여 가능한 케이스가 잃어버린 사람 수보다 많은 경우(테스트케이스 1의 경우)
        if (match > newLost.Count)
        {
            match = newLost.Count;
        }
        
        
        // Test
        Console.WriteLine("selfmatch " + selfmatch);
        Console.WriteLine("match " + match);
        
        Console.WriteLine("newLost.Count " + newLost.Count);
        Console.WriteLine("newReserve.Count " + newReserve.Count);

        answer = n - (lost.Length - selfmatch - match);


        return answer;
    }
}