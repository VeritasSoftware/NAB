using Newtonsoft.Json;

namespace NAB.PetStore.Repository
{   
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public PetType Type { get; set; }
    }
}
