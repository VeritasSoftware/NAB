using NAB.PetStore.Repository;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NAB.PetStore.UnitTests
{
    /// <summary>
    /// class PetStoreManagerTests - Business logic tests
    /// </summary>
    public class PetStoreManagerTests
    {
        private async Task<Person[]> GetPetStoreAsync()
        {
            //Get Pet Store
            var petsRepository = new PetStoreRepository() { Path = "./Pet.json" };
            var personAndPets = await petsRepository.GetPetStoreAsync();

            return personAndPets;
        }

        [Fact]
        public void Test_GetPetsByPersonGender()
        {
            //Use NSubstitue to mock the repository layer
            var petStoreRepository = Substitute.For<IPetStoreRepository>();
            petStoreRepository.GetPetStoreAsync().Returns(this.GetPetStoreAsync().Result);            

            //Create PetStoreManager instance
            IPetStoreManager petStoreManager = new PetStoreManager(petStoreRepository);

            //Call method to be tested. This method contains the business logic.
            var catsByPersonGender = petStoreManager.GetPetsByPersonGender(PetType.Cat).Result;

            //Check that there are 2 genders in the collection
            Assert.True(catsByPersonGender.PetsByPersonGender.Count == 2);

            //Check Cats belonging to Male persons
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Gender == Gender.Male);
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.Count() == 4);
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.Count(p => p.Name == "Garfield") == 1);
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.Count(p => p.Name == "Jim") == 1);
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.Count(p => p.Name == "Max") == 1);
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.Count(p => p.Name == "Tom") == 1);
            //Check that the pets are ordered alphabetically
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.ElementAt(0).Name == "Garfield");
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.ElementAt(1).Name == "Jim");
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.ElementAt(2).Name == "Max");
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.ElementAt(3).Name == "Tom");

            //Check Cats belonging to Female persons
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Gender == Gender.Female);
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.Count() == 3);
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.Count(p => p.Name == "Garfield") == 1);
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.Count(p => p.Name == "Simba") == 1);
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.Count(p => p.Name == "Tabby") == 1);
            //Check that the pets are ordered alphabetically
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.ElementAt(0).Name == "Garfield");
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.ElementAt(1).Name == "Simba");
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.ElementAt(2).Name == "Tabby");
        }
    }
}
