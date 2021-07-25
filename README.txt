Angular 10
.Net 5.0
SQL SERVER 18
Visual Studio 2019
Node v16.5.0

To run the project install node using npm install.

Angular Component:

Car:
Takes date as input and after clicking on button gives car list, Price and Selling price and car for the maximum profit.

C#.Net:

Controllers:
CarController:
Get Car list from database

Models:
Car-display car info

ServiceClass:
Calculate Selling price based on conditions

appsettings.json
Connection string for connection

Startup.cs
helps to run the project

Alternate approach for Selling price: It could also be calculated using stored procedure in database but due to constraint I was not able to implement it.

Database: ABCAutomotive.bacpac file

Tables:Car,CarType


