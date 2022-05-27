using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTime.Controllers;

[Authorize]
public class WelcomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}