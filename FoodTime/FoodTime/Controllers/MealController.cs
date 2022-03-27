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
    
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var mealFromDb = _db.Meals.Find(id);
        //var mealFromDbFirst = _db.Meals.FirstOrDefault(u => u.Id == id);
        //var mealFromDbSingle = _db.Meals.SingleOrDefault(u => u.Id == id);

        if (mealFromDb == null)
        {
            return NotFound();
        }
        return View(mealFromDb);
    }
    
    //POST
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(MealModel obj)
    {
        /*if (obj.Name == obj.DisplayOrder.ToString()) Custom Validation
        {
            ModelState.AddModelError(("name", "The DisplayOrder cannot exaclty match the Name."));
        }*/
        if (ModelState.IsValid)
        {
            _db.Meals.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index"); // jak w innym kontrolerze RedirectToAction("Index", "nazwa kontrolera")
        }
        return View(obj);
    }
    
}