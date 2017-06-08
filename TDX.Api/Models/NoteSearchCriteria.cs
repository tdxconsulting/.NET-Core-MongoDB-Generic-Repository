using System;
using Newtonsoft.Json;

namespace TDX.Api.Models
{
	public class NoteSearchCriteria : SearchCriteria
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
