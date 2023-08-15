using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NLogStructuredLogging
{
    internal class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] _)
        {
            var anonymousObject = new { Id = 1, Timestamp = DateTime.UtcNow, Tag = "tag1" };

            var complexObject = new ComplexObject
            {
                Labels = new[] { "Label1", "Label2" },
                Configuration = new Dictionary<string, object>()
                {
                        { "Foo", 1 },
                        { "Bar", "One" }
                },
                Child = new ComplexObjectChild
                {
                    SomeProp = 1,
                }
            };

            logger.Info("Here are some primitives: {Text} {Number}", "MyText", 49);
            logger.Info("Here is an anonymous object: {}", anonymousObject);
            logger.Info("Here is a complex object: {@ComplexObject}", complexObject);

            try
            {
                throw new InvalidOperationException("Here is an exception");
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
