//Create tests for User Repository
// Path: bookDestributedLibrary\bookDestributedLibrary.Tests\UserRepositoryTests.cs
// Compare this snippet from bookDestributedLibrary\bookDestributedLibrary.Tests\UserRepositoryTests.cs:
using bookDestributedLibrary.Data.Models;
using bookDestributedLibrary.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace bookDestributedLibrary.Tests.Repositories
{
    public class LoanHistoryTests
    {
        //Test for AddAsync method in LoanHistoryRepository
        [Fact]
        public async Task AddAsync_WithValidEntity_ReturnsEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync_WithValidEntity_ReturnsEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var loanHistoryRepository = new LoanHistoryRepository(context);
                var loanHistory = new LoanHistory
                {
                    BookId = 1,
                    UserId = 1,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };

                //Act
                var result = await loanHistoryRepository.AddAsync(loanHistory);

                //Assert
                Assert.Equal(loanHistory, result);
            }
        }

        //Test for DeleteAsync method in LoanHistoryRepository
        [Fact]
        public async Task DeleteAsync_WithValidId_RemovesEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteAsync_WithValidId_RemovesEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var loanHistoryRepository = new LoanHistoryRepository(context);
                var loanHistory = new LoanHistory
                {
                    BookId = 1,
                    UserId = 1,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                //add more loanHistory
                var loanHistory2 = new LoanHistory
                {
                    BookId = 2,
                    UserId = 2,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };

                // add loanHistory to dbcontext
                context.LoanHistory.Add(loanHistory);
                context.LoanHistory.Add(loanHistory2);
                await context.SaveChangesAsync();

                //Act
                await loanHistoryRepository.DeleteAsync(loanHistory.LoanId);

                //Assert
                Assert.Equal(1, context.LoanHistory.Count());
            }
        }


        //Test for GetAllAsync method in LoanHistoryRepository
        [Fact]
        public async Task GetAllAsync_WithValidId_ReturnsLoanHistory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllAsync_WithValidId_ReturnsLoanHistory")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var loanHistoryRepository = new LoanHistoryRepository(context);
                var loanHistory = new LoanHistory
                {
                    BookId = 1,
                    UserId = 1,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                //add more loanHistory
                var loanHistory2 = new LoanHistory
                {
                    BookId = 2,
                    UserId = 2,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                var loanHistory3 = new LoanHistory
                {
                    BookId = 3,
                    UserId = 3,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };

                // add loanHistory to dbcontext
                context.LoanHistory.Add(loanHistory);
                context.LoanHistory.Add(loanHistory2);
                context.LoanHistory.Add(loanHistory3);
                await context.SaveChangesAsync();

                //Act
                var result = await loanHistoryRepository.GetAllAsync();

                //Assert
                Assert.Equal(3, result.Count());
            }
        }

        //Test for GetByIdAsync method in LoanHistoryRepository
        [Fact]
        public async Task GetByIdAsync_WithValidId_ReturnsLoanHistory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByIdAsync_WithValidId_ReturnsLoanHistory")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var loanHistoryRepository = new LoanHistoryRepository(context);
                var loanHistory = new LoanHistory
                {
                    BookId = 1,
                    UserId = 1,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                //add more loanHistory
                var loanHistory2 = new LoanHistory
                {
                    BookId = 2,
                    UserId = 2,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                var loanHistory3 = new LoanHistory
                {
                    BookId = 3,
                    UserId = 3,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };

                // add loanHistory to dbcontext
                context.LoanHistory.Add(loanHistory);
                context.LoanHistory.Add(loanHistory2);
                context.LoanHistory.Add(loanHistory3);
                await context.SaveChangesAsync();

                //Act
                var result = await loanHistoryRepository.GetByIdAsync(loanHistory2.LoanId);

                //Assert
                Assert.Equal(loanHistory2, result);
            }
        }

        //Test for UpdateAsync method in LoanHistoryRepository
        [Fact]
        public async Task UpdateAsync_WithValidEntity_ReturnsEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UpdateAsync_WithValidEntity_ReturnsEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var loanHistoryRepository = new LoanHistoryRepository(context);
                var loanHistory = new LoanHistory
                {
                    BookId = 1,
                    UserId = 1,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                //add more loanHistory
                var loanHistory2 = new LoanHistory
                {
                    BookId = 2,
                    UserId = 2,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                var loanHistory3 = new LoanHistory
                {
                    BookId = 3,
                    UserId = 3,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };

                // add loanHistory to dbcontext
                context.LoanHistory.Add(loanHistory);
                context.LoanHistory.Add(loanHistory2);
                context.LoanHistory.Add(loanHistory3);
                await context.SaveChangesAsync();

                //Act
                var result = await loanHistoryRepository.UpdateAsync(loanHistory2);

                //Assert
                Assert.Equal(loanHistory2, result);
            }
        }

        //Test for GetAllAsync method and filter by BookId in LoanHistoryRepository
        [Fact]
        public async Task GetAllAsync_WithValidBookId_ReturnsLoanHistory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllAsync_WithValidBookId_ReturnsLoanHistory")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var loanHistoryRepository = new LoanHistoryRepository(context);
                var loanHistory = new LoanHistory
                {
                    BookId = 1,
                    UserId = 1,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                //add more loanHistory
                var loanHistory2 = new LoanHistory
                {
                    BookId = 2,
                    UserId = 2,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };
                var loanHistory3 = new LoanHistory
                {
                    BookId = 3,
                    UserId = 3,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };

                // add loanHistory to dbcontext
                context.LoanHistory.Add(loanHistory);
                context.LoanHistory.Add(loanHistory2);
                context.LoanHistory.Add(loanHistory3);
                await context.SaveChangesAsync();

                //Act
                var history = await loanHistoryRepository.GetAllAsync();

                var result = history.Where(x => x.BookId == 2);

                //Assert
                Assert.Equal(1, result.Count());
            }
        }

    }
}

