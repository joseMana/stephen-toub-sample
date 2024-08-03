//using Polly;
//using Polly.Retry;

//public class ProgramPolly1
//{
//    public static async Task Main(String[] args)
//    {
//        ResiliencePipeline pipeline = new ResiliencePipelineBuilder()
//            .AddRetry(new RetryStrategyOptions
//            {
//                MaxRetryAttempts = 10
//            }) 
//            .AddTimeout(TimeSpan.FromSeconds(10)) 
//            .Build();

//        var cts = new CancellationTokenSource();

//        await pipeline.ExecuteAsync(async token =>
//        {
//            await Task.Delay(1000, token);
//            Console.WriteLine("Trying...");

//            var client = new HttpClient();
//            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/access/Authenticate");
//            var content = new StringContent(
//                "{\"Email\":\"joseph.m.manangan@gmail.com\",\"Password\":\"P@ssword1234\"}", 
//                null, 
//                "application/json");
//            request.Content = content;
//            var response = await client.SendAsync(request);
//            response.EnsureSuccessStatusCode();
//            Console.WriteLine(await response.Content.ReadAsStringAsync());
//        }, cts.Token);


//        Console.ReadLine();
//    }
//}