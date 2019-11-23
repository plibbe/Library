using Library.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.EntityFrameworkCore
{
    public class LibraryDbContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer { FirstName = "Harry", LastName = "Potter", Id = 1 });
            modelBuilder.Entity<Customer>().HasData(new Customer { FirstName = "Ronald", LastName = "Weasley", Id = 2 });
            modelBuilder.Entity<Customer>().HasData(new Customer { FirstName = "Hermione", LastName = "Granger", Id = 3 });

            var author = new Author { FirstName = "Joanne", LastName = "Rowling", Id = 1 };

            modelBuilder.Entity<Author>().HasData(author);

            modelBuilder.Entity<Book>().HasData(new Book { Id = 1, Title = "Harry potter och de vises sten", Description = $"Första boken i Harry Potter serien", AuthorId = author.Id});

            base.OnModelCreating(modelBuilder);
        }
    }
}
