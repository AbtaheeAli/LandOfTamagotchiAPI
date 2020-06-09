# LandOfTamagotchiAPI

I created an API that allows a user to create and care for a virtual pet, reminiscent of a Tamagotchi. This application not only uses API endpoints and Entity Framework Core, but is able to do the basic functionality web API: create, read, update and delete.

Used a POCO called Tamagotchi with the following columns:
Id
Name
Birthday
HungerLevel
HappinessLevel

The API has the following endpoints

- GET /tamagotchis : returns all Tamagotchis in your database.

- GET /tamagotchis/{id} : returns the Tamagotchis with the corresponding id.

- POST /tamagotchis : Creates a new Tamagotchis. The Tamagotchis Birthday defaults to the current datetime, HungerLevel defaults to 0 and HappinessLevel defaults to 0.

- POST /tamagotchis/{id}/playtimes : Finds Tamagotchis by id and adds 5 to its happiness level and 3 to its hungry level.

- POST /tamagotchis/{id}/feedings : Finds the Tamagotchi by id and subtracts 5 from its hungry level and 3 from its happiness level.

- POST /tamagotchis/{id}/scoldings : Finds the Tamagotchi by id and subtracts 5 from its happiness level.

- DELETE /tamagotchis/{id} : Deletes a Tamagotchi from the database by Id
