using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext //DbContext is a built-in class inside EntityFrameworkCore.This class has to inherit this DbContext for proper database connection
    {

        //add some configuration
        //whatever configuration is added here, it is passed to the base class of DbContext.
        //That is why we write base(options)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //To create a table here, we have to create a DbSet
        public DbSet<Category> Categories { get; set; } //This one line will create a table Categories in the database
                                                        //having Category as the model 
        //After this, we have to do migration to create the table
        //In package manager console -> add-migration AddCategoryTableToDb (any meaningful name)
        //update-database ->adds the table to sql server
        //remove-migration -> undo changes you just migrated

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );
        }
    }
}
