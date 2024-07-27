

//public class ThreadStateLearning
//{
//    public static void Main(String[] args)
//    {
//        Thread t = new Thread(new ThreadStart(ThreadMethod));
//        t.IsBackground = true;
//        t.Start();

//        for (int i = 0; i < 4; i++)
//        {
//            Console.WriteLine("Main thread: Do some work.");
//            Thread.Sleep(0);
//        }

//        t.Join();
//    }

//    public static void ThreadMethod()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine("ThreadProc: {0}", i);
//            Thread.Sleep(0);
//        }
//    }
//}