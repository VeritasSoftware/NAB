using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NAB.PetStore.Repository
{
    /// <summary>
    /// Class PetStoreRepository
    /// </summary>
    public class PetStoreRepository : IPetStoreRepository
    {
        public string Path { get; set; }

        /// <summary>
        /// Get pet store async - reads the input file and deserializes json to object
        /// </summary>
        /// <returns><see cref="Task{Person[]}"/></returns>
        public async Task<Person[]> GetPetStoreAsync()
        {
            if (string.IsNullOrEmpty(this.Path))
            {
                throw new ArgumentNullException(nameof(this.Path));
            }

            string petStoreJson = await File.ReadAllTextAsync(this.Path);

            return JsonConvert.DeserializeObject<Person[]>(petStoreJson);
        }
    }
}
