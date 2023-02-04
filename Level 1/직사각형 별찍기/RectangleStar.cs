using System;

public class Example
{
    //static int a;
    //static int b;
    
    public static void Main()
    {
        String[] s;

        Console.Clear();
        s = Console.ReadLine().Split(' ');

        int a = Int32.Parse(s[0]);
        int b = Int32.Parse(s[1]);

        //Console.WriteLine("{0}", a + b);
        
        string stars = "";
        for(int j = 0; j < b; j++)
        {
            for(int i = 0; i < a; i++)
            {
                stars += "*";
            }
            stars += "\n";
        }
        Console.WriteLine(stars);
    }       
}
