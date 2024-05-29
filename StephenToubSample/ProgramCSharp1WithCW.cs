//using System.Runtime.CompilerServices;

//namespace StephenToubSample
//{
//    internal class ProgramCSharp1WithCW
//    {
//        [CompilerGenerated]
//        private sealed class displayClass
//        {
//            public int i;

//            internal void main(object p)
//            {
//                Console.WriteLine("Entered main of displayClass");
//                Console.WriteLine("Writing {0}", i);
//                Console.WriteLine(i);
//                Console.WriteLine("Done Writing {0}", i);

//                Console.WriteLine("Sleeping for 1 second");
//                Thread.Sleep(1000);
//                Console.WriteLine("Done Sleeping for 1 second");

//                Console.WriteLine("Exiting main of displayClass");
//            }
//        }
//        private static void Main(string[] args)
//        {
//            Console.WriteLine("Entered Main");

//            Console.WriteLine("Creating displayClass");
//            displayClass displayClass = new displayClass();
//            Console.WriteLine("Created displayClass");

//            Console.WriteLine("Setting displayClass.i to 0");
//            displayClass.i = 0;
//            Console.WriteLine("Done Setting displayClass.i to 0");

//            while (displayClass.i < 1000)
//            {
//                Console.WriteLine("Queueing {0}", displayClass.i);
//                ThreadPool.QueueUserWorkItem(new WaitCallback(displayClass.main));
//                Console.WriteLine("Queued {0}", displayClass.i);

//                Console.WriteLine("Incrementing {0}", displayClass.i);
//                displayClass.i++;
//                Console.WriteLine("Incremented {0}", displayClass.i);
//            }

//            Console.WriteLine("Exiting Main");
//            Console.ReadLine();
//        }
//    }
//}
