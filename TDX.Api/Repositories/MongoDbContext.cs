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
		private List<KeyValuePair<Type, string>> collections;

        public IMongoDatabase Database { get; private set; }

		public MongoDbContext(IOptions<AppSettings> config)
		{
            Init(config.Value.MongoDbSettings);
		}

		private void Init(MongoDbSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			if (client != null)
			    Database = client.GetDatabase(settings.Database);

			collections = new List<KeyValuePair<Type, string>>();
			collections.Add(new KeyValuePair<Type, string>(typeof(Note), "Notes"));
		}

		public string GetCollectionName(Type t)
		{
			return collections.Where(c => c.Key == t).FirstOrDefault().Value ?? string.Empty;
		}
    }
}
