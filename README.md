# NAB Coding Test

I have built a .Net Core Console app for the test.

## .Net Core Console App

### Features

*	Dependency Injection
	*	.Net Core dependency injection
*	Unit tests
	*	.Net Core **xUnit** unit tests
	*	**NSubstitute** for mocking
	*	The testing areas are
		*	Business logic tests
		*	Repository tests

### The solution
	
## **IPetStoreRepository** interface - Repository

| API | Description |
| ---- | ---- |
| GetPetStoreAsync | Reads the Pet.json text file and deserializes to object (using **Newtonsoft.Json** library). |

## **IPetStoreManager** interface - Business logic

| API | Description |
| ---- | ---- |
| GetPetsByPersonGender | Runs a **LINQ query** to perform the business logic. |


## Screenshot

![Screenshot](https://github.com/VeritasSoftware/NAB/blob/master/UI.jpg)



