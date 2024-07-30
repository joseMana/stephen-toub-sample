
//class BathroomStall
//{
//    public void BeUsed(int id)
//    {
//        for (int i = 0; i < 5; i++)
//        {
//            Console.WriteLine($"Being used by {id}");
//            Thread.Sleep(500);
//        }
//    }
//}

//public class MainClass
//{
//    static BathroomStall stall = new BathroomStall();
//    private static object lockObj = new object();
//    static void Main(string[] args)
//    {
//        for (int i = 1; i < 3; i++)
//            new Thread(RegularUsers).Start();

//        new Thread(TheWeirdGuy).Start();

//        Console.ReadLine();
//    }

//    static void RegularUsers()
//    {
//        lock (lockObj)
//            stall.BeUsed(Thread.CurrentThread.ManagedThreadId);
//    }

//    static void TheWeirdGuy()
//    {
//        stall.BeUsed(99);
//    }
//}