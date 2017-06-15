using System;
using TDX.Api.Models;
using TDX.Api.Repositories;
using TDX.Api.Services;

namespace TDX.Api.Tests
{
    public class ServiceFixture : IDisposable
    {
        public DataService<Note> Notes { get; private set; }

        public ServiceFixture()
        {
            var ctx = new MongoDbContext();
            Notes = new NoteService(new Repository<Note>(ctx));
        }

        public void Dispose()
        {

        }
    }
}