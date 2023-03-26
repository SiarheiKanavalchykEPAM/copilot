# go to web project folder
cd ../bookDestributedLibrary.web

# add Microsoft.DotNet.Scaffolding.Shared tool
dotnet add package Microsoft.DotNet.Scaffolding.Shared --version 2.1.0

# Create models for User Login and Registration
dotnet aspnet-codegenerator identity -dc BookDestributedLibrary.Data.ApplicationDbContext --files "Account.Register;Account.Login"  -outDir Models/Identity

# add Microsoft.AspNetCore.Authentication.Google
dotnet add package Microsoft.AspNetCore.Authentication.Google --version 2.1.0

# add Microsoft.AspNetCore.Authentication.Facebook
dotnet add package Microsoft.AspNetCore.Authentication.Facebook --version 2.1.0

# add Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 2.1.0

# add Microsoft.Owin
dotnet add package Microsoft.Owin --version 4.0.0

# add Microsoft.AspNetCore.Authentication.OAuth
dotnet add package Microsoft.AspNetCore.Authentication.OAuth --version 2.1.0