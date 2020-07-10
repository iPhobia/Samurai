using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private static SamuraiContext context = new SamuraiContext();
        static void Main(string[] args)
        {
            // looks if database is created in current context, if not creates looking at context
            var isCreated = context.Database.EnsureCreated() ? "database is not created. Creating..." : "database is already created...";
            Console.WriteLine(isCreated);

            GetSamurais("Before add:");
            AddSamurais();
            GetSamurais("After add:");
        }

        private static void AddSamurais()
        {
            var samurai = new Samurai { Name = "Lyoha" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}\n\tSamurais count is {samurais.Count()}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
