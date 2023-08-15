using System;
using System.Diagnostics;
using System.IO;

namespace NLogStructuredLogging
{
    internal class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] _)
        {
            logger.Info("This is a structured log with primitives. Properties: {Text} {Number}", 
                "MyText", 49);

            logger.Info("This is a structured log with a complex object. Properties: {}", 
                new { Id = 1, Timestamp = DateTime.UtcNow, Tag = "tag1" });

            try
            {
                throw new InvalidOperationException("This is a structured log with an exception");
            }
            catch (InvalidOperationException ex)
            {
                logger.Error(ex);
            }

            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", $"{DateTime.Today:yyyy-MM-dd}.log");
            Process.Start(logPath);
        }
    }
}
