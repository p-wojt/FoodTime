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

    //GET
    public IActionResult Create()
    {
        return View();
    }
    
    //POST
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(MealModel obj)
    {
        /*if (obj.Name == obj.DisplayOrder.ToString()) Custom Validation
        {
            ModelState.AddModelError(("name", "The DisplayOrder cannot exaclty match the Name."));
        }*/
        if (ModelState.IsValid)
        {
            _db.Meals.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index"); // jak w innym kontrolerze RedirectToAction("Index", "nazwa kontrolera")
        }
        return View(obj);
    }
}