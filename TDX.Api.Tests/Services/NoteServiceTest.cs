﻿using System;
using Newtonsoft.Json;
using Xunit;
using TDX.Api.Services;
using TDX.Api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TDX.Api.Tests.Services
{
    public class NoteServiceTest
    {
        private readonly NoteService notes;

        public NoteServiceTest()
        {
            notes = new NoteService();
        }

		[Fact]
		public async Task ReadAllNotes()
		{
            var results = await notes.Search(new NoteSearchCriteria
            {
                Text = "this should result in an empty array"
            });
            Console.WriteLine(JsonConvert.SerializeObject(results));
        }

		[Fact]
		public async Task ReadAllNotesNoCriteria()
		{
			var results = await notes.Search();
			Console.WriteLine(JsonConvert.SerializeObject(results));
		}
    }
}
