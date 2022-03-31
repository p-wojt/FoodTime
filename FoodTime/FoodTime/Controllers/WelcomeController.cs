using Microsoft.AspNetCore.Mvc;

namespace FoodTime.Controllers;

[Authorize]
public class WelcomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}