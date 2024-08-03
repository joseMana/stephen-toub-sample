//using Polly;
//using Polly.CircuitBreaker;
//using Polly.Retry;
//using System.Net;

//public class ProgramPolly1
//{
//    public static async Task Main(String[] args)
//    {
//        // Circuit breaker with default options.
//        // See https://www.pollydocs.org/strategies/circuit-breaker#defaults for defaults.
//        var optionsDefaults = new CircuitBreakerStrategyOptions();

//        // Circuit breaker with customized options:
//        // The circuit will break if more than 50% of actions result in handled exceptions,
//        // within any 10-second sampling duration, and at least 8 actions are processed.
//        var optionsComplex = new CircuitBreakerStrategyOptions
//        {
//            FailureRatio = 0.5,
//            SamplingDuration = TimeSpan.FromSeconds(10),
//            MinimumThroughput = 8,
//            BreakDuration = TimeSpan.FromSeconds(30),
//            ShouldHandle = new PredicateBuilder().Handle<SomeExceptionType>()
//        };

//        // Circuit breaker using BreakDurationGenerator:
//        // The break duration is dynamically determined based on the properties of BreakDurationGeneratorArguments.
//        var optionsBreakDurationGenerator = new CircuitBreakerStrategyOptions
//        {
//            FailureRatio = 0.5,
//            SamplingDuration = TimeSpan.FromSeconds(10),
//            MinimumThroughput = 8,
//            BreakDurationGenerator = static args => new ValueTask<TimeSpan>(TimeSpan.FromMinutes(args.FailureCount)),
//        };

//        // Handle specific failed results for HttpResponseMessage:
//        var optionsShouldHandle = new CircuitBreakerStrategyOptions<HttpResponseMessage>
//        {
//            ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
//                .Handle<SomeExceptionType>()
//                .HandleResult(response => response.StatusCode == HttpStatusCode.InternalServerError)
//        };

//        // Monitor the circuit state, useful for health reporting:
//        var stateProvider = new CircuitBreakerStateProvider();
//        var optionsStateProvider = new CircuitBreakerStrategyOptions<HttpResponseMessage>
//        {
//            StateProvider = stateProvider
//        };

//        var circuitState = stateProvider.CircuitState;

//        /*
//        CircuitState.Closed - Normal operation; actions are executed.
//        CircuitState.Open - Circuit is open; actions are blocked.
//        CircuitState.HalfOpen - Recovery state after break duration expires; actions are permitted.
//        CircuitState.Isolated - Circuit is manually held open; actions are blocked.
//        */

//        // Manually control the Circuit Breaker state:
//        var manualControl = new CircuitBreakerManualControl();
//        var optionsManualControl = new CircuitBreakerStrategyOptions
//        {
//            ManualControl = manualControl
//        };

//        // Manually isolate a circuit, e.g., to isolate a downstream service.
//        await manualControl.IsolateAsync();

//        // Manually close the circuit to allow actions to be executed again.
//        await manualControl.CloseAsync();

//        // Add a circuit breaker strategy with a CircuitBreakerStrategyOptions{<TResult>} instance to the pipeline
//        new ResiliencePipelineBuilder().AddCircuitBreaker(optionsDefaults);
//        new ResiliencePipelineBuilder<HttpResponseMessage>().AddCircuitBreaker(optionsStateProvider);
//    }
//}