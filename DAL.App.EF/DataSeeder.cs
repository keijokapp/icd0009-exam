using System;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DAL.App.EF
{
    public static class DataSeeder
    {
        public static void SeedInitialData(AppDbContext ctx, UserManager<AppUser> userManager)
        {
            ctx.Authors.Add(new Author()
            {
                FirstName = "Isac",
                LastName = "Asimov",
            });
            ctx.Publishers.Add(new Publisher()
            {
                PublisherName = "DoubleDay"
            });
            ctx.SaveChanges();
            var appUser = new AppUser();
            appUser.Email = "a@a.ee";
            appUser.UserName = appUser.Email;

            var res = userManager.CreateAsync(appUser, "Password").Result;
            if (!res.Succeeded)
            {
                throw new Exception("Identity error");
            }
            ctx.SaveChanges();

            ctx.Books.Add(new Book()
            {
                Title = "Foundation",
                PublishingYear = 1965,
                AppUserId = 1,
                PublisherId =1, 
            });
            ctx.SaveChanges();

            ctx.BookAndAuthors.Add(new BookAndAuthor()
            {
                BookId = 1,
                AuthorId = 1,
            });
            ctx.SaveChanges();

            ctx.Comments.Add(new Comment()
            {
                BookId = 1,
                CommentBody = "Some comments are here!"
            });
            ctx.SaveChanges();

        }
    }
}