//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;

//namespace JwtDisadvantagesDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string secretKey = "mysupersecret_secretkey!1234567890"; // Ensure the key is at least 32 characters long

//            var authServer = new AuthServer(secretKey);
//            var token = authServer.GenerateJwtToken();
//            Console.WriteLine("Generated JWT:");
//            Console.WriteLine(token);
//            Console.WriteLine();

//            var resource = new ProtectedResource(secretKey);
//            resource.AccessResource(token);

//            // Demonstrate potential issues
//            DemonstrateTokenSizeIssue();
//            DemonstrateLackOfRevocationIssue(authServer, token);
//            DemonstrateMisuseIssue(secretKey);
//        }

//        static void DemonstrateTokenSizeIssue()
//        {
//            Console.WriteLine("\nDemonstrating Token Size Issue:");
//            string longClaimValue = new string('x', 1000); // Simulating a large claim
//            var claims = new List<Claim> { new Claim("LargeClaim", longClaimValue) };
//            var token = GenerateJwtTokenWithClaims(claims);
//            Console.WriteLine("JWT with large claim:");
//            Console.WriteLine(token);
//        }

//        static void DemonstrateLackOfRevocationIssue(AuthServer authServer, string token)
//        {
//            Console.WriteLine("\nDemonstrating Lack of Revocation Issue:");
//            // Simulate user logout
//            Console.WriteLine("Simulating user logout. Token should be invalidated, but it will still be valid.");
//            var resource = new ProtectedResource(authServer.SecretKey);
//            resource.AccessResource(token);
//        }

//        static void DemonstrateMisuseIssue(string secretKey)
//        {
//            Console.WriteLine("\nDemonstrating Misuse Issue:");
//            Console.WriteLine("If the secret key is compromised, all tokens can be forged. Demonstrating by forging a token.");

//            var forgedToken = GenerateJwtToken(secretKey);
//            Console.WriteLine("Forged JWT:");
//            Console.WriteLine(forgedToken);

//            var resource = new ProtectedResource(secretKey);
//            resource.AccessResource(forgedToken);
//        }

//        static string GenerateJwtTokenWithClaims(List<Claim> claims)
//        {
//            var secretKey = "mysupersecret_secretkey!1234567890"; // Ensure the key is at least 32 characters long
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                issuer: "yourdomain.com",
//                audience: "yourdomain.com",
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(30),
//                signingCredentials: credentials);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        public static string GenerateJwtToken(string secretKey)
//        {
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, "1234567890"),
//                new Claim(JwtRegisteredClaimNames.Name, "John Doe"),
//                new Claim(JwtRegisteredClaimNames.Email, "john.doe@example.com"),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            var token = new JwtSecurityToken(
//                issuer: "yourdomain.com",
//                audience: "yourdomain.com",
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(30),
//                signingCredentials: credentials);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }

//    public class AuthServer
//    {
//        public string SecretKey { get; }

//        public AuthServer(string secretKey)
//        {
//            SecretKey = secretKey;
//        }

//        public string GenerateJwtToken()
//        {
//            return Program.GenerateJwtToken(SecretKey);
//        }
//    }

//    public class ProtectedResource
//    {
//        private readonly string _secretKey;

//        public ProtectedResource(string secretKey)
//        {
//            _secretKey = secretKey;
//        }

//        public void AccessResource(string token)
//        {
//            var principal = ValidateJwtToken(token, _secretKey);
//            if (principal != null)
//            {
//                Console.WriteLine("Access granted to protected resource. Claims:");
//                foreach (var claim in principal.Claims)
//                {
//                    Console.WriteLine($"{claim.Type}: {claim.Value}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Access denied. Invalid token.");
//            }
//        }

//        private ClaimsPrincipal ValidateJwtToken(string token, string secretKey)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
//            var validationParameters = new TokenValidationParameters
//            {
//                ValidateIssuer = true,
//                ValidateAudience = true,
//                ValidateLifetime = true,
//                ValidateIssuerSigningKey = true,
//                ValidIssuer = "yourdomain.com",
//                ValidAudience = "yourdomain.com",
//                IssuerSigningKey = securityKey
//            };

//            try
//            {
//                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
//                return principal;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Token validation failed: {ex.Message}");
//                return null;
//            }
//        }
//    }
//}
