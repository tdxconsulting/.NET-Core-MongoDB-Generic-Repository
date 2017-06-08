using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using TDX.Api.Repositories;
using MongoDB.Driver;

namespace TDX.Api.Services
{
	public class NoteService : DataService<Note>
	{
		public NoteService()
		{
			repo = new Repository<Note>("Notes");
		}

		protected override FilterDefinition<Note> CreateFilterDefinition(ISearchCriteria criteria)
		{
            if (criteria == null)
                return null;

			var c = criteria as NoteSearchCriteria;

            Console.WriteLine(c.Text);

			var filter = Builders<Note>.Filter.Where(n => n.Text.Contains(c.Text.Trim()));

            return filter;
		}
	}
}
