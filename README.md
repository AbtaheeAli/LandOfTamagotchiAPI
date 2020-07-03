# LandOfTamagotchiAPI

![Kapture 2020-07-03 at 8 52 47](https://user-images.githubusercontent.com/62678918/86471114-bb6c9700-bd0a-11ea-8c84-ecd7d114ae30.gif)

Languages and technologies used: C#, API, ASP.NET, & Entity Framework Core

I created an API that allows a user to create and care for a virtual pet, also known as a Tamagotchi. This application not only uses API endpoints and Entity Framework Core, but is able to do the basic functionality of a web API: create, read, update and delete.

I used a POCO called Tamagotchi with the following columns:
Id
Name
Birthday
HungerLevel
HappinessLevel

The API has the following endpoints:

- GET /tamagotchis : returns all Tamagotchi's in your database.

- GET /tamagotchis/{id} : returns the Tamagotchi with the corresponding id.

- POST /tamagotchis : Creates a new Tamagotchi. The Tamagotchi's Birthday defaults to the current datetime, HungerLevel defaults to 0 and HappinessLevel defaults to 0.

- POST /tamagotchis/{id}/playtimes : Finds the Tamagotchi by id and adds 5 to its happiness level and 3 to its hungry level.

- POST /tamagotchis/{id}/feedings : Finds the Tamagotchi by id and subtracts 5 from its hungry level and 3 from its happiness level.

- POST /tamagotchis/{id}/scoldings : Finds the Tamagotchi by id and subtracts 5 from its happiness level.

- DELETE /tamagotchis/{id} : Deletes a Tamagotchi from the database by Id
