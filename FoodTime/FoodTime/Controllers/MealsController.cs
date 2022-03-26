#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodTime.Data;
using FoodTime.Models;

namespace FoodTime.Controllers
{
    public class MealsController : Controller
    {
        private readonly FoodTimeContext _context;

        public MealsController(FoodTimeContext context)
        {
            _context = context;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            return View(await _context.MealModel.ToListAsync());
        }

        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealModel = await _context.MealModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealModel == null)
            {
                return NotFound();
            }

            return View(mealModel);
        }

        // GET: Meals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name")] MealModel mealModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealModel);
        }

        // GET: Meals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealModel = await _context.MealModel.FindAsync(id);
            if (mealModel == null)
            {
                return NotFound();
            }
            return View(mealModel);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name")] MealModel mealModel)
        {
            if (id != mealModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealModelExists(mealModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mealModel);
        }

        // GET: Meals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealModel = await _context.MealModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealModel == null)
            {
                return NotFound();
            }

            return View(mealModel);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealModel = await _context.MealModel.FindAsync(id);
            _context.MealModel.Remove(mealModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealModelExists(int id)
        {
            return _context.MealModel.Any(e => e.Id == id);
        }
    }
}
