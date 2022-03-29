using Microsoft.AspNetCore.Identity;

namespace FoodTime.Areas.Identity.Data;

public class ApplicationRole : IdentityRole
{
    public string Name { get; set; }
    
    public string Description { get; set; }
}