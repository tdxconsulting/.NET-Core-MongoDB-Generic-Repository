using System;
using Bogus;
using AutoBogus;
using TDX.Api.Models;

namespace TDX.Api.Tests.FakeData
{
    public static class DataUtility
    {
        public static Note CreateNote()
        {
            var note = new Faker<Note>(locale: "en_US")
                .RuleFor(n => n.Text, f => f.Lorem.Text());

			return note.Generate();
        }
    }
}
