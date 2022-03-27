using FoodTime.Data;
using FoodTime.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodTime.Controllers;

public class MealController : Controller
{
    private readonly ApplicationDbContext _db;

    public MealController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<MealModel> objMealList = _db.Meals;
        return View(objMealList);
    }
}