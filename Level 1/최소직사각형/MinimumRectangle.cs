using System;
using System.Linq;

public class Solution 
{
    public int solution(int[,] sizes) 
    {
        int answer = 0;        

        //(1) 배열의 길이(=원소의 개수)와 행의 개수 추출
        int length = sizes.Length; // 2n
        int row = length/2; // n
        
        //(2) 각 행마다 오름차순 정렬
        int temp = 0;        
        for(int i = 0; i < row; i++)
        {
            if(sizes[i,0] > sizes[i,1])
            {
                temp = sizes[i,0];
                sizes[i,0] = sizes[i,1];
                sizes[i,1] = temp;
            }
        }
        
        //(3) 각 열의 원소를 담는 배열 생성
        int[] column1 = new int[row];
        int[] column2 = new int[row];        
        for(int i = 0; i < row; i++)
        {
            column1[i] = sizes[i,0];
            column2[i] = sizes[i,1];
        }
        
        // (4) 각 배열의 최대값 추출 & 정답 계산
        int max1 = column1.Max();
        int max2 = column2.Max();
        answer = max1 * max2;        
        
        return answer;
    }
}