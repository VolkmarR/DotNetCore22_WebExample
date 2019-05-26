# Step 1 - Setup the project

## Create the Solution

* Create new, empty asp.net core 2.2 webapplication 
  * project name: QuestionsApp.Web
  * solution name: QuestionsApp
* Add new XUnit Test project (.Net Core)
  * project name: QuestionsApp.Tests
* Save all

## Add folders and files for the Web Api

* Add the folders 
  * Api
  * Api/Models
  * Api/Controllers
  * Api/Controllers/Commands
  * Api/Controllers/Queries
* Add the classes
  * QuestionsController.cs in Api/Controllers/Queries
  * QuestionsController.cs in Api/Controllers/Commands
  * Question in Api/Models

## Activate MVC for the Web Api

<details><summary>Activate and configure MVC in Startup.cs</summary>
 
~~~c#
public void ConfigureServices(IServiceCollection services)
{
    // Configuration for the MVC Framework
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

    // activate mvc for web-api
    app.UseMvc();

    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Error!");
    });
}
~~~
</details>

### Add the ApiController and Route Attributes to the QuestionsController classes

<details><summary>QuestionsController.cs in Api/Controllers/Queries</summary>
 
~~~c#
[ApiController]
[Route("Api/Queries/[controller]")]
public class QuestionsController
~~~
</details>
<details><summary>QuestionsController.cs in Api/Controllers/Commands</summary>
 
~~~c#
[ApiController]
[Route("Api/Commands/[controller]/[action]")]
public class QuestionsController
 ~~~
</details>

### Add Methods to the QuestionsController classes

<details><summary>Method Get to QuestionsController.cs in Api/Controllers/Queries</summary>
 
~~~c#
[HttpGet]
public List<Question> Get()
{
    throw new NotImplementedException();
}
~~~
</details>
<details><summary>Ask and Vote to QuestionsController.cs in Api/Controllers/Commands</summary>
 
~~~c#
[HttpPut]
public IActionResult Ask([FromQuery]string content)
{
    throw new NotImplementedException();
}

[HttpPut]
public IActionResult Vote([FromQuery]int questionID)
{
    throw new NotImplementedException();
}
~~~
</details>

### Add properties to Models/Question

<details><summary>int ID, string Content, int Votes</summary>

~~~c#
public int ID { get; set; }
public string Content { get; set; }
public int Votes { get; set; }
~~~
</details>

## Add Unittests for Controllers

* Create the refererence to the QuestionsApp.Web project in the QuestionsApp.Tests project
* Add NuGet Packages used by QuestionsApp.Web project to QuestionsApp.Tests project
* Add QuestionsTests class for tests

### Implement tests 

<details><summary>Helper methods to create instances for the controllers</summary>

~~~c#
private QuestionsApp.Web.Api.Controllers.Queries.QuestionsController NewQuery()
{
    return new Web.Api.Controllers.Queries.QuestionsController();
}

private QuestionsApp.Web.Api.Controllers.Commands.QuestionsController NewCommand()
{
    return new Web.Api.Controllers.Commands.QuestionsController();
}
~~~
</details>


<details><summary>Empty</summary>

~~~c#
[Fact]
public void Empty()
{
    var query = NewQuery();
    Assert.Empty(query.Get());
}
~~~
</details>

<details><summary>OneQuestion</summary>

~~~c#
[Fact]
public void OneQuestion()
{
    var query = NewQuery();
    var command = NewCommand();

    Assert.NotNull(command.Ask("Dummy Question"));

    Assert.Single(query.Get());
}
~~~
</details>

<details><summary>OneQuestionAndVote</summary>

~~~c#
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
~~~
</details>
