using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using TDX.Api.Repositories;
using MongoDB.Driver;

namespace TDX.Api.Services
{
	public class NoteService : DataService<Note>, ISearchable<Note>
	{
		public NoteService(IRepository<Note> repository)
		{
			repo = repository;
		}

		public override async Task<IEnumerable<Note>> Search(ISearchCriteria criteria = null)
		{
			if (criteria == null)
				return null;

			var filter = CreateFilterDefinition(criteria);

			return await repo.Search(criteria, filter);
		}

		public FilterDefinition<Note> CreateFilterDefinition(ISearchCriteria criteria)
		{
            if (criteria == null)
                return null;

			var c = criteria as NoteSearchCriteria;

			var filter = Builders<Note>.Filter.Where(n => n.Text.Contains(c.Text.Trim()));

            return filter;
		}
	}
}
