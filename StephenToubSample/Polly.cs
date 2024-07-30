using Polly;
using Polly.Retry;

public class ProgramPolly
{
    public static async Task Main(String[] args)
    {
        ResiliencePipeline pipeline = new ResiliencePipelineBuilder()
            .AddRetry(new RetryStrategyOptions()) 
            .AddTimeout(TimeSpan.FromSeconds(10)) 
            .Build();

        var cts = new CancellationTokenSource();

        await pipeline.ExecuteAsync(async token =>
        {
            await Task.Delay(1000, token);
            Console.WriteLine("Hello World!");
        }, cts.Token);
    }
}