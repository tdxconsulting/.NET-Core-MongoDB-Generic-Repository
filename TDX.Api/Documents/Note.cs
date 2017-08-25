using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TDX.Api.Documents
{
	public class Note : DocumentBase
	{
        [JsonProperty("text")]
		public string Text { get; set; }
	}
}
