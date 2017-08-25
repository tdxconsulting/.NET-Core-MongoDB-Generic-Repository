using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Documents;
using TDX.Api.Models;
using TDX.Api.Repositories;
using MongoDB.Driver;

namespace TDX.Api.Services
{
	public class WidgetService : DataService<Widget>
	{
		public WidgetService(IRepository<Widget> repository)
		{
			repo = repository;
		}

        public override Task<IEnumerable<Widget>> Search(ISearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
	}
}
