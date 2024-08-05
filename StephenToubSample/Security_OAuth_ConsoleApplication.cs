//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;

//namespace AuthenticationExample
//{
//    // Abstract base class
//    abstract class AuthenticationType
//    {
//        // Abstract method for authenticating a user
//        public abstract bool Authenticate(string username, string password);
//    }

//    // JWT Authentication
//    class JWT : AuthenticationType
//    {
//        private string secretKey = "my_secret_key"; // Secret key for signing the JWT

//        public override bool Authenticate(string username, string password)
//        {
//            Console.WriteLine("Step 1: Validate username and password.");
//            // Simulate user validation (in reality, you'd query the database)
//            if (username == "jwtUser" && password == "jwtPassword")
//            {
//                Console.WriteLine("Step 2: Generate JWT token.");
//                string token = GenerateJWT(username);
//                Console.WriteLine($"Generated Token: {token}");
//                Console.WriteLine("Step 3: Send token to the client.");
//                return true;
//            }
//            return false;
//        }

//        private string GenerateJWT(string username)
//        {
//            string header = Convert.ToBase64String(Encoding.UTF8.GetBytes("{\"alg\": \"HS256\", \"typ\": \"JWT\"}"));
//            string payload = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{{\"sub\": \"{username}\", \"exp\": \"{DateTime.UtcNow.AddHours(1).ToString("o")}\"}}"));
//            string signature = CreateSignature(header, payload);
//            return $"{header}.{payload}.{signature}";
//        }

//        private string CreateSignature(string header, string payload)
//        {
//            string message = $"{header}.{payload}";
//            byte[] key = Encoding.UTF8.GetBytes(secretKey);
//            using (var hmac = new HMACSHA256(key))
//            {
//                byte[] signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
//                return Convert.ToBase64String(signatureBytes);
//            }
//        }
//    }

//    // Basic Authentication
//    class BasicAuthentication : AuthenticationType
//    {
//        private Dictionary<string, string> users = new Dictionary<string, string>
//        {
//            { "basicUser", HashPassword("basicPassword") }
//        };

//        public override bool Authenticate(string username, string password)
//        {
//            Console.WriteLine("Step 1: Encode username and password in base64.");
//            string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
//            Console.WriteLine($"Encoded Credentials: {encodedCredentials}");

//            Console.WriteLine("Step 2: Decode credentials and verify.");
//            string decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
//            string[] splitCredentials = decodedCredentials.Split(':');

//            if (splitCredentials.Length == 2 && VerifyPassword(splitCredentials[0], splitCredentials[1]))
//            {
//                Console.WriteLine("Step 3: Credentials are verified.");
//                return true;
//            }

//            return false;
//        }

//        private static string HashPassword(string password)
//        {
//            using (var sha256 = SHA256.Create())
//            {
//                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
//                StringBuilder builder = new StringBuilder();
//                foreach (byte b in bytes)
//                {
//                    builder.Append(b.ToString("x2"));
//                }
//                return builder.ToString();
//            }
//        }

//        private bool VerifyPassword(string username, string password)
//        {
//            if (users.ContainsKey(username))
//            {
//                string hashedPassword = HashPassword(password);
//                return users[username] == hashedPassword;
//            }
//            return false;
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Create instances of different authentication types
//            AuthenticationType jwtAuth = new JWT();
//            AuthenticationType basicAuth = new BasicAuthentication();

//            // Authenticate using different methods
//            Console.WriteLine("JWT Authentication:");
//            jwtAuth.Authenticate("jwtUser", "jwtPassword");

//            Console.WriteLine("\nBasic Authentication:");
//            basicAuth.Authenticate("basicUser", "basicPassword");

//            Console.ReadLine();
//        }
//    }
//}
