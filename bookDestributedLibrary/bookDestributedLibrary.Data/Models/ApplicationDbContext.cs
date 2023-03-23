using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Faker;

namespace bookDestributedLibrary.Data.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        // var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //         .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=book-library;Trusted_Connection=True;")
        //         .Options;
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<LoanHistory> LoanHistory { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ReservationQueue> ReservationQueues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Add 100 random Users using Faker
        for (int i = 1; i < 101; i++)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = i,
                Name = Faker.Name.FullName(),
                Email = Faker.User.Email(),
                Phone = Faker.Number.RandomNumber(1000000000, 9999999999).ToString(),
                City = Faker.Address.USCity(),
                Address = Faker.Address.SecondaryAddress()
            });
        }

        //Add 1000 random Books using Faker
        for (int i = 1; i < 1001; i++)
        {
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = i,
                Title = Faker.Lorem.Sentence(),
                Author = Faker.Name.FullName(),
                ISBN = Faker.Number.RandomNumber(1000000000, 9999999999).ToString(),
                PublicationDate = Faker.Date.Past(),
                Genres = Faker.Lorem.Sentence(),
                NumberOfPages = Faker.Number.RandomNumber(101, 1001),
                Tags = Faker.Lorem.Sentence(),
                ContributorId = Faker.Number.RandomNumber(1, 101),
                CurrentKeeperId = Faker.Number.RandomNumber(1, 101)
            });
        }

        //Add 1000 random LoanHistories using Faker
        for (int i = 1; i < 1001; i++)
        {
            modelBuilder.Entity<LoanHistory>().HasData(new LoanHistory
            {
                LoanId = i,
                BookId = Faker.Number.RandomNumber(1, 1001),
                UserId = Faker.Number.RandomNumber(1, 101),
                LoanDate = Faker.Date.Past(),
                DueDate = Faker.Date.Forward()
            });
        }

        //Add 1000 random ReservationQueues using Faker for only 20 random Books
        for (int i = 1; i < 1001; i++)
        {
            modelBuilder.Entity<ReservationQueue>().HasData(new ReservationQueue
            {
                ReservationId = i,
                BookId = Faker.Number.RandomNumber(1, 21),
                UserId = Faker.Number.RandomNumber(1, 101),
                ReservationDate = Faker.Date.Past()
            });
        }
    }
}
