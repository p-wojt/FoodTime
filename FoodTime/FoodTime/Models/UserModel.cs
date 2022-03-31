using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Models;

public class UserModel
{
    [Key]
    public int Id { get; set; }
    [DisplayName("First name")]
    public string Firstname { get; set; }
    [DisplayName("Last name")]
    public string Lastname { get; set; }
    public List<MealModel> Usermeals { get; set; }
    public List<FoodModel> Userfoods { get; set; }
}