# go to Data project folder
cd bookDestributedLibrary.Data

# create migration
dotnet ef migrations add InitialCreate

# Update database according to the changes in the model
dotnet ef database update

# Create repository folder
mkdir Repositories

# go to test project folder
cd ..\bookDestributedLibrary.Tests

# add Microsoft.EntityFrameworkCore.InMemory package
dotnet add package Microsoft.EntityFrameworkCore.InMemory

#run DeleteAsyncShouldDeleteBook test
dotnet test --filter FullyQualifiedName=bookDestributedLibrary.Tests.BookRepositoryTests.DeleteAsyncShouldDeleteBook

