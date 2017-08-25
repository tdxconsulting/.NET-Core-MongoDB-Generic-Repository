using System;
using Bogus;
using AutoBogus;
using TDX.Api.Documents;

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

        public static Widget CreateWidget()
        {
            var widget = new Faker<Widget>(locale: "en_US")
                .RuleFor(n => n.Property1, f => f.Lorem.Text())
                .RuleFor(n => n.Property2, f => f.Lorem.Text());

            return widget.Generate();
        }
    }
}
