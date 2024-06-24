using Serilog.Events;
using Serilog;

namespace LibraryWebApi.Services
{
    public static class ConfigureLogger
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
             .WriteTo.File("LibraryWebAppLog-.txt", rollingInterval:
             RollingInterval.Day)
             .CreateLogger();
        }
    }
}
