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
	}
}
