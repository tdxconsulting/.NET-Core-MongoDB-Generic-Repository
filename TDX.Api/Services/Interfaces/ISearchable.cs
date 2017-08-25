using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Documents;
using TDX.Api.Models;
using MongoDB.Driver;

namespace TDX.Api.Services
{
	public interface ISearchable<T> where T : class
	{
		Task<IEnumerable<T>> Search(ISearchCriteria criteria);
		FilterDefinition<T> CreateFilterDefinition(ISearchCriteria criteria);
	}
}