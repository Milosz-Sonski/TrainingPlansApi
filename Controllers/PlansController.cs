using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingPlansApi.Data;
using TrainingPlansApi.Models;
using System.Collections.Generic;

namespace TrainingPlansApi.Controllers
{
    public class PlansController : Controller
    {
        private readonly TrainingPlansContext _context;

        public PlansController(TrainingPlansContext context)
        {
            _context = context;
        }

        // Upewnij siê, ¿e zwracasz Task<IActionResult> dla metod asynchronicznych
        public async Task<IActionResult> Create()
        {
            // Twoja logika tworzenia planu
            return View();
        }

        public async Task<IActionResult> Community()
        {
            // Asynchroniczne pobieranie danych z bazy
            var plans = await _context.TrainingPlans.ToListAsync();
            return View(plans);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var plan = await _context.TrainingPlans.FirstOrDefaultAsync(p => p.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        public async Task<IActionResult> UpdatePlan(TrainingPlan plan)
        {
            var existingPlan = await _context.TrainingPlans.FirstOrDefaultAsync(p => p.Id == plan.Id);
            if (existingPlan == null)
            {
                return NotFound();
            }

            // Zaktualizowanie planu
            existingPlan.Name = plan.Name;
            existingPlan.Description = plan.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction("Community");
        }

        public async Task<IActionResult> AddTrainingPlan(TrainingPlan plan)
        {
            if (!ModelState.IsValid)  // Sprawdzamy, czy model jest prawid³owy
            {
                return View("Create", plan);  // Zwracamy widok Create z planem
            }

            _context.TrainingPlans.Add(plan);  // Dodajemy plan do bazy danych
            await _context.SaveChangesAsync();  // Zapisujemy dane

            return RedirectToAction("Index");  // Przekierowanie do Index
        }
    }
}
