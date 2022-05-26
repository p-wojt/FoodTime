using FoodTime.Areas.Identity.Data;
using FoodTime.Data;
using FoodTime.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodTime.Controllers;

[Authorize]
public class MealController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public MealController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
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
    public async Task<IActionResult> Create(MealModel obj)
    {
        /*if (obj.Name == obj.DisplayOrder.ToString()) Custom Validation
        {
            ModelState.AddModelError(("name", "The DisplayOrder cannot exaclty match the Name."));
        }*/
        if (ModelState.IsValid)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            obj.ApplicationUser = applicationUser;

            _db.Meals.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Meal created successfuly";
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
            TempData["success"] = "Category updated successfuly";
            return RedirectToAction("Index"); // jak w innym kontrolerze RedirectToAction("Index", "nazwa kontrolera")
        }

        return View(obj);
    }

    public IActionResult Delete(int? id)
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
    [HttpPost, ActionName("Delete")] // jak request pod Delete to chodzi o ta metode
    [AutoValidateAntiforgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Meals.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Meals.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfuly"; //zostaje w memory na 1 redirect
        return RedirectToAction("Index");
    }
}