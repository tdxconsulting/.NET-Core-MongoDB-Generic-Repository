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
    public class WidgetsController : ApiController<Widget>
    {
		public WidgetsController(WidgetService svc)
		{
			data = svc;
		}
    }
}
