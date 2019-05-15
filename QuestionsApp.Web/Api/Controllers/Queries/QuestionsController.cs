using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestionsApp.Web.Api.Models;

namespace QuestionsApp.Web.Api.Controllers.Queries
{
    [ApiController]
    [Route("Api/Queries/[controller]")]
    public class QuestionsController
    {
        [HttpGet]
        public List<Question> Get()
        {
            throw new NotImplementedException();
        }
    }
}
