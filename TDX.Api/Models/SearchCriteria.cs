using System;
using Newtonsoft.Json;

namespace TDX.Api.Models
{
	public class SearchCriteria : ISearchCriteria
	{
		[JsonProperty("offset")]
		public int Offset { get; set; } = 0;

		[JsonProperty("limit")]
		public int Limit { get; set; } = 50;
	}
}