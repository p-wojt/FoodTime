using System.ComponentModel.DataAnnotations;

namespace FoodTime.Models;

public class MealModel
{
    [Key]
    public int Id { get; set; }
    [Required]   
    public string Name { get; set; }
}