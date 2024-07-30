//namespace StephenToubSample
//{
//    internal class ProgramFixedCSharp1
//    {
//        private sealed class DisplayClass
//        {
//            public int i;

//            internal void Main(object p)
//            {
//                Console.WriteLine(i);
//                Thread.Sleep(1000);
//            }
//        }
//        private static void Main(string[] args)
//        {
//            for (int i = 0; i < 1000; i++)
//            {
//                DisplayClass displayC = new DisplayClass();
//                displayC.i = i;

//                ThreadPool.QueueUserWorkItem(new WaitCallback(displayC.Main));
//            }

//            Console.WriteLine("Exiting Main");

//            Console.ReadLine();
//        }
//    }
//}
