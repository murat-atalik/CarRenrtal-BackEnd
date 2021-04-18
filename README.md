# RentACarProject -Backend
## Table of contents
* [About the Project](#about-project)
* [Built With](#built-with)
* [Techniques](#techniques)
* [Setup](#setup)

## About Project
I prepared this project in accordance with its solid principle to improve myself and learn about corporate software architecture.
This project is the backend part of a car rental system. If you want to look at the frontend part of the car rental system, check the link below. 
* [Car Rental FrontEnd](https://github.com/murat-atalik/CarRental-FrontEnd)
 ## Built With
Project is created with:
* .NET
* ASP.NET for Restful api
* EntityFramework Core
* Autofac
* FluentValidation
* MsSql
	
  ## Techniques
* Layered Architecture Design Pattern
* AOP
* Autofac dependency resolver
* IOC
* JWT

## Setup
* [Change local path address](https://github.com/murat-atalik/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/MyCarDbContext.cs)
* [Delete Mıgrations Folder](https://github.com/murat-atalik/ReCapProject/tree/master/DataAccess/Migrations)
* Open Nuget Package Manager Console
* Type add-Migration MigrationName and press the Enter button.
If this process was successful, go to the next step. 
* Type update-database and press the Enter button.
* Follow these steps all setup will be finished.
