using static System.Console;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace Packt.Shared
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        private bool disposedValue;

        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
            //if your logger uses unmanaged resources, you can release the memory here


        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ConsoleLoggerProvider()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    public class ConsoleLogger : ILogger
    {
        //if your logger uses unmanaged resources, you can return the class that implements IDisposable here
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            //to avoid overlogging, you cna filter on the log level
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            }
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (eventId.Id == 20100)
            {
                //log the level and event identifier
                Write($"Level: {logLevel}, Event ID: {eventId.Id}");
                //only output the state or exception if it exists
                if (state != null)
                {
                    Write($", State: {state}");
                }
                if (exception != null)
                {
                    Write($", Exception: {exception.Message}");
                }
                WriteLine();

            }
        }
    }
}
