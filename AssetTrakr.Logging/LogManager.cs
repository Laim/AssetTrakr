using Serilog;
namespace AssetTrakr.Logging
{
    public class LogManager
    {

        internal readonly string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Laim", "AssetTrakr", "Logs");

        public LogManager()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Adjust the minimum log level as needed
                .WriteTo.File(Path.Combine(logPath, "app.log"), rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}") // Log to file with daily rolling
                .CreateLogger();
        }

        public static void Information<T>(string message) => Log.ForContext<T>().Information(message);

        public static void Fatal<T>(string message) => Log.ForContext<T>().Fatal(message);

        public static void Error<T>(string message) => Log.ForContext<T>().Error(message);

        /// <summary>
        /// Should only be used in classes that are static where <see cref="Error{T}(string)"/> is not suitable
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="source">class name</param>
        public static void Error(string message, string source) => Log.Error($"[{source}] {message}");

        public static void Debug<T>(string message) => Log.ForContext<T>().Debug(message);
    }
}
