using NAB.PetStore.Repository;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NAB.PetStore.UnitTests
{
    public class PetStoreRepositoryTests
    {
        [Fact]
        public async Task Test_GetPetStoreAsync()
        {
            var petStoreRepository = new PetStoreRepository() { Path = "./Pet.json" };

            var petStore = await petStoreRepository.GetPetStoreAsync();

            Assert.True(petStore.Length == 6);
            var petsCount = petStore.Sum(x => x.Pets?.Count);
            Assert.True(petsCount == 10);
        }
    }
}
