using Microsoft.Extensions.DependencyInjection;
using NAB.PetStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAB.PetStore
{
    class Program
    {
        static IServiceProvider serviceProvider;

        private static IServiceProvider AddDependencyInjection()
        {
            var services = new ServiceCollection();

            return services.AddScoped<IPetStoreRepository, PetStoreRepository>(x => new PetStoreRepository() { Path = "./Pet.json" })
                           .AddScoped<IPetStoreManager, PetStoreManager>()
                           .BuildServiceProvider();
                    
        }

        static void Print()
        {
            Console.WriteLine("Select pet type: 1-Dog, 2-Cat, 3-Fish\r\nAny other key to quit..");

            var input = Console.ReadKey();

            if (input.Key != ConsoleKey.D1 && input.Key != ConsoleKey.D2 && input.Key != ConsoleKey.D3)
            {
                return;
            }

            Console.WriteLine(Environment.NewLine);

            var petType = (PetType)Enum.Parse(typeof(PetType), new string(new char[] { input.KeyChar }));            

            var petStoreManager = serviceProvider.GetRequiredService<IPetStoreManager>();

            var results = petStoreManager.GetPetsByPersonGender(petType).Result;

            results.PetsByPersonGender.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Gender.ToString());

                x.Pets.ToList().ForEach(p => Console.WriteLine($"\t{p.Name}"));
            });

            Console.WriteLine(Environment.NewLine);

            Print();
        }

        static string GetRepeatedString(string toRepeat, int noOfTimes)
        {
            return string.Concat(Enumerable.Repeat("*", noOfTimes));
        }

        static void Main(string[] args)
        {           
            try
            {
                Console.WriteLine(GetRepeatedString("*", 34));
                Console.WriteLine($"{GetRepeatedString("*", 5)}     NAB Pet Store!     {GetRepeatedString("*", 5)}");
                Console.WriteLine(GetRepeatedString("*", 34));
                Console.WriteLine(Environment.NewLine);

                serviceProvider = AddDependencyInjection();

                Print();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Print();
            }
        }
    }
}
