# Step 2 - Web Api implementation

## Add database model

* Add the NuGet packages to both projects
  * Microsoft.EntityFrameworkCore.InMemory
  * Microsoft.EntityFrameworkCore.Sqlite
* Add new folder DB to the QuestionsApp.Web project
* Add new classes for the database model
  * QuestionsContext
  * QuestionDB
  * VoteDB
* Add properties to QuestionDB 
  * ID (int, Key, DatabaseGenerated)
  * Content (string)
  * Votes (ICollection)
* Add properties to QuestionDB 
  * ID (int, Key, DatabaseGenerated)
  * QuestionID (int)
  * Question (QuestionDB)
* Implement QuestionsContext
  * DbSet for Questions and Votes
  * Constructor with DbContextOptions parameter
* Configure EntityFramework in startup to use InMemoryDatabase

## Implement Queries and Commands

* Add a constructor to controllers for dependency injection
* Implement the controllers
* Test the implementation with the unit tests

## Activate Swagger

* Add the Swashbuckle.AspNetCore NuGet package to the QuestionsApp.Web project
* Configure and activate Swagger