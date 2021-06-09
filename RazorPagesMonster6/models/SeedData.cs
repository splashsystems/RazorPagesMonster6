using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMonster6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMonster6.models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMonster6Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMonster6Context>>()))
            {
                // Look for any monsters.
                if (context.Monster.Any())
                {
                    return;   // DB has been seeded
                }

                context.Monster.AddRange(
                    new Monster
                    {
                        MonsterName = "Sharp Edge",
                        ReleaseDate = DateTime.Parse("0050-1-1"),
                        Genre = "Accidental Danger",
                        Price = 4.00M,
                        Rating = "A"
                    },

                    new Monster
                    {
                        MonsterName = "Large Tree",
                        ReleaseDate = DateTime.Parse("0001-1-1"),
                        Genre = "Beauty in Place",
                        Price = 87000M,
                        Rating = "A"
                    },

                    new Monster
                    {
                        MonsterName = "Flap Jacks",
                        ReleaseDate = DateTime.Parse("1600-1-1"),
                        Genre = "Non-violent",
                        Price = 5.99M,
                        Rating = "A"
                    },

                    new Monster
                    {
                        MonsterName = "Party Face",
                        ReleaseDate = DateTime.Parse("1970-3-28"),
                        Genre = "Curiosities",
                        Price = 14.00M,
                        Rating = "A"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
