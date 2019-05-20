#!/bin/sh

cd WebApp

dotnet aspnet-codegenerator controller -name AuthorsController -actions -m Author -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name BookAndAuthorsController -actions -m BookAndAuthor -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name BooksController -actions -m Book -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name CommentsController -actions -m Comment -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name PublishersController -actions -m Publisher -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
