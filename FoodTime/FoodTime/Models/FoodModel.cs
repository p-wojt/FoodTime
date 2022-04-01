using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodTime.Areas.Identity.Data;

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

    [ForeignKey("MealModelId")]
    public MealModel? MealModel { get; set; }

    [ForeignKey("ApplicationUserId")]
    public virtual ApplicationUser ApplicationUser { get; set; }

    public List<IngredientModel> Ingredients { get; set; }

    public FoodModel()
    {
        Ingredients = new List<IngredientModel>();
    }
}