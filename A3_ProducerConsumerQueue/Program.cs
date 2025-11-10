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

        List<Producer> producers = new List<Producer>();
        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        for (int i = 0; i < 5; i++)
        {
            Producer p = new Producer(i, queue);
            producers.Add(p);
        }
        Consumer consumer = new Consumer(queue);


        Console.WriteLine("Producer und Consumer gestartet...\n");

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen

        // TODO

        while (queue.Count() < 50)
        {
            Console.WriteLine($"Current queue Count: {queue.Count()}");
            Thread.Sleep(1000);
        }

        foreach (Producer p in producers)
        {
            p.Stop();
        }
        consumer.Stop();
        Console.WriteLine($"Final Count: {queue.Count()}");

        // Alle Producer stoppen


        // Consumer stoppen


    }
}
