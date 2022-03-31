using FoodTime.Data;
using FoodTime.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTime.Controllers;

public class FoodController : Controller
{
    private readonly ApplicationDbContext _db;

    public FoodController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<ActionResult> AddIngredient([Bind("Ingredients")] FoodModel food)
    {
        food.Ingredients.Add(new IngredientModel());
        return PartialView("IngredientItems", food);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Calories,Ingredients")] FoodModel food)
    {
        if (ModelState.IsValid)
        {
            int totalCalories = 0;
            foreach (var ingredient in food.Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            food.Calories = totalCalories;
            food.Name = food.Name.Trim();
            _db.Add(food);
            await _db.SaveChangesAsync();
            return RedirectToAction((nameof(Index)));
        }

        return View(food);
    }
}