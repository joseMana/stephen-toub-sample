//using System.Security.Cryptography;
//public class AntiForgeryToken
//{
//    public string Token { get; private set; }
//    public DateTime Expiry { get; private set; }

//    public AntiForgeryToken()
//    {
//        Token = GenerateToken();
//        Expiry = DateTime.Now.AddMinutes(30); // Token expires in 30 minutes
//    }

//    private string GenerateToken()
//    {
//        using (var rng = new RNGCryptoServiceProvider())
//        {
//            var data = new byte[32];
//            rng.GetBytes(data);
//            return Convert.ToBase64String(data);
//        }
//    }

//    public bool IsExpired()
//    {
//        return DateTime.Now > Expiry;
//    }
//}
//public class WebApp
//{
//    private Dictionary<string, AntiForgeryToken> sessionTokens = new Dictionary<string, AntiForgeryToken>();

//    public string GenerateAntiForgeryTokenForSession(string sessionId)
//    {
//        var antiForgeryToken = new AntiForgeryToken();
//        sessionTokens[sessionId] = antiForgeryToken;
//        return antiForgeryToken.Token;
//    }

//    public bool ValidateAntiForgeryToken(string sessionId, string antiForgeryToken)
//    {
//        if (sessionTokens.ContainsKey(sessionId))
//        {
//            var storedToken = sessionTokens[sessionId];
//            if (storedToken.Token == antiForgeryToken && !storedToken.IsExpired())
//            {
//                return true;
//            }
//        }
//        return false;
//    }
//}
//public class SomeOtherSite
//{
//    private WebApp webApp;

//    public SomeOtherSite(WebApp app)
//    {
//        webApp = app;
//    }

//    public void RequestSomething(string sessionId, string antiForgeryToken)
//    {
//        if (webApp.ValidateAntiForgeryToken(sessionId, antiForgeryToken))
//        {
//            Console.WriteLine("Request validated and processed.");
//        }
//        else
//        {
//            Console.WriteLine("Invalid or expired anti-forgery token.");
//        }
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        // Simulate session ID
//        string sessionId = "user123";

//        // Initialize WebApp and generate anti-forgery token for the session
//        WebApp webApp = new WebApp();
//        string antiForgeryToken = webApp.GenerateAntiForgeryTokenForSession(sessionId);

//        Console.WriteLine($"Generated Anti-Forgery Token: {antiForgeryToken}");

//        // Simulate another site trying to make a request
//        SomeOtherSite someOtherSite = new SomeOtherSite(webApp);

//        // Simulate valid request
//        Console.WriteLine("Simulating valid request...");
//        someOtherSite.RequestSomething(sessionId, antiForgeryToken);

//        // Simulate invalid request
//        Console.WriteLine("Simulating invalid request...");
//        someOtherSite.RequestSomething(sessionId, "invalid_token");
//    }
//}

