using Microsoft.AspNetCore.Mvc;

namespace FoodTime.Controllers;

public class WelcomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}