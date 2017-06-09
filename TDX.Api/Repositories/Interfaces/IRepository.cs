using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using MongoDB.Driver;

namespace TDX.Api.Repositories
{
	public interface IRepository<T> where T : class
	{
		IMongoCollection<T> Collection { get; }
		Task<IEnumerable<T>> Search(ISearchCriteria criteria, FilterDefinition<T> filter);
		Task<T> Get(string id);
        Task<T> GetByParentId(string id);
		Task<string> Insert(T model);
		Task<ReplaceOneResult> Update(T model);
		Task<DeleteResult> Delete(string id);
        Task<UpdateResult> SoftDelete(string id);
        Task<UpdateResult> SetActive(string id, bool isActive);
	}
}