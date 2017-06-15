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
	public class NoteServiceTest : IClassFixture<ServiceFixture>
	{
		private readonly ServiceFixture fixture;

		public NoteServiceTest(ServiceFixture svcs)
		{
			fixture = svcs;
		}

		[Fact]
		public async Task SearchNotesNoResult()
		{
            var results = await fixture.Notes.Search(new NoteSearchCriteria
            {
                Text = "this should result in an empty array"
            });
            Console.WriteLine(JsonConvert.SerializeObject(results));
        }

        [Fact]
		public async Task SearchAllNotes()
		{
			var results = await fixture.Notes.Search(new NoteSearchCriteria
			{
				Text = "a"
			});
			Console.WriteLine(JsonConvert.SerializeObject(results));
		}

		[Fact]
		public async Task ReadAllNotesNoCriteria()
		{
			var results = await fixture.Notes.Search(null);
			Console.WriteLine(JsonConvert.SerializeObject(results));
		}
    }
}
