using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using TDX.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace TDX.Api.Controllers
{
    public class NotesController : ApiController<Note>
    {
		public NotesController(NoteService svc)
		{
			data = svc;
		}

		// GET: api/items/search?text=abc&offset=0&limit=20
		[HttpGet("search")]
        public async Task<IEnumerable<Note>> Search([FromQuery] NoteSearchCriteria criteria)
		{
			return await data.Search(criteria);
		}
    }
}
