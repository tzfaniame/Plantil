using System;
using System.Linq;
using Plantil.Domain.Entities;
using Plantil.Data;

namespace Plantil.ConsoleApp
{
    internal class Program
    {
        private static PlantContext context = new PlantContext();

        private static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            GetPlants("Before Add:");
            AddPlant();
            GetPlants("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddPlant()
        {
            var Plant = new Plant { Name = "Sampson" };
            context.Plants.Add(Plant);
            context.SaveChanges();
        }

        private static void GetPlants(string text)
        {
            var Plants = context.Plants.ToList();
            Console.WriteLine($"{text}: Plant count is {Plants.Count}");
            foreach (var Plant in Plants)
            {
                Console.WriteLine(Plant.Name);
            }
        }
    }
}
