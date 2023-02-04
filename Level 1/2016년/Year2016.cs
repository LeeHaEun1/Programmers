public class Solution 
{
    public string solution(int a, int b) 
    {
        // 1월 31일
        // 2월 29일 ** (-1)
        // 3월 31일
        // 4월 30일
        // 5월 31일
        // 6월 30일
        // 7월 31일
        // 8월 31일 ** (+1) 
        // 9월 30일
        // 10월 31일
        // 11월 30일
        // 12월 31일
        
        //string answer = "";
        string[] answer = {"THU","FRI","SAT","SUN","MON","TUE","WED"};
        
        int remainder = 0; 
        int days = 0;
        
        // [1] 홀수월
        if(a%2 == 1)
        {
            if(a > 8)
            {
                days += ((31+30) * ((a-1)/2)) + b;
                remainder = days % 7;
            }
            else if(a > 2)
            {
                days += ((31+30) * ((a-1)/2)) - 1 + b;
                remainder = days % 7;
            }
            else
            {
                remainder = b % 7;
            }
        }
        
        // [2] 짝수월
        if(a%2 == 0)
        {
            if(a > 2)
            {
                days += 31*(a/2) + 30*(a/2-1) - 1 + b;
                remainder = days % 7;
            }
            else
            {
                days += 31 + b;
                remainder = days % 7;
            }
        }
        
        return answer[remainder];
    }
}