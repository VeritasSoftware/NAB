using System;
using System.Linq;
using System.Threading.Tasks;

namespace NAB.PetStore.Repository
{
    /// <summary>
    /// Class PetStoreManager
    /// </summary>
    public class PetStoreManager : IPetStoreManager
    {
        private readonly IPetStoreRepository _petStoreRepository;        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="petStoreRepository">The injected pet repository</param>
        public PetStoreManager(IPetStoreRepository petStoreRepository)
        {
            _petStoreRepository = petStoreRepository ?? throw new ArgumentNullException(nameof(petStoreRepository));
        }        

        /// <summary>
        /// Get Pets by Person's gender
        /// </summary>
        /// <param name="petType">The Pet type</param>
        /// <remarks>Throws ArgumentNullException</remarks>
        /// <returns><see cref="Task{PetsByPersonGenderCollection}"/></returns>
        public async Task<PetsByPersonGenderCollection> GetPetsByPersonGender(PetType petType)
        {
            var petStore = await _petStoreRepository.GetPetStoreAsync();

            //LINQ Query to get Pets by Person's gender and Pet type
            return new PetsByPersonGenderCollection()
            {
                PetsByPersonGender = petStore.ToList()
                                             .Where(person => person.Pets != null)
                                             .GroupBy(person => person.Gender)
                                             .Select(g => new PetsByPersonGender
                                             {
                                                 Gender = g.Key,
                                                 Pets = g.SelectMany(person => person.Pets.Where(pet => pet.Type == petType))
                                                                                          .OrderBy(x => x.Name)
                                             })
                                             .ToList()
            };
        }
    }
}
