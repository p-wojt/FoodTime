#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodTime.Models;

namespace FoodTime.Data
{
    public class FoodTimeContext : DbContext
    {
        public FoodTimeContext (DbContextOptions<FoodTimeContext> options)
            : base(options)
        {
        }

        public DbSet<FoodTime.Models.MealModel> MealModel { get; set; }
    }
}
