﻿using GraduationProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GraduationProject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<BeverageIngredient> BeverageIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "ChuckNorris", Password = "NinjaKick", Email = "kickass@gmail.com" },
                new User { UserId = 2, UserName = "BruceLee", Password = "RoundHouseKick", Email = "iiiiiijjjaaa@hotmail.com" }
            );

            modelBuilder.Entity<Favorite>().HasData(
                new Favorite { FavoriteId = 1, UserId = 1, BeverageId = 1 },
                new Favorite { FavoriteId = 2, UserId = 2, BeverageId = 2 }
            );

            modelBuilder.Entity<Beverage>().HasData(
                new Beverage { BeverageId = 1, Name = "Potato Margarita", Tag = "ordinary", Alcohol = true, Instruction = "Shake it like a polaroid picture", Glass = "Martini Glass", Image = "http://potatomargarita.com" },
                new Beverage { BeverageId = 2, Name = "Tomato Martini", Tag = "cocktail", Alcohol = true, Instruction = "Stir it up", Glass = "Thumbler", Image = "http://tomatomartini.com" },
                new Beverage { BeverageId = 3, Name = "Brocoli Old Fashioned", Tag = "ordinary", Alcohol = false, Instruction = "On the grind", Glass = "Long glass", Image = "http://brocolioldfashined.com" }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Brocoli Liqueur", Description = "Great vegetable, quite bitter", Image = "http://brocoli.com" },
                new Ingredient { IngredientId = 2, Name = "Potato", Description = "Saved nations from famine", Image = "http://potato.com" },
                new Ingredient { IngredientId = 3, Name = "Tomato extract", Description = "The italian berry", Image = "http://tomato.com" }
            );

            modelBuilder.Entity<BeverageIngredient>().HasData(
                new BeverageIngredient { BeverageIngredientId = 1, BeverageId = 1, IngredientId = 1, Measurment = "60ml" },
                new BeverageIngredient { BeverageIngredientId = 2, BeverageId = 1, IngredientId = 2, Measurment = "One Slice" },
                new BeverageIngredient { BeverageIngredientId = 3, BeverageId = 1, IngredientId = 3, Measurment = "35ml" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
