using System;
using Newtonsoft.Json;

namespace TDX.Api.Documents
{
    public class Widget : DocumentBase
    {
		[JsonProperty("prop1")]
		public string Property1 { get; set; }

		[JsonProperty("prop2")]
		public string Property2 { get; set; }
    }
}
