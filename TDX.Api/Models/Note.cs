using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TDX.Api.Models
{
	public class Note : ModelBase
	{
        [JsonProperty("text")]
		public string Text { get; set; }
	}
}
