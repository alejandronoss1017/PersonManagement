using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Entities;

namespace WebApp.Controllers.View;

public class ProfessionsController(AppDbContext context) : Controller
{
    // GET: Professions
    public async Task<IActionResult> Index()
    {
        return View(await context.Professions.ToListAsync());
    }

    // GET: Professions/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var profession = await context.Professions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (profession == null)
        {
            return NotFound();
        }

        return View(profession);
    }

    // GET: Professions/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Professions/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description")] Profession profession)
    {
        if (ModelState.IsValid)
        {
            context.Add(profession);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(profession);
    }

    // GET: Professions/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var profession = await context.Professions.FindAsync(id);
        if (profession == null)
        {
            return NotFound();
        }
        return View(profession);
    }

    // POST: Professions/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Profession profession)
    {
        if (id != profession.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(profession);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionExists(profession.Id))
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
        return View(profession);
    }

    // GET: Professions/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var profession = await context.Professions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (profession == null)
        {
            return NotFound();
        }

        return View(profession);
    }

    // POST: Professions/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var profession = await context.Professions.FindAsync(id);
        if (profession != null)
        {
            context.Professions.Remove(profession);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProfessionExists(int id)
    {
        return context.Professions.Any(e => e.Id == id);
    }
}