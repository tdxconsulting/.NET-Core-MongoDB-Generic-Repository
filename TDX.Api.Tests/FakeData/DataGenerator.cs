﻿using System;
using Newtonsoft.Json;
using Xunit;
using TDX.Api.Services;
using TDX.Api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TDX.Api.Tests.FakeData
{
    public class DataGenerator
    {
        private readonly NoteService notes;

        public DataGenerator()
        {
            notes = new NoteService();
        }

		//[Fact]
		public async void CreateNote()
		{
            var note = DataUtility.CreateNote();
            await notes.Insert(note);
            Console.WriteLine(JsonConvert.SerializeObject(note));
        }
    }
}
