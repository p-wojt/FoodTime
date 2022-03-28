using FoodTime.Areas.Identity.Data;
using FoodTime.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTime.Data;

public class ApplicationDbContext :DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    //Create table with name Meals
    public DbSet<MealModel> Meals { get; set; }
    
    public DbSet<ApplicationUser> Users { get; set; }
}