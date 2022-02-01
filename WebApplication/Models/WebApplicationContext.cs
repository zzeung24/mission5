using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication.Models
{
    public class WebApplicationContext : DbContext
    {
        //Constructor
        public WebApplicationContext(DbContextOptions<WebApplicationContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );




            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryId = 1,
                    Title = "Avengers, The",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryId = 1,
                    Title = "Batman",
                    Year = 1989,
                    Director = "Tim Burton",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                ApplicationId = 3,
                    CategoryId = 1,
                    Title = "Batman & Robin",
                    Year = 1997,
                    Director = "Joel Schumacher",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    ApplicationId = 4,
                    CategoryId = 2,
                    Title = "Mystery Men",
                    Year = 1999,
                    Director = "Kinka Usher",
                    Rating = "PG-13",
                    Edited = false
                }


            );
        }
    }
}
