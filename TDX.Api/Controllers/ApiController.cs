using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using TDX.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace TDX.Api.Controllers
{
    [Route("api/[controller]")]
	[Produces("application/json")]
    public class ApiController<T> : Controller where T : class, IModel
    {
        protected IDataService<T> data;

        // GET: api/items
        [HttpGet]
		public async Task<IEnumerable<T>> Search()
        {
			return await data.Search(null);
		}

		// GET api/items/593048b58d9f120eca1b001a
		[HttpGet("{id}")]
        public async Task<T> Get(string id)
        {
            return await data.Get(id);
        }

        // POST api/items
        [HttpPost]
        public async Task Post([FromBody] T model)
        {
            await data.Insert(model);
        }

		// PUT api/items/593048b58d9f120eca1b001a
		[HttpPut("{id}")]
        public async Task Put([FromBody] T model)
        {
            await data.Update(model);
        }

		// DELETE api/items/593048b58d9f120eca1b001a
		[HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await data.SoftDelete(id);
        }
    }
}
