//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics.Metrics;
//using System.Linq;

//namespace LINQExample
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Sample data for Visits
//            List<Visit> visits = new List<Visit>
//            {
//                new Visit { VisitId = 1, CustomerId = 23 },
//                new Visit { VisitId = 2, CustomerId = 9 },
//                new Visit { VisitId = 4, CustomerId = 30 },
//                new Visit { VisitId = 5, CustomerId = 54 },
//                new Visit { VisitId = 6, CustomerId = 96 },
//                new Visit { VisitId = 7, CustomerId = 54 },
//                new Visit { VisitId = 8, CustomerId = 54 },
//            };

//            // Sample data for Transactions
//            List<Transaction> transactions = new List<Transaction>
//            {
//                new Transaction { TransactionId = 2, VisitId = 5, Amount = 310 },
//                new Transaction { TransactionId = 3, VisitId = 5, Amount = 300 },
//                new Transaction { TransactionId = 9, VisitId = 5, Amount = 200 },
//                new Transaction { TransactionId = 12, VisitId = 1, Amount = 910 },
//                new Transaction { TransactionId = 13, VisitId = 2, Amount = 970 },
//            };
//            var result = visits
//                .GroupJoin(
//                    transactions,
//                    visit => visit.VisitId,
//                    transaction => transaction.VisitId,
//                    (visit, transGroup) => new { visit, transGroup }
//                )
//                .SelectMany(
//                    x => x.transGroup.DefaultIfEmpty(),
//                    (x, subTransaction) => new { x.visit.CustomerId, subTransaction }
//                );

//            foreach (var item in result)
//            {
//                Console.WriteLine(item);
//            }

//                /*returns IEnumerable<TResult> 
//                Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, 
//                IEnumerable<TInner> inner, 
//                Func<TOuter, TKey> outerKeySelector, 
//                Func<TInner, TKey> innerKeySelector, 
//                Func<TOuter, TInner, TResult> resultSelector);
//                */
//            // Output the results
//            Console.WriteLine("CustomerId, CountNoTrans");
//        }

//    }
//    public class Visit
//    {
//        public int VisitId { get; set; }
//        public int CustomerId { get; set; }
//    }

//    public class Transaction
//    {
//        public int TransactionId { get; set; }
//        public int VisitId { get; set; }
//        public decimal Amount { get; set; }
//    }

//}
