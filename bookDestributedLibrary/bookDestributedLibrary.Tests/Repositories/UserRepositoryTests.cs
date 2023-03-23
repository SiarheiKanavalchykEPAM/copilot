//Create tests for User Repository
// Path: bookDestributedLibrary\bookDestributedLibrary.Tests\UserRepositoryTests.cs
// Compare this snippet from bookDestributedLibrary\bookDestributedLibrary.Tests\UserRepositoryTests.cs:
using bookDestributedLibrary.Data.Models;
using bookDestributedLibrary.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace bookDestributedLibrary.Tests.Repositories
{
    public class UserRepositoryTests
    {
        //Test for AddAsync method in UserRepository
        [Fact]
        public async Task AddAsync_WithValidEntity_ReturnsEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync_WithValidEntity_ReturnsEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);
                var user = new User
                {
                    Name = "TestName",
                    Email = "TestEmail",
                    Phone = "TestPhone",
                    City = "TestCity",
                    Address = "TestAddress"
                };

                //Act
                var result = await userRepository.AddAsync(user);

                //Assert
                Assert.Equal(user, result);
            }
        }

        //Test for DeleteAsync method in UserRepository
        [Fact]
        public async Task DeleteAsync_WithValidId_RemovesEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteAsync_WithValidId_RemovesEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);
                var user = new User
                {
                    Name = "TestName",
                    Email = "TestEmail",
                    Phone = "TestPhone",
                    City = "TestCity",
                    Address = "TestAddress"
                };

                // add user to dbcontext
                context.Users.Add(user);
                await context.SaveChangesAsync();

                await userRepository.DeleteAsync(user.UserId);

                //Act
                var result = await context.Users.FirstOrDefaultAsync();

                //Assert
                Assert.Null(result);
            }
        }

        //Test for GetAllAsync method in UserRepository
        [Fact]
        public async Task GetAllAsync_WithValidData_ReturnsAllUsers()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllAsync_WithValidData_ReturnsAllUsers")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);
                var user = new User
                {
                    Name = "TestName",
                    Email = "TestEmail",
                    Phone = "TestPhone",
                    City = "TestCity",
                    Address = "TestAddress"
                };

                // add user to dbcontext
                context.Users.Add(user);
                await context.SaveChangesAsync();

                //Act
                var result = await userRepository.GetAllAsync();

                //Assert
                Assert.Equal(1, result.Count());
            }
        }

        //Test for GetByIdAsync method in UserRepository
        [Fact]
        public async Task GetByIdAsync_WithValidId_ReturnsUser()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByIdAsync_WithValidId_ReturnsUser")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);
                var user = new User
                {
                    Name = "TestName",
                    Email = "TestEmail",
                    Phone = "TestPhone",
                    City = "TestCity",
                    Address = "TestAddress"
                };
                //add more users
                var user2 = new User
                {
                    Name = "TestName2",
                    Email = "TestEmail2",
                    Phone = "TestPhone2",
                    City = "TestCity2",
                    Address = "TestAddress2"
                };
                var user3 = new User
                {
                    Name = "TestName3",
                    Email = "TestEmail3",
                    Phone = "TestPhone3",
                    City = "TestCity3",
                    Address = "TestAddress3"
                };

                // add user to dbcontext
                context.Users.Add(user);
                context.Users.Add(user2);
                context.Users.Add(user3);

                await context.SaveChangesAsync();

                //Act
                var result = await userRepository.GetByIdAsync(user.UserId);

                //Assert
                Assert.Equal(user, result);
            }
        }

        //Test for UpdateAsync method in UserRepository
        [Fact]
        public async Task UpdateAsync_WithValidEntity_ReturnsEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UpdateAsync_WithValidEntity_ReturnsEntity")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);
                var user = new User
                {
                    Name = "TestName",
                    Email = "TestEmail",
                    Phone = "TestPhone",
                    City = "TestCity",
                    Address = "TestAddress"
                };

                // add user to dbcontext
                context.Users.Add(user);
                await context.SaveChangesAsync();

                //Act
                user.Name = "TestName2";
                var result = await userRepository.UpdateAsync(user);

                //Assert
                Assert.Equal(user.Name, result.Name);
            }
        }

        //Test for GetAllAsync method and filter by name in UserRepository
        [Fact]
        public async Task GetAllAsync_WithValidDataAndFilterByName_ReturnsAllUsers()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllAsync_WithValidDataAndFilterByName_ReturnsAllUsers")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);
                var user = new User
                {
                    Name = "TestName",
                    Email = "TestEmail",
                    Phone = "TestPhone",
                    City = "TestCity",
                    Address = "TestAddress"
                };
                //add more users
                var user2 = new User
                {
                    Name = "TestName2",
                    Email = "TestEmail2",
                    Phone = "TestPhone2",
                    City = "TestCity2",
                    Address = "TestAddress2"
                };
                var user3 = new User
                {
                    Name = "TestName3",
                    Email = "TestEmail3",
                    Phone = "TestPhone3",
                    City = "TestCity3",
                    Address = "TestAddress3"
                };


                // add user to dbcontext
                context.Users.Add(user);
                context.Users.Add(user2);
                context.Users.Add(user3);

                await context.SaveChangesAsync();

                //Act
                var users = await userRepository.GetAllAsync();
                var result = users.Where(u => u.Name == "TestName2");

                //Assert
                Assert.Equal(1, result.Count());
            }
        }
    }
}

