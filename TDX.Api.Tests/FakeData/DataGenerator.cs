﻿using System;
using Newtonsoft.Json;
using Xunit;
using TDX.Api.Services;
using TDX.Api.Documents;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TDX.Api.Tests.FakeData
{
	public class DataGenerator : IClassFixture<ServiceFixture>
	{
		private readonly ServiceFixture fixture;

		public DataGenerator(ServiceFixture svcs)
		{
			fixture = svcs;
		}

		[Fact]
		public async void CreateNote()
		{
            var note = DataUtility.CreateNote();
            await fixture.Notes.Insert(note);
            Console.WriteLine(JsonConvert.SerializeObject(note));
        }

		[Fact]
		public async void CreateWidget()
		{
			var widget = DataUtility.CreateWidget();
			await fixture.Widgets.Insert(widget);
			Console.WriteLine(JsonConvert.SerializeObject(widget));
		}
    }
}
