# Step 1 - Setup the project

## Create the Solution

* Create new, empty asp.net core 2.2 webapplication 
  * project name: QuestionsApp.Web
  * solution name: QuestionsApp
* Add new class library project (.Net Standard)
  * project name: QuestionsApp.Tests
* Save all

## Activate MVC for the Web Api

* Activate and configure MVC in Startup.cs
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
* Add the ApiController and Route Attributes to the QuestionsController classes
* Add the following methods to the conrollers
  * Get to Queries/QuestionsController
  * Ask and Vote to Commands/QuestionsController
