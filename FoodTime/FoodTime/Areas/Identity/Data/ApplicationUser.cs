using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FoodTime.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodTime.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [DisplayName("First name")]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [DisplayName("Last name")]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }


    public List<MealModel> UserMeals { get; set; }
    public List<FoodModel> UserFood { get; set; }

    public ApplicationUser()
    {
        UserMeals = new List<MealModel>();
        UserFood = new List<FoodModel>();
    }
}
