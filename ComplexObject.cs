using System.Collections.Generic;

namespace NLogStructuredLogging
{
    internal class ComplexObject
    {
        public string[] Labels { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public ComplexObjectChild Child { get; set; }
    }
}
