# Step 4 - Client Refresh

## Server Configration

* Add the new Folder Hubs to Question.Web
* Add new Class QuestionsHub to Folder Hub
* Configure and activate SignalR in the Startup class

## Add calles to the hub

* Add a new IHubContext<QuestionsHub> property to the Commands\QuestionController class 
* And thr parameter to the constructor
* Fix the instantiation in the unit test constructor
* Add a new method RefreshClients and call it in the two methods

## Web site Implementation

* Add signalr script
* Remove the call of getQuestions from the methods ask and vote 
* Add connection to hub and register to the refresh message to call getQuestions
