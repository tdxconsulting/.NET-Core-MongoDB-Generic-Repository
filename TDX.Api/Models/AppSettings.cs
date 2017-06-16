using System;
namespace TDX.Api.Models
{
    public class AppSettings
    {
		public MongoDbSettings MongoDbSettings { get; set; }
		public Logging Logging { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public LogLevel LogLevel { get; set; }
    }
}
