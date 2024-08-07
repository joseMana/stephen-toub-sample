﻿//using System.Reactive.Linq;
//using System.Reactive.Subjects;

//public static class ObservableExtensions
//{
//    public static IObservable<TResult> Pipe<TSource, TResult>(this IObservable<TSource> source, params Func<IObservable<TSource>, IObservable<TResult>>[] operators)
//    {
//        IObservable<TResult> result = null;
//        foreach (var op in operators)
//        {
//            result = op(source);
//        }
//        return result;
//    }

//    public static IObservable<TResult> Map<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector)
//    {
//        return source.Select(selector);
//    }

//    public static IObservable<TResult> MergeMap<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
//    {
//        return source.SelectMany(selector);
//    }
//    public static IObservable<TResult> SwitchMap<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
//    {
//        return source.Select(selector).Switch();
//    }
//}

//public class Program
//{
//    static async Task Main(string[] args)
//    {
//        var switchMapKeypress = new Subject<string>();
//        var switchMapOutput = switchMapKeypress.Pipe(
//            src => src.Map(eventData => eventData),
//            src => src.SwitchMap(value => MockHttpRequest(value, "switchMap"))
//        );

//        switchMapOutput.Subscribe(result => Console.WriteLine("SwitchMap Result: {result}"));

//        switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750); switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750); switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750); switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750); switchMapKeypress.OnNext("test3");
//        await Task.Delay(750);
//        switchMapKeypress.OnNext("test4");
//        await Task.Delay(750);
//        Console.ReadLine();
//    }

//    public static IObservable<string> MockHttpRequest(string value, string type)
//    {
//        return Observable.Create<string>(observer =>
//        {
//            Task.Run(async () =>
//            {
//                await Task.Delay(1000); // Simulate network delay
//                observer.OnNext("{type} Processed value: {value}");
//                observer.OnCompleted();
//            });

//            return System.Reactive.Disposables.Disposable.Empty;
//        });
//    }
//}
