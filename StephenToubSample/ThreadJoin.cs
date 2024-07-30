

//public class ThreadJoinLearning
//{
//    public static void Main(String[] args)
//    {
//        var thread1 = new Thread(async () =>
//        {
//            await Task.Delay(3000);
//            Console.WriteLine("Thread 1");
//        });
//        var thread2 = new Thread(async () =>
//        {
//            await Task.Delay(5000);
//            Console.WriteLine("Thread 2");
//        });
//        var thread3 = new Thread(() =>
//        {
//            Thread.Sleep(8000);
//            Console.WriteLine("Thread 3");
//        });
//        var thread4 = new Thread(() =>
//        {
//            DateTime startTime = DateTime.Now;
//            int mySum = 0;
//            while ((DateTime.Now - startTime).Seconds < 8) { }
//            Console.WriteLine("Thread 4");
//        });

//        thread1.Start();
//        thread2.Start();
//        thread3.Start();
//        thread4.Start();

//        Console.WriteLine("Calling Join on Thread 1");
//        thread1.Join();

//        Console.WriteLine("Calling Join on Thread 2");
//        thread2.Join();

//        Console.WriteLine("Calling Join on Thread 3");
//        thread3.Join();

//        Console.WriteLine("Calling Join on Thread 4");
//        thread4.Join();

//    }
//}