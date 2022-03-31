using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Models;

public class IngredientModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Ingridient name")]
    // [Range(1, 100, ErrorMessage = "cos nie tak")]
    public string Name { get; set; }

    public int Amount { get; set; } = 0;
    
    public int Calories { get; set; } = 0;
}