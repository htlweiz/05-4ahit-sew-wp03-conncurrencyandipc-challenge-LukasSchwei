using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{

    static int valueA = 0;
    static int valueB = 0;
    public static void Main(string[] args)
    {
        Thread thread1 = new Thread(() => CountUpThreadA());
        Thread thread2 = new Thread(() => CountDownThreadB());
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();

        if (valueA > 50)
            Console.WriteLine($"Win for Count up with {valueA}");
        else if (valueA < 50)
            Console.WriteLine($"Win for Count down with {valueA}");
        else
            Console.WriteLine("Draw");
    }

    private static void CountUpThreadA()
    {
        for (int i = 1; i <= 100; i++)
        {
            valueA = i;
            Thread.Sleep(100);
            if (valueA == valueB)
            {
                Console.WriteLine(valueA + " " + valueB);
                return;
            }
        }
    }

    private static void CountDownThreadB()
    {
        for (int i = 100; i >= 1; i--)
        {
            valueB = i;
            Thread.Sleep(100);
            if (valueA == valueB)
            {
                Console.WriteLine(valueA + " " + valueB);
                return;
            }
        }
    }
}
