using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TDX.Api.Services
{
    public interface IDataService<T> where T : class
    {
		Task<IEnumerable<T>> Get(int offset = 0, int limit = 50);
		Task<T> Get(string id);
		Task<string> Insert(T model);
		Task<ReplaceOneResult> Update(T model);
		Task<DeleteResult> Delete(string id);
		Task<UpdateResult> SoftDelete(string id);
        Task<UpdateResult> SetActive(string id, bool isActive);
    }
}
