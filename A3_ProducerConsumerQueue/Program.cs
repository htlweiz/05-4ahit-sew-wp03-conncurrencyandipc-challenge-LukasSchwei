using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 3: Producer-Consumer");
        Console.WriteLine("==========================================\n");

        Producer[] producers = new Producer[5];
        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        for (int i = 0; i < 5; i++)
        {
            Producer p = new Producer(i, queue);
            producers[i] = p;
        }


        Console.WriteLine("Producer und Consumer gestartet...\n");

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen

        // TODO

        Thread checker = new Thread(() => CheckQueue(queue, producers));
        checker.Start();
        checker.Join();

        foreach (Producer p in producers)
        {
            p.Stop();
        }
        Console.WriteLine($"Final Count: {queue.Count()}");

        // Alle Producer stoppen


        // Consumer stoppen


    }
    
    static void CheckQueue(ConcurrentQueue<int> queue, Producer[] producers)
    {
        while(true)
        {
            if (queue.Count() >= 50)
            {
                return;
            }
        }
    }
}
