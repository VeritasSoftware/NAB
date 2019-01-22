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

        public async Task<Person[]> GetPetStore()
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
