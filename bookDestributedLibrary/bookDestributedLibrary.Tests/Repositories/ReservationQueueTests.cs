//Create tests for User Repository
// Path: bookDestributedLibrary\bookDestributedLibrary.Tests\UserRepositoryTests.cs
// Compare this snippet from bookDestributedLibrary\bookDestributedLibrary.Tests\UserRepositoryTests.cs:
using bookDestributedLibrary.Data.Models;
using bookDestributedLibrary.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace bookDestributedLibrary.Tests
{
    public class ReservationQueueTests
    {
        //Test for AddAsync method in ReservationQueueRepository
        [Fact]
        public async Task AddAsync_WithValidData_AddsEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync_WithValidData_AddsEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var reservationQueueRepository = new ReservationQueueRepository(context);
                var reservationQueue = new ReservationQueue
                {
                    BookId = 1,
                    UserId = 1,
                    ReservationDate = DateTime.Now
                };

                //Act
                var result = await reservationQueueRepository.AddAsync(reservationQueue);

                //Assert
                Assert.Equal(reservationQueue, result);
            }
        }

        //Test for DeleteAsync method in ReservationQueueRepository
        [Fact]
        public async Task DeleteAsync_WithValidId_DeletesEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteAsync_WithValidId_DeletesEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var reservationQueueRepository = new ReservationQueueRepository(context);
                var reservationQueue = new ReservationQueue
                {
                    BookId = 1,
                    UserId = 1,
                    ReservationDate = DateTime.Now
                };

                // add reservationQueue to dbcontext
                context.ReservationQueues.Add(reservationQueue);
                await context.SaveChangesAsync();

                //Act
                await reservationQueueRepository.DeleteAsync(reservationQueue.ReservationId);

                //Assert
                Assert.Empty(context.ReservationQueues);
            }
        }

        //Test for GetAllAsync method in ReservationQueueRepository
        [Fact]
        public async Task GetAllAsync_WithValidData_ReturnsAllEntities()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllAsync_WithValidData_ReturnsAllEntities")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var reservationQueueRepository = new ReservationQueueRepository(context);
                var reservationQueue = new ReservationQueue
                {
                    BookId = 1,
                    UserId = 1,
                    ReservationDate = DateTime.Now
                };
                //add more reservationQueues
                var reservationQueue2 = new ReservationQueue
                {
                    BookId = 2,
                    UserId = 2,
                    ReservationDate = DateTime.Now
                };
                var reservationQueue3 = new ReservationQueue
                {
                    BookId = 3,
                    UserId = 3,
                    ReservationDate = DateTime.Now
                };

                // add reservationQueue to dbcontext
                context.ReservationQueues.Add(reservationQueue);
                context.ReservationQueues.Add(reservationQueue2);
                context.ReservationQueues.Add(reservationQueue3);

                await context.SaveChangesAsync();

                //Act
                var result = await reservationQueueRepository.GetAllAsync();

                //Assert
                Assert.Equal(3, result.Count());
            }
        }

        //Test for GetByIdAsync method in ReservationQueueRepository
        [Fact]
        public async Task GetByIdAsync_WithValidId_ReturnsEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByIdAsync_WithValidId_ReturnsEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var reservationQueueRepository = new ReservationQueueRepository(context);
                var reservationQueue = new ReservationQueue
                {
                    BookId = 1,
                    UserId = 1,
                    ReservationDate = DateTime.Now
                };

                // add reservationQueue to dbcontext
                context.ReservationQueues.Add(reservationQueue);
                await context.SaveChangesAsync();

                //Act
                var result = await reservationQueueRepository.GetByIdAsync(reservationQueue.ReservationId);

                //Assert
                Assert.Equal(reservationQueue, result);
            }
        }

        //Test for UpdateAsync method in ReservationQueueRepository
        [Fact]
        public async Task UpdateAsync_WithValidData_UpdatesEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UpdateAsync_WithValidData_UpdatesEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var reservationQueueRepository = new ReservationQueueRepository(context);
                var reservationQueue = new ReservationQueue
                {
                    BookId = 1,
                    UserId = 1,
                    ReservationDate = DateTime.Now
                };

                // add reservationQueue to dbcontext
                context.ReservationQueues.Add(reservationQueue);
                await context.SaveChangesAsync();

                //Act
                reservationQueue.BookId = 2;
                await reservationQueueRepository.UpdateAsync(reservationQueue);

                //Assert
                Assert.Equal(2, reservationQueue.BookId);
            }
        }

        //Test for GetAllAsync method and filter by BookId in ReservationQueueRepository
        [Fact]
        public async Task GetAllAsync_WithValidDataAndFilterByBookId_ReturnsAllEntities()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllAsync_WithValidDataAndFilterByBookId_ReturnsAllEntities")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var reservationQueueRepository = new ReservationQueueRepository(context);
                var reservationQueue = new ReservationQueue
                {
                    BookId = 1,
                    UserId = 1,
                    ReservationDate = DateTime.Now
                };
                //add more reservationQueues
                var reservationQueue2 = new ReservationQueue
                {
                    BookId = 2,
                    UserId = 2,
                    ReservationDate = DateTime.Now
                };
                var reservationQueue3 = new ReservationQueue
                {
                    BookId = 3,
                    UserId = 3,
                    ReservationDate = DateTime.Now
                };

                // add reservationQueue to dbcontext
                context.ReservationQueues.Add(reservationQueue);
                context.ReservationQueues.Add(reservationQueue2);
                context.ReservationQueues.Add(reservationQueue3);

                await context.SaveChangesAsync();

                //Act
                var queue = await reservationQueueRepository.GetAllAsync();
                var result = queue.Where(x => x.BookId == 1);

                //Assert
                Assert.Equal(1, result.Count());
            }
        }
    }
}

