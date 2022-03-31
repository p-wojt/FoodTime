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

    public int Calories { get; set; } = 0;
    
    public DayOfWeek Day { get; set; }
    
    public TimeOnly time { get; set; }
    
    public List<FoodModel> Food { get; set; }
}