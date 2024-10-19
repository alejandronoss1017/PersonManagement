using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Controllers.View;

public class PhonesController(AppDbContext context) : Controller
{
    // GET: Phones
    public async Task<IActionResult> Index()
    {
        var appDbContext = context.Phones.Include(p => p.OwnerNavigation);
        return View(await appDbContext.ToListAsync());
    }

    // GET: Phones/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var phone = await context.Phones
            .Include(p => p.OwnerNavigation)
            .FirstOrDefaultAsync(m => m.Number == id);
        if (phone == null)
        {
            return NotFound();
        }

        return View(phone);
    }

    // GET: Phones/Create
    public IActionResult Create()
    {
        ViewData["Owner"] = new SelectList(context.People, "Id", "Id");
        return View();
    }

    // POST: Phones/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Number,Carrier,Owner")] Phone phone)
    {
        if (ModelState.IsValid)
        {
            context.Add(phone);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Owner"] = new SelectList(context.People, "Id", "Id", phone.Owner);
        return View(phone);
    }

    // GET: Phones/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var phone = await context.Phones.FindAsync(id);
        if (phone == null)
        {
            return NotFound();
        }
        ViewData["Owner"] = new SelectList(context.People, "Id", "Id", phone.Owner);
        return View(phone);
    }

    // POST: Phones/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Number,Carrier,Owner")] Phone phone)
    {
        if (id != phone.Number)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(phone);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(phone.Number))
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
        ViewData["Owner"] = new SelectList(context.People, "Id", "Id", phone.Owner);
        return View(phone);
    }

    // GET: Phones/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var phone = await context.Phones
            .Include(p => p.OwnerNavigation)
            .FirstOrDefaultAsync(m => m.Number == id);
        if (phone == null)
        {
            return NotFound();
        }

        return View(phone);
    }

    // POST: Phones/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var phone = await context.Phones.FindAsync(id);
        if (phone != null)
        {
            context.Phones.Remove(phone);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PhoneExists(string id)
    {
        return context.Phones.Any(e => e.Number == id);
    }
}