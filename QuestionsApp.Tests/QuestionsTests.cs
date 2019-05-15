using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionsApp.Web.DB;
using Xunit;

namespace QuestionsApp.Tests
{
    public class QuestionsQueriesTests
    {
        private QuestionsContext NewContext()
        {
            var options = new DbContextOptionsBuilder<QuestionsContext>().
                                UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            return new QuestionsContext(options);
        }

        private QuestionsApp.Web.Api.Controllers.Queries.QuestionsController NewQuery(QuestionsContext context)
        {
            return new Web.Api.Controllers.Queries.QuestionsController(context);
        }

        private QuestionsApp.Web.Api.Controllers.Commands.QuestionsController NewCommand(QuestionsContext context)
        {
            return new Web.Api.Controllers.Commands.QuestionsController(context);
        }


        [Fact]
        public void Empty()
        {
            var query = NewQuery(NewContext());

            Assert.Empty(query.Get());
        }

        [Fact]
        public void OneQuestion()
        {
            var context = NewContext();
            var query = NewQuery(context);
            var command = NewCommand(context);

            Assert.IsType<OkResult>(command.Ask("Dummy Question"));

            Assert.Single(query.Get());
        }

        [Fact]
        public void OneQuestionAndVote()
        {
            var context = NewContext();
            var query = NewQuery(context);
            var command = NewCommand(context);

            Assert.IsType<OkResult>(command.Ask("Dummy Question"));
            
            var result = query.Get();
            Assert.Single(result);
            Assert.Equal(0, result[0].Votes);

            Assert.IsType<OkResult>(command.Vote(result[0].ID));
            result = query.Get();
            Assert.Single(result);
            Assert.Equal(1, result[0].Votes);
        }

    }
}
