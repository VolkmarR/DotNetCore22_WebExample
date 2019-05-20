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
