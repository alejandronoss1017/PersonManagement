using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Entities;

namespace WebApp.Controllers;

public class EducationsController(AppDbContext context) : Controller
{
    // GET: Educations
    public async Task<IActionResult> Index()
    {
        var appDbContext = context.Educations.Include(e => e.IdPersonNavigation).Include(e => e.IdProfessionNavigation);
        return View(await appDbContext.ToListAsync());
    }

    // GET: Educations/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var education = await context.Educations
            .Include(e => e.IdPersonNavigation)
            .Include(e => e.IdProfessionNavigation)
            .FirstOrDefaultAsync(m => m.IdProfession == id);
        if (education == null)
        {
            return NotFound();
        }

        return View(education);
    }

    // GET: Educations/Create
    public IActionResult Create()
    {
        ViewData["IdPerson"] = new SelectList(context.People, "Id", "Id");
        ViewData["IdProfession"] = new SelectList(context.Professions, "Id", "Id");
        return View();
    }

    // POST: Educations/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdProfession,IdPerson,Date,University")] Education education)
    {
        if (ModelState.IsValid)
        {
            context.Add(education);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["IdPerson"] = new SelectList(context.People, "Id", "Id", education.IdPerson);
        ViewData["IdProfession"] = new SelectList(context.Professions, "Id", "Id", education.IdProfession);
        return View(education);
    }

    // GET: Educations/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var education = await context.Educations.FindAsync(id);
        if (education == null)
        {
            return NotFound();
        }
        ViewData["IdPerson"] = new SelectList(context.People, "Id", "Id", education.IdPerson);
        ViewData["IdProfession"] = new SelectList(context.Professions, "Id", "Id", education.IdProfession);
        return View(education);
    }

    // POST: Educations/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdProfession,IdPerson,Date,University")] Education education)
    {
        if (id != education.IdProfession)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(education);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(education.IdProfession))
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
        ViewData["IdPerson"] = new SelectList(context.People, "Id", "Id", education.IdPerson);
        ViewData["IdProfession"] = new SelectList(context.Professions, "Id", "Id", education.IdProfession);
        return View(education);
    }

    // GET: Educations/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var education = await context.Educations
            .Include(e => e.IdPersonNavigation)
            .Include(e => e.IdProfessionNavigation)
            .FirstOrDefaultAsync(m => m.IdProfession == id);
        if (education == null)
        {
            return NotFound();
        }

        return View(education);
    }

    // POST: Educations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var education = await context.Educations.FindAsync(id);
        if (education != null)
        {
            context.Educations.Remove(education);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EducationExists(int id)
    {
        return context.Educations.Any(e => e.IdProfession == id);
    }
}