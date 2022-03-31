using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Models;

public class FoodModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Food name")]
    // [Range(1, 100, ErrorMessage = "cos nie tak")]
    public string Name { get; set; }

    public int Calories { get; set; }

    public List<IngredientModel> Ingredients { get; set; }

    public FoodModel()
    {
        Ingredients = new List<IngredientModel>();
    }
}