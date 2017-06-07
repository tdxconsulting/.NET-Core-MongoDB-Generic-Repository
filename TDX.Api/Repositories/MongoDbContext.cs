using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TDX.Api.Models;
using System.Collections.Generic;
using System;

namespace TDX.Api.Repositories
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase db;

        public IMongoDatabase Database { get { return db; } }

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
			var client = new MongoClient("mongodb://localhost:27017");
			if (client != null)
			    db = client.GetDatabase("TDX-API");

			//var client = new MongoClient(settings.Value.ConnectionString);
			//if (client != null)
			//    db = client.GetDatabase(settings.Value.Database);
		}
    }
}
