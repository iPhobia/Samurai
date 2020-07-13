using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            // looks if database is created in current context, if not creates looking at context
            //var isCreated = _context.Database.EnsureCreated() ? "database is not created. Creating..." : "database is already created...";
            //Console.WriteLine(isCreated);

            //GetSamurais("Before add:");
            //AddSamurai();
            //InsertMultipleSamurais();
            //InsertDifferentTables();
            //GetSamurais("After add:");
            QueryFilters();
        }

        private static void QueryFilters()
        {
            var name = "Pasha";
            var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "P%")).ToList();
        }

        private static void InsertDifferentTables()
        {
            var samurai = new Samurai { Name = "Idiot" };
            var clan = new Clan { ClanName = "Imperial" };
            _context.AddRange(samurai, clan);
            _context.SaveChanges();
        }

        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Pasha" };
            var samurai2 = new Samurai { Name = "Denis" };
            var samurai3 = new Samurai { Name = "Vasya" };
            var samurai4 = new Samurai { Name = "Kolya" };
            _context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4);
            _context.SaveChanges();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Lyoha" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text}\n\tSamurais count is {samurais.Count()}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
