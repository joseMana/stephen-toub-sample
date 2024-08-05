//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Collections.Specialized;
//using System.Web;

//class Program
//{
//    private static readonly string clientId = "your_client_id";
//    private static readonly string clientSecret = "your_client_secret";
//    private static readonly string authorizationEndpoint = "https://github.com/login/oauth/authorize";
//    private static readonly string tokenEndpoint = "https://github.com/login/oauth/access_token";
//    private static readonly string redirectUri = "http://localhost:12345/";
//    private static readonly string userInfoEndpoint = "https://api.github.com/user";

//    static async Task Main(string[] args)
//    {
//        string authorizationCode = await GetAuthorizationCode();
//        string accessToken = await GetAccessToken(authorizationCode);
//        await GetUserInformation(accessToken);
//    }

//    private static async Task<string> GetAuthorizationCode()
//    {
//        string authorizationRequest = $"{authorizationEndpoint}?client_id={clientId}&redirect_uri={Uri.EscapeDataString(redirectUri)}&scope=read:user&response_type=code";

//        Console.WriteLine("Open the following URL in a browser and enter the code from the redirect URL:");
//        Console.WriteLine(authorizationRequest);

//        // Simple local HTTP listener to capture the authorization code
//        using (var listener = new System.Net.HttpListener())
//        {
//            listener.Prefixes.Add(redirectUri);
//            listener.Start();

//            var context = await listener.GetContextAsync();
//            var query = context.Request.QueryString;

//            var response = context.Response;
//            string responseString = "<html><body>Authorization code received. You can close this window.</body></html>";
//            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
//            response.ContentLength64 = buffer.Length;
//            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
//            response.OutputStream.Close();

//            listener.Stop();

//            return query["code"];
//        }
//    }

//    private static async Task<string> GetAccessToken(string authorizationCode)
//    {
//        var client = new HttpClient();

//        var tokenRequestParams = new NameValueCollection
//        {
//            { "client_id", clientId },
//            { "client_secret", clientSecret },
//            { "code", authorizationCode },
//            { "redirect_uri", redirectUri }
//        };

//        var tokenRequestContent = new FormUrlEncodedContent(new[]
//        {
//            new KeyValuePair<string, string>("client_id", clientId),
//            new KeyValuePair<string, string>("client_secret", clientSecret),
//            new KeyValuePair<string, string>("code", authorizationCode),
//            new KeyValuePair<string, string>("redirect_uri", redirectUri),
//        });

//        var tokenResponse = await client.PostAsync(tokenEndpoint, tokenRequestContent);
//        var responseContent = await tokenResponse.Content.ReadAsStringAsync();
//        var queryParams = HttpUtility.ParseQueryString(responseContent);

//        return queryParams["access_token"];
//    }

//    private static async Task GetUserInformation(string accessToken)
//    {
//        var client = new HttpClient();
//        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("CSharpApp", "1.0"));

//        var response = await client.GetAsync(userInfoEndpoint);
//        var content = await response.Content.ReadAsStringAsync();

//        Console.WriteLine("User Information:");
//        Console.WriteLine(content);
//    }
//}
