//namespace StephenToubSample
//{
//    internal class ProgramFixedCSharp1WithCW
//    {
//        private sealed class DisplayClass
//        {
//            public int num;

//            internal void Main(object p)
//            {
//                Console.WriteLine("Inside Main of DisplayClass");

//                Console.WriteLine("Writing num");
//                Console.WriteLine(num);
//                Console.WriteLine("Wrote num");

//                Console.WriteLine("Sleeping");
//                Thread.Sleep(1000);
//                Console.WriteLine("Slept");

//                Console.WriteLine("Exiting Main of DisplayClass");
//            }
//        }
//        private static void Main(string[] args)
//        {
//            Console.WriteLine("Entered Main");


//            for (int i = 0; i < 1000; i++)
//            {
//                Console.WriteLine("Entered Loop " + i);

//                Console.WriteLine("Instantiating DisplayClass");
//                DisplayClass displayC = new DisplayClass();
//                Console.WriteLine("Instantiated DisplayClass");

//                Console.WriteLine("Setting num");
//                displayC.num = i;
//                Console.WriteLine("Set num");

//                Console.WriteLine("Queueing WorkItem");
//                ThreadPool.QueueUserWorkItem(new WaitCallback(displayC.Main));
//                Console.WriteLine("Queued WorkItem");
//            }

//            Console.WriteLine("Exiting Main");

//            Console.ReadLine();
//        }
//    }
//}
