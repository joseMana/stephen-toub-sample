//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Collections.Specialized;
//using System.Web;

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        using (var listener = new System.Net.HttpListener())
//        {
//            listener.Prefixes.Add("https://www.facebook.com/");
//            listener.Start();
//            //access is denied - Only LOCALHOST is allowed in HttpListener

//            var context = await listener.GetContextAsync();
//            var query = context.Request.QueryString;

//            var response = context.Response;
//            string responseString = "<html><body>Authorization code received. You can close this window.</body></html>";
//            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
//            response.ContentLength64 = buffer.Length;
//            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
//            response.OutputStream.Close();

//            listener.Stop();
//        }
//    }
//}
