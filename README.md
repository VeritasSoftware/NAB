# NAB Coding Test

I have built a .Net Core Console app for the test.

## .Net Core Console App

### Features

*	Dependency Injection
*	.Net Core **xUnit** unit tests. Using **NSubstitute** for mocking.
		*	Business logic tests
		*	Repository tests

### The solution
	
## **IPetStoreRepository** interface - Repository

| API | Description |
| ---- | ---- |
| GetPetStoreAsync | Reads the Pet.json text file and deserializes to object (using **Newtonsoft.Json** library). |

## **IPetStoreMananger** interface - Business logic

| API | Description |
| ---- | ---- |
| GetPetsByPersonGender | Runs a **LINQ query** to perform the business logic. |




