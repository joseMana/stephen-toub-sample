//namespace StephenToubSample
//{
//    internal class ProgramFixed
//    {
//        static void Main(string[] args)
//        {
//            for (int i = 0; i < 1000; i++)
//            {
//                var num = i;
//                ThreadPool.QueueUserWorkItem(delegate
//                {
//                    Console.WriteLine(num);
//                    Thread.Sleep(1000);
//                });
//            }

//            Console.ReadLine();
//        }
//    }
//}
