//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//public class Program
//{
//    private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(3); // Limit to 3 concurrent tasks

//    public static async Task Main(string[] args)
//    {
//        List<Task> tasks = new List<Task>();
//        for (int i = 0; i < 10; i++)
//        {
//            int taskNum = i;
//            tasks.Add(RunTaskAsync(taskNum));
//        }

//        await Task.WhenAll(tasks);
//        Console.WriteLine("All tasks completed.");
//    }

//    private static async Task RunTaskAsync(int taskNum)
//    {
//        await Semaphore.WaitAsync();
//        try
//        {
//            Console.WriteLine($"Task {taskNum} started.");
//            await Task.Delay(1000); // Simulate work
//            Console.WriteLine($"Task {taskNum} completed.");
//        }
//        finally
//        {
//            Semaphore.Release();
//        }
//    }
//}
