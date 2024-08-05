using System;
using System.Threading;
using System.Threading.Tasks;

public class MyObservable<T>
{
    private Func<CancellationToken, Task<T>> _taskFactory;

    public MyObservable(Func<CancellationToken, Task<T>> taskFactory)
    {
        _taskFactory = taskFactory;
    }

    public async Task SubscribeAsync(Func<T, Task> onNext, CancellationToken cancellationToken)
    {
        T result = await _taskFactory(cancellationToken);
        if (!cancellationToken.IsCancellationRequested)
        {
            await onNext(result);
        }
    }
}
public static class ObservableExtensions
{
    public static MyObservable<U> SwitchMap<T, U>(this MyObservable<T> source, Func<T, MyObservable<U>> selector)
    {
        return new MyObservable<U>(async cancellationToken =>
        {
            T latestSourceValue = default;
            MyObservable<U> latestObservable = null;
            TaskCompletionSource<U> tcs = new TaskCompletionSource<U>();

            await source.SubscribeAsync(async value =>
            {
                latestSourceValue = value;
                latestObservable = selector(value);

                if (cancellationToken.IsCancellationRequested)
                {
                    tcs.SetCanceled();
                }
                else
                {
                    await latestObservable.SubscribeAsync(result =>
                    {
                        tcs.SetResult(result);
                        return Task.CompletedTask;
                    }, cancellationToken);
                }

            }, cancellationToken);

            return await tcs.Task;
        });
    }

    public static MyObservable<U> MergeMap<T, U>(this MyObservable<T> source, Func<T, MyObservable<U>> selector)
    {
        return new MyObservable<U>(async cancellationToken =>
        {
            var tcs = new TaskCompletionSource<U>();

            await source.SubscribeAsync(async value =>
            {
                var innerObservable = selector(value);

                await innerObservable.SubscribeAsync(result =>
                {
                    tcs.SetResult(result);
                    return Task.CompletedTask;
                }, cancellationToken);

            }, cancellationToken);

            return await tcs.Task;
        });
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();

        var observable1 = new MyObservable<int>(async token =>
        {
            await Task.Delay(1000); // Simulate async work
            return 1;
        });

        var observable2 = new MyObservable<string>(async token =>
        {
            await Task.Delay(500); // Simulate async work
            return "Result after switchMap";
        });

        var observable3 = new MyObservable<string>(async token =>
        {
            await Task.Delay(300); // Simulate async work
            return "Result after mergeMap";
        });

        var switchedObservable = observable1.SwitchMap(value =>
        {
            Console.WriteLine($"Source emitted (SwitchMap): {value}");
            return observable2;
        });

        var mergedObservable = observable1.MergeMap(value =>
        {
            Console.WriteLine($"Source emitted (MergeMap): {value}");
            return observable3;
        });

        await switchedObservable.SubscribeAsync(result =>
        {
            Console.WriteLine($"Switched Observable emitted: {result}");
            return Task.CompletedTask;
        }, cts.Token);

        await mergedObservable.SubscribeAsync(result =>
        {
            Console.WriteLine($"Merged Observable emitted: {result}");
            return Task.CompletedTask;
        }, cts.Token);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        cts.Cancel();
    }
}

