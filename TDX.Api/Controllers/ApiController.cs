using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using TDX.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

namespace TDX.Api.Controllers
{
    [Route("api/[controller]")]
	[Produces("application/json")]
    public class ApiController<T> : Controller where T : class, IModel
    {
        protected IDataService<T> data;

		protected string ControllerUri
		{
			get { return $"api/{data.CollectionName.ToLower()}/"; }
		}

        // GET: api/items
        [HttpGet]
		public async Task<IActionResult> Search([FromBody] ISearchCriteria criteria)
        {
			if (!TryValidateModel(criteria))
				return BadRequest();

			var result = await data.Search(criteria);

			if (!result.Any<T>())
				return NotFound(criteria);

			return Ok(result);
        }

		// GET api/items/593048b58d9f120eca1b001a
		[HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
			var result = await data.Get(id);

			if (result == null)
				return NotFound(id);

			return Ok(result);
        }

        // GET api/items/parent/593048b58d9f120eca1b001a
		[HttpGet("parent/{id}")]
		public async Task<IActionResult> GetByParentId(string id)
		{
			var result = await data.GetByParentId(id);

			if (!result.Any<T>())
				return NotFound(id);

			return Ok(result);
		}

        // POST api/items
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T model)
        {
			var id = await data.Insert(model);

			return Created($"{ControllerUri}{id}", id);
        }

		// PUT api/items/593048b58d9f120eca1b001a
		[HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] T model)
        {
			var result = await data.Update(model);

			return Ok(model);
        }

		// PATCH api/items/593048b58d9f120eca1b001a
		[HttpPatch("{id}")]
		public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<T> patch)
		{
			var model = await data.Get(id);
			patch.ApplyTo(model);

			var result = await data.Update(model);

			return Ok(patch);
		}

		// DELETE api/items/593048b58d9f120eca1b001a
		[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
			var result = await data.SoftDelete(id);

			return NoContent();
        }
    }
}
