using System.Collections.Generic;

namespace NAB.PetStore.Repository
{
    /// <summary>
    /// Class Pets By Person Gender
    /// </summary>
    public class PetsByPersonGender
    {
        public Gender Gender { get; set; }

        public IEnumerable<Pet> Pets { get; set; }
    }
}
