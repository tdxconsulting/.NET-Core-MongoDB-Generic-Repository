using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Documents;
using TDX.Api.Models;
using TDX.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

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
        public async Task<IActionResult> Search([FromQuery] NoteSearchCriteria criteria)
		{
			if (!TryValidateModel(criteria))
				return BadRequest();

			var result = await data.Search(criteria);

			if (!result.Any<Note>())
				return NotFound(criteria);

			return Ok(result);
		}
    }
}
