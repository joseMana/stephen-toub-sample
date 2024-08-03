//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;

//namespace JwtExplanationDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string secretKey = "mysupersecret_secretkey!1234567890"; // Ensure the key is at least 32 characters long

//            // Generate JWT token
//            var token = GenerateJwtToken(secretKey);
//            Console.WriteLine($"This is the token -> {token}");
//            Console.WriteLine("It consists of 3 parts separated by dots:");
//            Console.WriteLine("1. Header");
//            Console.WriteLine("2. Payload");
//            Console.WriteLine("3. Signature");

//            // Split the token into its parts
//            var tokenParts = token.Split('.');
//            Console.WriteLine("\nHeader:");
//            string header = DecodeBase64Url(tokenParts[0]);
//            Console.WriteLine(header);

//            Console.WriteLine("\nPayload:");
//            string payload = DecodeBase64Url(tokenParts[1]);
//            Console.WriteLine(payload);

//            Console.WriteLine("\nSignature:");
//            string signature = tokenParts[2];
//            Console.WriteLine(signature);

//            Console.WriteLine("\nExplanation:");
//            Console.WriteLine("1. Header: Contains metadata about the token, such as the signing algorithm.");
//            Console.WriteLine("2. Payload: Contains the claims, which are statements about an entity (typically, the user) and additional data.");
//            Console.WriteLine("3. Signature: Used to verify that the token was not altered and was signed by the sender.");

//            // Investigate Header
//            Console.WriteLine("\nLet's try and investigate this header:");
//            InvestigateHeader(header);

//            // Investigate Payload
//            Console.WriteLine("\nLet's try and investigate this payload:");
//            InvestigatePayload(payload);

//            // Investigate Signature
//            Console.WriteLine("\nLet's try and investigate this signature:");
//            InvestigateSignature(tokenParts[0], tokenParts[1], signature, secretKey);
//        }

//        static string GenerateJwtToken(string secretKey)
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

//        static string DecodeBase64Url(string base64Url)
//        {
//            string base64 = base64Url.Replace('-', '+').Replace('_', '/');
//            switch (base64.Length % 4)
//            {
//                case 2: base64 += "=="; break;
//                case 3: base64 += "="; break;
//            }
//            var byteArray = Convert.FromBase64String(base64);
//            return Encoding.UTF8.GetString(byteArray);
//        }

//        static void InvestigateHeader(string header)
//        {
//            Console.WriteLine("The header is a JSON object that contains metadata about the token.");
//            Console.WriteLine("Typical fields include 'alg' (algorithm) and 'typ' (type).");

//            var headerJson = System.Text.Json.JsonDocument.Parse(header).RootElement;
//            foreach (var property in headerJson.EnumerateObject())
//            {
//                Console.WriteLine($"{property.Name}: {property.Value}");
//            }
//        }

//        static void InvestigatePayload(string payload)
//        {
//            Console.WriteLine("The payload is a JSON object that contains the claims.");
//            Console.WriteLine("Claims are statements about an entity (typically, the user) and additional data.");

//            var payloadJson = System.Text.Json.JsonDocument.Parse(payload).RootElement;
//            foreach (var property in payloadJson.EnumerateObject())
//            {
//                Console.WriteLine($"{property.Name}: {property.Value}");
//            }
//        }

//        static void InvestigateSignature(string header, string payload, string signature, string secretKey)
//        {
//            Console.WriteLine("The signature is used to verify that the token was not altered and was signed by the sender.");

//            // Explain how the signature is generated
//            Console.WriteLine("The signature is generated by encoding the header and payload, then signing them using the secret key and the specified algorithm.");
//            Console.WriteLine("Here's a simplified version of how the signature is created:");

//            // Create the string to sign (header + "." + payload)
//            string stringToSign = $"{header}.{payload}";
//            Console.WriteLine($"String to sign: {stringToSign}");

//            // Generate the signature using HMACSHA256
//            var encoding = new UTF8Encoding();
//            byte[] keyBytes = encoding.GetBytes(secretKey);
//            byte[] messageBytes = encoding.GetBytes(stringToSign);
//            using (var hmacsha256 = new HMACSHA256(keyBytes))
//            {
//                byte[] hashMessage = hmacsha256.ComputeHash(messageBytes);
//                string generatedSignature = Base64UrlEncode(hashMessage);
//                Console.WriteLine($"Generated signature: {generatedSignature}");

//                // Compare the generated signature with the signature from the token
//                Console.WriteLine($"Original signature: {signature}");
//                if (generatedSignature == signature)
//                {
//                    Console.WriteLine("The signature is valid.");
//                }
//                else
//                {
//                    Console.WriteLine("The signature is invalid.");
//                }
//            }
//        }

//        static string Base64UrlEncode(byte[] input)
//        {
//            var output = Convert.ToBase64String(input);
//            output = output.Split('=')[0]; // Remove padding characters
//            output = output.Replace('+', '-'); // Replace '+' with '-'
//            output = output.Replace('/', '_'); // Replace '/' with '_'
//            return output;
//        }
//    }
//}
