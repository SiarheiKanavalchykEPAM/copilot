//Create tests for Book Repository
//
// Path: bookDestributedLibrary\bookDestributedLibrary.Tests\BookRepositoryTests.cs
// Compare this snippet from bookDestributedLibrary\bookDestributedLibrary.Tests\BookRepositoryTests.cs:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookDestributedLibrary.Data.Models;
using bookDestributedLibrary.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace bookDestributedLibrary.Tests.Repositories
{
    public class BookRepositoryTests
    {
        //Test for AddAsync method in BookRepository
        [Fact]
        public async Task AddAsyncShouldAddBook()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsyncShouldAddBook")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repo = new BookRepository(context);
                var book = new Book
                {
                    Title = "Hobbit",
                    Author = "Tolkien",
                    ISBN = "123456789",
                    PublicationDate = new DateTime(1937, 9, 21),
                    Genres = "Fantasy",
                    NumberOfPages = 310,
                    Tags = "Adventure, Fantasy, Magic"
                };
                //Act
                await repo.AddAsync(book);
                //Assert
                var result = await context.Books.FirstOrDefaultAsync();
                Assert.Equal(book.Title, result.Title);
                Assert.Equal(book.Author, result.Author);
                Assert.Equal(book.ISBN, result.ISBN);
                Assert.Equal(book.PublicationDate, result.PublicationDate);
                Assert.Equal(book.Genres, result.Genres);
                Assert.Equal(book.NumberOfPages, result.NumberOfPages);
                Assert.Equal(book.Tags, result.Tags);
            }
        }

        //Test for DeleteAsync method in BookRepository
        [Fact]
        public async Task DeleteAsyncShouldDeleteBook()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteAsyncShouldDeleteBook")
                .Options;
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new BookRepository(context);
                var book = new Book
                {
                    Title = "Hobbit",
                    Author = "Tolkien",
                    ISBN = "123456789",
                    PublicationDate = new DateTime(1937, 9, 21),
                    Genres = "Fantasy",
                    NumberOfPages = 310,
                    Tags = "Adventure, Fantasy, Magic"
                };
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();

                //Get Id from book
                var bookId = book.BookId;
                //Act
                await repo.DeleteAsync(bookId);
                //Assert
                var result = await context.Books.FirstOrDefaultAsync();
                Assert.Null(result);
            }
        }

        //Test for UpdateAsync method in BookRepository
        [Fact]
        public async Task UpdateAsyncShouldUpdateBook()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UpdateAsyncShouldUpdateBook")
                .Options;
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new BookRepository(context);
                var book = new Book
                {
                    Title = "Hobbit",
                    Author = "Tolkien",
                    ISBN = "123456789",
                    PublicationDate = new DateTime(1937, 9, 21),
                    Genres = "Fantasy",
                    NumberOfPages = 310,
                    Tags = "Adventure, Fantasy, Magic"
                };
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();

                //Act
                book.Title = "Lord of the Rings";
                await repo.UpdateAsync(book);
                //Assert
                var result = await context.Books.FirstOrDefaultAsync();
                Assert.Equal(book.Title, result.Title);
            }
        }            

        //Test for GetBookByIdAsync method in BookRepository
        [Fact]
        public async Task GetBookByIdAsyncShouldReturnBook()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetBookByIdAsyncShouldReturnBook")
                .Options;
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new BookRepository(context);
                var book = new Book
                {
                    Title = "Hobbit",
                    Author = "Tolkien",
                    ISBN = "123456789",
                    PublicationDate = new DateTime(1937, 9, 21),
                    Genres = "Fantasy",
                    NumberOfPages = 310,
                    Tags = "Adventure, Fantasy, Magic"
                };
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();

                //Act
                var result = await repo.GetByIdAsync(book.BookId);
                //Assert
                Assert.Equal(book.Title, result.Title);
                Assert.Equal(book.Author, result.Author);
                Assert.Equal(book.ISBN, result.ISBN);
                Assert.Equal(book.PublicationDate, result.PublicationDate);
                Assert.Equal(book.Genres, result.Genres);
                Assert.Equal(book.NumberOfPages, result.NumberOfPages);
                Assert.Equal(book.Tags, result.Tags);
            }
        }

        //Test for GetBooksAsync method in BookRepository
        [Fact]
        public async Task GetBooksAsyncShouldReturnAllBooks()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetBooksAsyncShouldReturnAllBooks")
                .Options;
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new BookRepository(context);
                var book1 = new Book
                {
                    Title = "Hobbit",
                    Author = "Tolkien",
                    ISBN = "123456789",
                    PublicationDate = new DateTime(1937, 9, 21),
                    Genres = "Fantasy",
                    NumberOfPages = 310,
                    Tags = "Adventure, Fantasy, Magic"
                };
                var book2 = new Book
                {
                    Title = "Lord of the Rings",
                    Author = "Tolkien",
                    ISBN = "987654321",
                    PublicationDate = new DateTime(1954, 7, 29),
                    Genres = "Fantasy",
                    NumberOfPages = 1216,
                    Tags = "Adventure, Fantasy, Magic"
                };
                await context.Books.AddAsync(book1);
                await context.Books.AddAsync(book2);
                await context.SaveChangesAsync();

                //Act
                var result = await repo.GetAllAsync();
                //Assert
                Assert.Equal(2, result.Count());
            }
        }

        //Test for GetBooksAsync method and then filter using Linq by Author in BookRepository
        [Fact]
        public async Task GetBooksAsyncShouldReturnBooksByAuthor()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetBooksAsyncShouldReturnBooksByAuthor")
                .Options;
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new BookRepository(context);
                var book1 = new Book
                {
                    Title = "Hobbit",
                    Author = "Tolkien",
                    ISBN = "123456789",
                    PublicationDate = new DateTime(1937, 9, 21),
                    Genres = "Fantasy",
                    NumberOfPages = 310,
                    Tags = "Adventure, Fantasy, Magic"
                };
                var book2 = new Book
                {
                    Title = "Lord of the Rings",
                    Author = "Tolkien",
                    ISBN = "987654321",
                    PublicationDate = new DateTime(1954, 7, 29),
                    Genres = "Fantasy",
                    NumberOfPages = 1216,
                    Tags = "Adventure, Fantasy, Magic"
                };
                //Add more books
                var book3 = new Book
                {
                    Title = "The Hobbit or There and Back Again",
                    Author = "Henry Kuttner",
                    ISBN = "123456789",
                    PublicationDate = new DateTime(1937, 9, 21),
                    Genres = "Fantasy",
                    NumberOfPages = 310,
                    Tags = "Adventure, Fantasy, Magic"
                };
                var book4 = new Book
                {
                    Title = "Children of Hurin",
                    Author = "Konan Doji",
                    ISBN = "987654321",
                    PublicationDate = new DateTime(1954, 7, 29),
                    Genres = "Fantasy",
                    NumberOfPages = 1216,
                    Tags = "Adventure, Fantasy, Magic"
                };
                await context.Books.AddAsync(book1);
                await context.Books.AddAsync(book2);
                await context.Books.AddAsync(book3);
                await context.Books.AddAsync(book4);
                await context.SaveChangesAsync();

                //Act
                var result = await repo.GetAllAsync();
                var filteredResult = result.Where(b => b.Author == "Tolkien").ToList();
                //Assert
                Assert.Equal(2, filteredResult.Count());
            }
        }

        
    }
}