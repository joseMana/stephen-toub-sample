//using System;
//using System.Collections.Generic;

//namespace YieldExperiment
//{
//    class Program
//    {
//        // Iterator method that yields even numbers up to a specified limit
//        private static IEnumerable<int> GenerateEvenNumbers(int limit)
//        {
//            for (int i = 0; i <= limit; i++)
//            {
//                // Yielding only even numbers
//                if (i % 2 == 0)
//                {
//                    yield return i;
//                }
//            }
//        }
//        static void Main(string[] args)
//        {
//            // Using the iterator method to generate a sequence of even numbers
//            foreach (var number in GenerateEvenNumbers(10))
//            {
//                Console.WriteLine(number);
//            }
//        }
//    }
//}









/* DECOMPILED */
// YieldExperiment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// YieldExperiment.Program
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Runtime.CompilerServices;

//internal class Program
//{
//    [CompilerGenerated]
//    private sealed class generateEventNumbersIterator : IEnumerable<int>, IEnumerable, IEnumerator<int>, IDisposable, IEnumerator
//    {
//        private int state;

//        private int current;

//        private int initialThreadId;

//        private int limit;

//        public int limit2;

//        private int index;

//        int IEnumerator<int>.Current
//        {
//            //[DebuggerHidden]
//            get
//            {
//                return current;
//            }
//        }

//        object IEnumerator.Current
//        {
//            //[DebuggerHidden]
//            get
//            {
//                return current;
//            }
//        }

//        ////[DebuggerHidden]
//        public generateEventNumbersIterator(int state)
//        {
//            this.state = state;
//            initialThreadId = Environment.CurrentManagedThreadId;
//        }

//        ////[DebuggerHidden]
//        void IDisposable.Dispose()
//        {
//        }

//        private bool MoveNext()
//        {
//            int num = state;
//            if (num != 0)
//            {
//                if (num != 1)
//                {
//                    return false;
//                }
//                state = -1;
//                goto IL_0057;
//            }
//            state = -1;
//            index = 0;
//            goto IL_0068;
//        IL_0057:
//            index++;
//            goto IL_0068;
//        IL_0068:
//            if (index <= limit)
//            {
//                if (index % 2 == 0)
//                {
//                    current = index;
//                    state = 1;
//                    return true;
//                }
//                goto IL_0057;
//            }
//            return false;
//        }

//        bool IEnumerator.MoveNext()
//        {
//            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
//            return this.MoveNext();
//        }

//        //[DebuggerHidden]
//        void IEnumerator.Reset()
//        {
//            throw new NotSupportedException();
//        }

//        //[DebuggerHidden]
//        IEnumerator<int> IEnumerable<int>.GetEnumerator()
//        {
//            generateEventNumbersIterator d;
//            if (state == -2 && initialThreadId == Environment.CurrentManagedThreadId)
//            {
//                state = 0;
//                d = this;
//            }
//            else
//            {
//                d = new generateEventNumbersIterator(0);
//            }
//            d.limit = limit2;
//            return d;
//        }

//        //[DebuggerHidden]
//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return ((IEnumerable<int>)this).GetEnumerator();
//        }
//    }

//    [IteratorStateMachine(typeof(generateEventNumbersIterator))]
//    private static IEnumerable<int> GenerateEvenNumbers(int limit)
//    {
//        generateEventNumbersIterator d = new generateEventNumbersIterator(-2);
//        d.limit2 = limit;
//        return d;
//    }

//    private static void Main(string[] args)
//    {
//        foreach (int number in GenerateEvenNumbers(10))
//        {
//            Console.WriteLine(number);
//        }
//    }
//}
