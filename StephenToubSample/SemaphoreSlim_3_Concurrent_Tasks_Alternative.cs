//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//public class Program
//{
//    private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(3); // Limit to 3 concurrent tasks
//    private static int _currentConcurrentTasks = 0;
//    private static readonly object Lock = new object();

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
//            lock (Lock)
//            {
//                _currentConcurrentTasks++;
//                Console.WriteLine($"Task {taskNum} started. Concurrent tasks: {_currentConcurrentTasks}");
//            }

//            await Task.Delay(1000); // Simulate work

//            lock (Lock)
//            {
//                Console.WriteLine($"Task {taskNum} completed. Concurrent tasks: {_currentConcurrentTasks}");
//                _currentConcurrentTasks--;
//            }
//        }
//        finally
//        {
//            Semaphore.Release();
//        }
//    }
//}
