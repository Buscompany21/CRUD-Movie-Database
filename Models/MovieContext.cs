using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_4_Assignment.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    Category = "Action/Adventure",
                    Title = "Batman",
                    Year = 1989,
                    Director = "Tim Burton",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieResponse
                {
                    Category = "Action/Adventure",
                    Title = "Die Hard",
                    Year = 1988,
                    Director = "John McTiernan",
                    Rating = "R",
                    Edited = true,
                    LentTo = "",
                    Notes = ""
                },
                new MovieResponse
                {
                    Category = "Action/Adventure",
                    Title = "Ocean's Eleven",
                    Year = 2001,
                    Director = "Steven Soderbergh",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
