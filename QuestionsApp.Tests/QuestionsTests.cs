using System;
using Xunit;

namespace QuestionsApp.Tests
{
    public class QuestionsQueriesTests
    {
        private QuestionsApp.Web.Api.Controllers.Queries.QuestionsController NewQuery()
        {
            return new Web.Api.Controllers.Queries.QuestionsController();
        }

        private QuestionsApp.Web.Api.Controllers.Commands.QuestionsController NewCommand()
        {
            return new Web.Api.Controllers.Commands.QuestionsController();
        }


        [Fact]
        public void Empty()
        {
            var query = NewQuery();

            Assert.Empty(query.Get());
        }

        [Fact]
        public void OneQuestion()
        {
            var query = NewQuery();
            var command = NewCommand();

            Assert.NotNull(command.Ask("Dummy Question"));

            Assert.Single(query.Get());
        }

        [Fact]
        public void OneQuestionAndVote()
        {
            var query = NewQuery();
            var command = NewCommand();

            Assert.NotNull(command.Ask("Dummy Question"));
            
            var result = query.Get();
            Assert.Single(result);
            Assert.Equal(0, result[0].Votes);

            Assert.NotNull(command.Vote(result[0].ID));
            result = query.Get();
            Assert.Single(result);
            Assert.Equal(1, result[0].Votes);
        }

    }
}
