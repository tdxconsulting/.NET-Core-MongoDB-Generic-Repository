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
		private List<KeyValuePair<Type, string>> collections;

		public MongoDbContext(IOptions<MongoDbSettings> settings = null)
		{
			Init(settings);
		}

		private void Init(IOptions<MongoDbSettings> settings)
		{
			//TODO: read from config
			//var client = new MongoClient(settings.Value.ConnectionString);
			//if (client != null)
			//    Database = client.GetDatabase(settings.Value.Database);

			var client = new MongoClient("mongodb://localhost:27017");
			if (client != null)
				Database = client.GetDatabase("TDX-API");

			collections = new List<KeyValuePair<Type, string>>();

			collections.Add(new KeyValuePair<Type, string>(typeof(Note), "Notes"));
		}

		public string GetCollectionName(Type t)
		{
			return collections.Where(c => c.Key == t).FirstOrDefault().Value ?? string.Empty;
		}
    }
}
