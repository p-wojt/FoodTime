using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Models;

public class IngredientModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Ingredient name")]
    public string Name { get; set; }

    public string Amount { get; set; }
    
    public int Calories { get; set; } = 0;
}