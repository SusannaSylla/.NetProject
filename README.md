# Book web application 2021 Susanna Sülla

Vajalikud toimingud CRUD lehtede ehitmaise ja ORM (Entity Framework) toimimiseks

CRUD lehtede genereerimiseks vaja installida

~~~
dotnet tool install --global dotnet-aspnet-codegenerator
  or
dotnet tool update --global dotnet-aspnet-codegenerator
  or
dotnet tool update --global dotnet-ef
~~~

Installi "KooliProjekt" projektis olles (nuget) 

~~~
Microsoft.EntityFrameworkCore.Design
Microsoft.VisualStudio.Web.CodeGeneration.Design
Microsoft.EntityFrameworkCore.SqlServer
~~~

Lisa andmebaasi ühenduse string appsettings.json
~~~
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=my.db"
  },
~~~


Genereeri "razor pages" lehed CRUD toimingute jaoks
(Käivita WebApp kaustas)
~~~
dotnet aspnet-codegenerator razorpage -m Author -outDir Pages/Authors -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m Book -outDir Pages/Books -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m BookAuthor -outDir Pages/BookAuthors -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m Comment -outDir Pages/Comments -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m Publisher -outDir Pages/Publishers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
~~~
