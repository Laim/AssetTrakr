using Serilog;
namespace AssetTrakr.Logging
{
    /// <summary>
    /// Static Log Manager that utilises Serilog and writes to <see cref="logPath"/>
    /// </summary>
    public class LogManager
    {

        internal readonly string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Laim", "AssetTrakr", "Logs");

        public LogManager(string fileName = "app.log")
        {

#if DEBUG
            // Manual override in case we're running a debug build to seperate logs
            fileName = $"debug-{fileName}";
#endif

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Adjust the minimum log level as needed
                .WriteTo.File(
                    Path.Combine(logPath, fileName), 
                    rollingInterval: RollingInterval.Day, 
                    outputTemplate: "[{Timestamp:HH:mm:ss.fff zzz} {Level:u3}] [{SourceContext}] {Message}{NewLine}{Exception}") // Log to file with daily rolling
                .CreateLogger();
        }

        public static void Information<T>(string message) => Log.ForContext<T>().Information(message);

        /// <summary>
        /// Modified version of <see cref="Information{T}(string)"/> that can be used on Static Classes.
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="type">class type</param>
        public static void Information(string message, Type type)
        {
            // Get the method info for the generic method
            var method = typeof(Log).GetMethod("ForContext", new Type[] { });

            // Create the generic method using the type parameter
            var genericMethod = method.MakeGenericMethod(type);

            // Invoke the generic method to get the logger
            var logger = genericMethod.Invoke(null, null) as ILogger;

            // Use the logger to log the info message
            logger.Information(message);
        }

        public static void Fatal<T>(string message) => Log.ForContext<T>().Fatal(message);

        /// <summary>
        /// Modified version of <see cref="Fatal{T}(string)"/> that can be used on Static Classes.
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="type">class type</param>
        public static void Fatal(string message, Type type)
        {
            // Get the method info for the generic method
            var method = typeof(Log).GetMethod("ForContext", new Type[] { });

            // Create the generic method using the type parameter
            var genericMethod = method.MakeGenericMethod(type);

            // Invoke the generic method to get the logger
            var logger = genericMethod.Invoke(null, null) as ILogger;

            // Use the logger to log the fatal message
            logger.Fatal(message);
        }

        public static void Error<T>(string message) => Log.ForContext<T>().Error(message);

        /// <summary>
        /// Modified version of <see cref="Error{T}(string)"/> that can be used on Static Classes.
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="type">class type</param>
        public static void Error(string message, Type type)
        {
            // Get the method info for the generic method
            var method = typeof(Log).GetMethod("ForContext", new Type[] { });

            // Create the generic method using the type parameter
            var genericMethod = method.MakeGenericMethod(type);

            // Invoke the generic method to get the logger
            var logger = genericMethod.Invoke(null, null) as ILogger;

            // Use the logger to log the fatal message
            logger.Error(message);
        }

        public static void Warning<T>(string message) => Log.ForContext<T>().Warning(message);

        /// <summary>
        /// Modified version of <see cref="Warning{T}(string)"/> that can be used on Static Classes.
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="type">class type</param>
        public static void Warning(string message, Type type)
        {
            // Get the method info for the generic method
            var method = typeof(Log).GetMethod("ForContext", new Type[] { });

            // Create the generic method using the type parameter
            var genericMethod = method.MakeGenericMethod(type);

            // Invoke the generic method to get the logger
            var logger = genericMethod.Invoke(null, null) as ILogger;

            // Use the logger to log the info message
            logger.Warning(message);
        }


    }
}
