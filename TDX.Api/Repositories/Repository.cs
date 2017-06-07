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

        public Repository(string collectionName)
        {
            context = new MongoDbContext(null);
            collection = context.Database.GetCollection<T>(collectionName);
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

        public async Task<IEnumerable<T>> Get(int offset = 0, int limit = 50)
        {
			try
			{
				return await collection.Find(_ => true).ToListAsync();
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
