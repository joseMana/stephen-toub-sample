//using System.Runtime.CompilerServices;

//namespace StephenToubSample
//{
//    internal class ProgramCSharp1
//    {
//        [CompilerGenerated]
//        private sealed class displayClass
//        {
//            public int i;

//            internal void main(object p)
//            {
//                Console.WriteLine(i);
//                Thread.Sleep(1000);
//            }
//        }
//        private static void Main(string[] args)
//        {
//            displayClass displayClass = new displayClass();
//            displayClass.i = 0;

//            while (displayClass.i < 1000)
//            {
//                ThreadPool.QueueUserWorkItem(new WaitCallback(displayClass.main));
//                displayClass.i++;
//            }

//            Console.ReadLine();
//        }
//    }
//}
