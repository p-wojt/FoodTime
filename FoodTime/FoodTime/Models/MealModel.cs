using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Models;

public class MealModel
{
    [Key]
    public int Id { get; set; }
    [Required]   
    [DisplayName("Meal name")]
    // [Range(1, 100, ErrorMessage = "cos nie tak")]
    public string Name { get; set; }
}