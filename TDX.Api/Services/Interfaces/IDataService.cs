using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using TDX.Api.Models;

namespace TDX.Api.Services
{
    public interface IDataService<T> where T : class
    {
		Task<IEnumerable<T>> Search(ISearchCriteria criteria);
		Task<T> Get(string id);
		Task<string> Insert(T model);
		Task<ReplaceOneResult> Update(T model);
		Task<DeleteResult> Delete(string id);
		Task<UpdateResult> SoftDelete(string id);
        Task<UpdateResult> SetActive(string id, bool isActive);
    }
}
