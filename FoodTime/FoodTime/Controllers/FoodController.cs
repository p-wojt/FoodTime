using FoodTime.Areas.Identity.Data;
using FoodTime.Data;
using FoodTime.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace FoodTime.Controllers;

[Authorize]
public class FoodController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FoodController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        ApplicationUser contextUser = await _userManager.GetUserAsync(User);
        ApplicationUser applicationUser = _db.Users.Where(x => x.Id == contextUser.Id).Include(x => x.UserFood)
            .FirstOrDefaultAsync().Result!;
        IEnumerable<FoodModel> food = applicationUser.UserFood;
        return View(food);
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
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            applicationUser = await _db.Users.Where(x => x.Id == applicationUser.Id)
                .Include(x => x.UserFood)
                .FirstOrDefaultAsync();


            int totalCalories = 0;
            foreach (var ingredient in food.Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            food.Calories = totalCalories;
            food.Name = food.Name.Trim();

            applicationUser.UserFood.Add(food);

            _db.Users.Update(applicationUser);
            _db.Food.Add(food);
            await _db.SaveChangesAsync();
            return RedirectToAction((nameof(Index)));
        }

        return View(food);
    }

    [HttpGet]
    public IActionResult FoodIngredients(long? foodId)
    {
        FoodModel foodModel = _db.Food
            .Where(x => x.Id == foodId)
            .Include(x => x.Ingredients)
            .FirstOrDefault();
        
        return View(foodModel.Ingredients);
    }
    
    
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
    
            var food = _db.Food.Find(id);
    
            if (food == null)
            {
                return NotFound();
            }
    
            return View(food);
        }


    [HttpPost, ActionName("Delete")] // jak request pod Delete to chodzi o ta metode
    [ValidateAntiForgeryToken]
    public IActionResult DeleteFood(int? id)
    {
        var food = _db.Food.Find(id);
        if (food == null)
        {
            return NotFound();
        }

        List<IngredientModel> ingredients = _db.Ingredient.Where(x => x.Id == food.Id).ToList();
        foreach (var ingredientModel in ingredients)
        {
            _db.Ingredient.Remove(ingredientModel);
        }
        _db.Food.Remove(food);
        _db.SaveChanges();
        TempData["success"] = "Food deleted successfuly"; // zostaje w memory na 1 redirect

        return RedirectToAction("Index");
    }
}