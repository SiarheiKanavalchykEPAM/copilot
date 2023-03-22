# go to Web project folder
cd bookDestributedLibrary.Web

# Add Book Details page with controller and view
dotnet aspnet-codegenerator controller -name BookDetailsController --relativeFolderPath Controllers --useDefaultLayout

# Add Search Book page with controller and view
dotnet aspnet-codegenerator controller -name SearchBookController --relativeFolderPath Controllers --useDefaultLayout


