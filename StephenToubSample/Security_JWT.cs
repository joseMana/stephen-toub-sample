//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;

//namespace JwtDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string secretKey = "mysupersecret_secretkey!1234567890"; // Ensure the key is at least 32 characters long

//            // Simulate a user requesting a JWT token from the AuthServer
//            var authServer = new AuthServer(secretKey);
//            Console.WriteLine("Requesting JWT from AuthServer...");
//            var token = authServer.GenerateJwtToken();
//            Console.WriteLine("Received JWT:");
//            Console.WriteLine(token);
//            Console.WriteLine();

//            // Simulate accessing a protected resource using the received JWT token
//            var resource = new ProtectedResource(secretKey);
//            Console.WriteLine("Attempting to access protected resource with JWT...");
//            resource.AccessResource(token);
//        }
//    }

//    // This class simulates an authentication server that issues JWT tokens.
//    public class AuthServer
//    {
//        private readonly string _secretKey;

//        public AuthServer(string secretKey)
//        {
//            _secretKey = secretKey;
//        }

//        public string GenerateJwtToken()
//        {
//            // A symmetric security key is used to encrypt and decrypt the JWT token. 
//            // It is essential that the key is kept secret and not shared publicly.
//            // What a SymmetricSecurityKey does is that it uses the same key to sign and validate the token.
//            // This means that the same key is used to create the token and validate it.
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

//            // Signing credentials are created using the security key and the HMAC-SHA256 algorithm.
//            // This ensures the token is signed with a strong algorithm and can be verified later.
//            // To put it simply, the signing credentials are used to sign the token.
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            // Claims are statements about an entity (typically, the user) and additional metadata.
//            // Claims are used to add information to the token, such as the user's name, email, and unique identifier.
//            // The point of claims is to provide information about the user in the token.
//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, "1234567890"),
//                new Claim(JwtRegisteredClaimNames.Name, "John Doe"),
//                new Claim(JwtRegisteredClaimNames.Email, "john.doe@example.com"),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            Console.WriteLine("Creating the token with claims and signing credentials...");

//            // A JwtSecurityToken is created with the specified claims, issuer, audience, expiration, and signing credentials.
//            // This is not the actual token but a representation of the token.
//            // The actual token is created when the WriteToken method is called.
//            var token = new JwtSecurityToken(
//                issuer: "yourdomain.com",
//                audience: "yourdomain.com",
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(30),
//                signingCredentials: credentials);

//            Console.WriteLine("Token created successfully.");
//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }

//    // This class simulates a protected resource that requires a valid JWT token to access.
//    public class ProtectedResource
//    {
//        private readonly string _secretKey;

//        public ProtectedResource(string secretKey)
//        {
//            _secretKey = secretKey;
//        }

//        public void AccessResource(string token)
//        {
//            Console.WriteLine("Validating the provided JWT token...");
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
//                // ValidateIssuer, ValidateAudience, and ValidateLifetime ensure the token was issued by a trusted issuer,
//                // was intended for the right audience, and has not expired.
//                ValidateIssuer = true,
//                ValidateAudience = true,
//                ValidateLifetime = true,
//                // ValidateIssuerSigningKey ensures the token's signature is valid and was created using the specified signing key.
//                ValidateIssuerSigningKey = true,
//                ValidIssuer = "yourdomain.com",
//                ValidAudience = "yourdomain.com",
//                IssuerSigningKey = securityKey
//            };

//            try
//            {
//                Console.WriteLine("Validating the token...");
//                // ValidateToken checks the token against the validation parameters and returns the claims principal if valid.
//                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
//                Console.WriteLine("Token validation successful.");
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
