using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TDX.Api.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TDX.Api.Repositories
{
    public class MongoDbContext
    {
		public IMongoDatabase Database { get; private set; }

		private MongoDbCollectionRegistry collections;

		public MongoDbContext(IOptions<AppSettings> config, MongoDbCollectionRegistry registry)
		{
			collections = registry;
			Init(config.Value.MongoDbSettings);
		}

		private void Init(MongoDbSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			if (client != null)
				Database = client.GetDatabase(settings.Database);
		}

		public string GetCollectionName(Type t)
		{
			return collections.GetCollectionName(t);
		}
    }
}
