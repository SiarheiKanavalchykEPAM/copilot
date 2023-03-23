#Create bookDestributedLibrary solution folder
mkdir bookDestributedLibrary
cd bookDestributedLibrary

# Create MVC ASP .NET Core application with 3 layer architecture (Presentation, Application, Data).
dotnet new webapp -o bookDestributedLibrary.Web
dotnet new classlib -o bookDestributedLibrary.Application
dotnet new classlib -o bookDestributedLibrary.Data

# create MVC ASP .NET Core solution
dotnet new sln

# Add projects to solution
dotnet sln add bookDestributedLibrary.Web/bookDestributedLibrary.Web.csproj
dotnet sln add bookDestributedLibrary.Application/bookDestributedLibrary.Application.csproj
dotnet sln add bookDestributedLibrary.Data/bookDestributedLibrary.Data.csproj

# Add reference to bookDestributedLibrary.Application project from bookDestributedLibrary.Web project
dotnet add bookDestributedLibrary.Web/bookDestributedLibrary.Web.csproj reference bookDestributedLibrary.Application/bookDestributedLibrary.Application.csproj

# Add reference to bookDestributedLibrary.Data project from bookDestributedLibrary.Application project
dotnet add bookDestributedLibrary.Application/bookDestributedLibrary.Application.csproj reference bookDestributedLibrary.Data/bookDestributedLibrary.Data.csproj

# Add reference to bookDestributedLibrary.Data project from bookDestributedLibrary.Web project
dotnet add bookDestributedLibrary.Web/bookDestributedLibrary.Web.csproj reference bookDestributedLibrary.Data/bookDestributedLibrary.Data.csproj

# Add xUnit Test project to the solution.
dotnet new xunit -o bookDestributedLibrary.Tests
dotnet sln add bookDestributedLibrary.Tests/bookDestributedLibrary.Tests.csproj

# Add reference to bookDestributedLibrary.Application project from bookDestributedLibrary.Tests project
dotnet add bookDestributedLibrary.Tests/bookDestributedLibrary.Tests.csproj reference bookDestributedLibrary.Application/bookDestributedLibrary.Application.csproj

# Add reference to bookDestributedLibrary.Data project from bookDestributedLibrary.Tests project
dotnet add bookDestributedLibrary.Tests/bookDestributedLibrary.Tests.csproj reference bookDestributedLibrary.Data/bookDestributedLibrary.Data.csproj

# Add reference to bookDestributedLibrary.Web project from bookDestributedLibrary.Tests project
dotnet add bookDestributedLibrary.Tests/bookDestributedLibrary.Tests.csproj reference bookDestributedLibrary.Web/bookDestributedLibrary.Web.csproj

# Add reference to Microsoft.AspNetCore.Mvc.Testing package to the project as a NuGet package reference
dotnet add bookDestributedLibrary.Tests/bookDestributedLibrary.Tests.csproj package Microsoft.AspNetCore.Mvc.Testing

# Use Entity Framework Core as ORM. Use SQL Server as database.
dotnet add bookDestributedLibrary.Data/bookDestributedLibrary.Data.csproj package Microsoft.EntityFrameworkCore.SqlServer

# Add reference to Microsoft.EntityFrameworkCore.Design package to the project as a NuGet package reference
dotnet add bookDestributedLibrary.Data/bookDestributedLibrary.Data.csproj package Microsoft.EntityFrameworkCore.Design

# Add reference to Microsoft.EntityFrameworkCore.Tools package to the project as a NuGet package reference
dotnet add bookDestributedLibrary.Data/bookDestributedLibrary.Data.csproj package Microsoft.EntityFrameworkCore.Tools
---------------------------------------------------------------------------------------------------------------------------------------------
# Go to Deta project folder
cd bookDestributedLibrary.Data

# Install dotnet-ef tool
dotnet tool install --global dotnet-ef

# create DbContext
dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=book-library;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c ApplicationDbContext

# go to Web project folder
cd bookDestributedLibrary.Web

# Add Book Details page with controller and view
dotnet aspnet-codegenerator controller -name BookDetailsController --relativeFolderPath Controllers --useDefaultLayout

# Add Search Book page with controller and view
dotnet aspnet-codegenerator controller -name SearchBookController --relativeFolderPath Controllers --useDefaultLayout


