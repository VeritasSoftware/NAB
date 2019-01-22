using System.Threading.Tasks;

namespace NAB.PetStore.Repository
{
    public interface IPetStoreManager
    {
        Task<PetsByPersonGenderCollection> GetPetsByPersonGender(PetType petType);
    }
}
