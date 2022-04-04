﻿using FoodTime.Areas.Identity.Data;
using FoodTime.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodTime.Data;

public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }


    public DbSet<ApplicationUser> Users { get; set; }

    //Create table with name Meals
    public DbSet<MealModel> Meals { get; set; }

    public DbSet<FoodModel> Food { get; set; }

    public DbSet<IngredientModel> Ingredient { get; set; }
}