using System.Threading.Tasks;

namespace NAB.PetStore.Repository
{
    /// <summary>
    /// Interface IPetStoreRepository
    /// </summary>
    public interface IPetStoreRepository
    {
        Task<Person[]> GetPetStoreAsync();
    }
}
