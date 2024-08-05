//using System;
//using System.Security.Principal;
//using System.Threading;

//namespace CustomPrincipalDemo
//{
//    public class CustomIdentity : IIdentity
//    {
//        public CustomIdentity(string name, string authenticationType, bool isAuthenticated)
//        {
//            Name = name;
//            AuthenticationType = authenticationType;
//            IsAuthenticated = isAuthenticated;
//        }

//        public string Name { get; private set; }

//        public string AuthenticationType { get; private set; }

//        public bool IsAuthenticated { get; private set; }
//    }

//    public class CustomPrincipal : IPrincipal
//    {
//        public CustomPrincipal(CustomIdentity identity)
//        {
//            Identity = identity;
//        }

//        public IIdentity Identity { get; private set; }

//        public bool IsInRole(string role)
//        {
//            // Implement role-based authorization logic here
//            return role == "Admin"; // Example: only users in "Admin" role
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Simulate authentication in the main thread
//            Console.WriteLine("Simulating authentication in the main thread...");
//            var mainThreadIdentity = new CustomIdentity("john.doe", "CustomAuth", true);
//            var mainThreadPrincipal = new CustomPrincipal(mainThreadIdentity);

//            // Set the principal to the current thread
//            // Every thread has a principal object
//            // The principal object is used to determine the current user's identity and roles
//            // What is important is that the principal object is used by the authorization logic 
//            //to determine if the user is allowed to perform a certain action
//            Thread.CurrentPrincipal = mainThreadPrincipal;

//            // Investigate the IPrincipal object in the main thread
//            InvestigatePrincipal(Thread.CurrentPrincipal);

//            // Simulate authorization in the main thread
//            Console.WriteLine("\nSimulating authorization in the main thread...");
//            if (Thread.CurrentPrincipal.IsInRole("Admin"))
//            {
//                Console.WriteLine("User is in the Admin role.");
//            }
//            else
//            {
//                Console.WriteLine("User is not in the Admin role.");
//            }

//            // Simulate a different principal in a new thread
//            var newThread = new Thread(() =>
//            {
//                Console.WriteLine("\nSimulating IPrincipal in a new thread...");
//                var currentThreadPrincipal = Thread.CurrentPrincipal;

//                // Investigate the IPrincipal object in the new thread
//                InvestigatePrincipal(currentThreadPrincipal);
//            });

//            newThread.Start();
//            newThread.Join();

//            Console.ReadLine();
//        }

//        static void InvestigatePrincipal(IPrincipal principal)
//        {
//            Console.WriteLine("\nInvestigating IPrincipal object...");
//            Console.WriteLine($"Identity Name: {principal.Identity.Name}");
//            Console.WriteLine($"Authentication Type: {principal.Identity.AuthenticationType}");
//            Console.WriteLine($"Is Authenticated: {principal.Identity.IsAuthenticated}");
//        }
//    }
//}
