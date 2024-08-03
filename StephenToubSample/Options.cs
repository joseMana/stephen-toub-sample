//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using Microsoft.Extensions.Primitives;

//namespace OptionsMonitorExample
//{
//    public class MySettings
//    {
//        public string Option1 { get; set; }
//        public int Option2 { get; set; }
//    }

//    public class SettingsConsumer
//    {
//        private readonly IDisposable _listener;
//        private MySettings _settings;

//        public SettingsConsumer(IOptionsMonitor<MySettings> optionsMonitor)
//        {
//            _settings = optionsMonitor.CurrentValue;
//            _listener = optionsMonitor.OnChange(OnSettingsChanged);
//        }

//        public void DisplaySettings()
//        {
//            Console.WriteLine($"Option1: {_settings.Option1}, Option2: {_settings.Option2}");
//        }

//        private void OnSettingsChanged(MySettings newSettings)
//        {
//            Console.WriteLine("Settings changed!");
//            _settings = newSettings;
//            DisplaySettings();
//        }

//        public void Dispose()
//        {
//            _listener.Dispose();
//        }
//    }

//    public class CustomOptionsChangeTokenSource : IOptionsChangeTokenSource<MySettings>
//    {
//        private Action _triggerChangeAction;
//        public string Name => Options.DefaultName;

//        public IChangeToken GetChangeToken()
//        {
//            throw new NotImplementedException();
//        }

//        public IDisposable OnChange(Action changeCallback)
//        {
//            _triggerChangeAction = changeCallback;
//            return new ChangeTokenDisposable(() => _triggerChangeAction = null);
//        }

//        public void TriggerChange()
//        {
//            _triggerChangeAction?.Invoke();
//        }

//        private class ChangeTokenDisposable : IDisposable
//        {
//            private readonly Action _disposeAction;
//            public ChangeTokenDisposable(Action disposeAction) => _disposeAction = disposeAction;
//            public void Dispose() => _disposeAction();
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Set up dependency injection
//            var services = new ServiceCollection();
//            ConfigureServices(services);

//            // Build the service provider
//            var serviceProvider = services.BuildServiceProvider();

//            // Resolve and use the SettingsConsumer
//            var consumer = serviceProvider.GetRequiredService<SettingsConsumer>();
//            consumer.DisplaySettings();

//            // Simulate changing configuration
//            var changeTokenSource = serviceProvider.GetRequiredService<CustomOptionsChangeTokenSource>();
//            changeTokenSource.TriggerChange();

//            Console.ReadLine();
//        }

//        private static void ConfigureServices(IServiceCollection services)
//        {
//            // Configure options
//            services.Configure<MySettings>(options =>
//            {
//                options.Option1 = "Initial value";
//                options.Option2 = 42;
//            });

//            // Add options monitor and consumer
//            services.AddOptions<MySettings>();
//            services.AddSingleton<SettingsConsumer>();
//            services.AddSingleton<CustomOptionsChangeTokenSource>();
//            services.AddSingleton<IOptionsChangeTokenSource<MySettings>>(provider => provider.GetRequiredService<CustomOptionsChangeTokenSource>());
//        }
//    }
//}
