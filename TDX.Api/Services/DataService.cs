using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using TDX.Api.Repositories;
using MongoDB.Driver;

namespace TDX.Api.Services
{
	public abstract class DataService<T> : IDataService<T> where T : class
	{
		protected IRepository<T> repo;

        public string CollectionName { get { return repo.CollectionName; } }

		public async Task<DeleteResult> Delete(string id)
		{
			return await repo.Delete(id);
		}

		public async Task<T> Get(string id)
		{
			return await repo.Get(id);
		}

		public async Task<IEnumerable<T>> GetByParentId(string id)
		{
			return await repo.GetByParentId(id);
		}

		public async Task<string> Insert(T model)
		{
			return await repo.Insert(model);
		}

		public async Task<UpdateResult> SetActive(string id, bool isActive)
		{
			return await repo.SetActive(id, isActive);
		}

		public async Task<UpdateResult> SoftDelete(string id)
		{
			return await repo.SoftDelete(id);
		}

		public async Task<ReplaceOneResult> Update(T model)
		{
			return await repo.Update(model);
		}

        public abstract Task<IEnumerable<T>> Search(ISearchCriteria criteria);
	}
}
