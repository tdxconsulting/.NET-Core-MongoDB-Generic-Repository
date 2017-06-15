using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using MongoDB.Driver;

namespace TDX.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IModel
    {
        protected readonly MongoDbContext context;
        protected IMongoCollection<T> collection;

		public IMongoCollection<T> Collection
		{
			get { return collection; }
		}

		public Repository(MongoDbContext ctx)
		{
			context = ctx;
			collection = context.Database.GetCollection<T>(context.GetCollectionName(typeof(T)));
        }

        public async Task<DeleteResult> Delete(string id)
        {
		    try
			{
				return await collection.DeleteOneAsync(
					 Builders<T>.Filter.Eq(x => x.Id, id));
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

		public async Task<IEnumerable<T>> Search(ISearchCriteria criteria = null, FilterDefinition<T> filter = null)
		{
			if (filter == null)
				return null;

			if (criteria == null)
				criteria = new SearchCriteria();

			try
			{
				return await collection
					.Find(filter)
					.Skip(criteria.Offset)
					.Limit(criteria.Limit)
					.ToListAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public async Task<T> Get(string id)
		{
			var filter = Builders<T>.Filter.Eq(x => x.Id, id);

			try
			{
				return await collection
								.Find(filter)
								.FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<T> GetByParentId(string id)
		{
			var filter = Builders<T>.Filter.Eq(x => x.ParentId, id);

			try
			{
				return await collection
								.Find(filter)
								.FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public async Task<string> Insert(T model)
        {
			try
			{
                await collection.InsertOneAsync(model);
				var filter = Builders<T>.Filter.Eq(x => x.Id, model.Id);
				var update = Builders<T>.Update
								.CurrentDate(s => s.Created);
                await collection.UpdateOneAsync(filter, update);
                return model.Id;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public async Task<UpdateResult> SoftDelete(string id)
        {
			var filter = Builders<T>.Filter.Eq(x => x.Id, id);
			var update = Builders<T>.Update
							.Set(s => s.IsSoftDeleted, true)
							.CurrentDate(s => s.SoftDeleted);

			try
			{
				return await collection.UpdateOneAsync(filter, update);
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public async Task<ReplaceOneResult> Update(T model)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, model.Id);
			try
			{
				return await collection.ReplaceOneAsync(filter, model, new UpdateOptions { IsUpsert = true });
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

		public async Task<UpdateResult> SetActive(string id, bool isActive)
		{
			var filter = Builders<T>.Filter.Eq(x => x.Id, id);
			var update = Builders<T>.Update
							.Set(s => s.IsActive, isActive)
							.CurrentDate(s => s.Updated);

			try
			{
				return await collection.UpdateOneAsync(filter, update);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
    }
}
