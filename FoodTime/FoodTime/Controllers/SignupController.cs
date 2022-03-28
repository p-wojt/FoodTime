using Microsoft.AspNetCore.Mvc;

namespace FoodTime.Controllers;

public class SignupController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}