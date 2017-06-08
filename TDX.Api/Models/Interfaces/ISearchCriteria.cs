using System;
namespace TDX.Api.Models
{
	public interface ISearchCriteria
	{
		int Offset { get; set; }
		int Limit { get; set; }
	}
}
