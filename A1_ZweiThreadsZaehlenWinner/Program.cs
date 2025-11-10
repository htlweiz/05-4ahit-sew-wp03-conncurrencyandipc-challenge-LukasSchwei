using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
   
    
    public static void Main(string[] args)
    {
        new Thread(CountUpThreadA).Start();
        new Thread(CountDownThreadB).Start();
    }
    
    private static void CountUpThreadA()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine($"Thread 1: {i}");
            Thread.Sleep(100);
        }
    }
    
    private static void CountDownThreadB()
    {
       for (int i = 100; i >= 1; i--)
        {
            Console.WriteLine($"Thread 2: {i}");
            Thread.Sleep(100);
        }
    }
}
