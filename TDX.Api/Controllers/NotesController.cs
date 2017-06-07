using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDX.Api.Models;
using TDX.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace TDX.Api.Controllers
{
    public class NotesController : ApiController<Note>
    {
        public NotesController()
        {
            data = new NoteService();
        }
    }
}
