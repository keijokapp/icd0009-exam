using System;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DAL.App.EF
{
    public static class DataSeeder
    {
        public static void SeedInitialData(AppDbContext ctx, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var transportCategory = new Category
            {
                Name = "Transport",
                Type = CategoryType.Transport
            };

            var foodCategory = new Category
            {
                Name = "Food",
                Type = CategoryType.Food
            };

            var otherCategory = new Category
            {
                Name = "Other",
                Type = CategoryType.General
            };

            var toppingCategory = new Category
            {
                Name = "Topping",
                Type = CategoryType.Topping
            };


            ctx.Category.Add(transportCategory);
            ctx.Category.Add(foodCategory);
            ctx.Category.Add(otherCategory);
            ctx.Category.Add(toppingCategory);

            ctx.Products.Add(new Product
            {
                Name = "pizza",
                Category = foodCategory,
                Price = 2400
            });

            
            ctx.Products.Add(new Product
            {
                Name = "asdasda",
                Category = foodCategory,
                Price = 2400
            });

            
            ctx.Products.Add(new Product
            {
                Name = "koerapasteet",
                Category = toppingCategory,
                Price = 2400
            });
 
            var role = new AppRole
            {
                NormalizedName = "Admin",
                Name = "Admin"
            };

            roleManager.CreateAsync(role).Wait();

            var user = new AppUser
            {
                UserName = "keijokapp",
                Email = "keijo.kapp@gmail.com"
            };

            var success = userManager.CreateAsync(user, "Passw0rd").Result;
            if (success != IdentityResult.Success)
            {
                throw new Exception("shit");
            }
            userManager.AddToRoleAsync(user, "Admin").Wait();

            ctx.SaveChanges();
        }
    }
}