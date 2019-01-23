using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NAB.PetStore.Repository;
using System;
using System.IO;
using System.Linq;

namespace NAB.PetStore
{
    class Program
    {
        static IServiceProvider serviceProvider;

        /// <summary>
        /// Add dependency injection
        /// </summary>
        /// <returns></returns>
        private static IServiceProvider AddDependencyInjection()
        {
            var services = new ServiceCollection();

            var settings = new Settings();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            configuration.Bind(settings);

            return services.AddScoped<IPetStoreRepository, PetStoreRepository>(x => new PetStoreRepository() { Path = settings.PetStoreFilePath })
                           .AddScoped<IPetStoreManager, PetStoreManager>()
                           .BuildServiceProvider();
                    
        }

        /// <summary>
        /// Print
        /// </summary>
        static void Print()
        {
            try
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

                results?.PetsByPersonGender.ToList().ForEach(x =>
                {
                    Console.WriteLine(x.Gender.ToString());

                    x.Pets.ToList().ForEach(p => Console.WriteLine($"\t{p.Name}"));
                });

                Console.WriteLine(Environment.NewLine);

                Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Shutting down...");
            }            
        }

        static string GetRepeatedString(string toRepeat, int noOfTimes)
        {
            return string.Concat(Enumerable.Repeat("*", noOfTimes));
        }

        static void PrintHeader()
        {
            Console.WriteLine(GetRepeatedString("*", 34));
            Console.WriteLine($"{GetRepeatedString("*", 5)}     NAB Pet Store!     {GetRepeatedString("*", 5)}");
            Console.WriteLine(GetRepeatedString("*", 34));
            Console.WriteLine(Environment.NewLine);
        }

        static void Main(string[] args)
        {           
            try
            {
                PrintHeader();

                serviceProvider = AddDependencyInjection();

                Print();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Shutting down...");
            }
        }
    }
}
