using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission06_adfish.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options) : base (options)
        {

        }


        public DbSet<Movie> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder ab)
        {
            ab.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryID = 2, CategoryName = "Comedy"},
                new Category { CategoryID = 3, CategoryName = "Drama"},
                new Category { CategoryID = 4, CategoryName = "Family"},
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense"},
                new Category { CategoryID = 6, CategoryName = "Television"},
                new Category { CategoryID = 7, CategoryName = "Miscellaneous"},
                new Category { CategoryID = 8, CategoryName = "VHS"}
            );
        }
    }
}
