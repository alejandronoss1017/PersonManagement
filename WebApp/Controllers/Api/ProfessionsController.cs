using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Entities;

namespace WebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfessionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Professions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profession>>> GetProfessions()
        {
            return await _context.Professions.ToListAsync();
        }

        // GET: api/Professions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profession>> GetProfession(int id)
        {
            var profession = await _context.Professions.FindAsync(id);

            if (profession == null)
            {
                return NotFound();
            }

            return profession;
        }

        // PUT: api/Professions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfession(int id, Profession profession)
        {
            if (id != profession.Id)
            {
                return BadRequest();
            }

            _context.Entry(profession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Professions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profession>> PostProfession(Profession profession)
        {
            _context.Professions.Add(profession);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfessionExists(profession.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfession", new { id = profession.Id }, profession);
        }

        // DELETE: api/Professions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfession(int id)
        {
            var profession = await _context.Professions.FindAsync(id);
            if (profession == null)
            {
                return NotFound();
            }

            _context.Professions.Remove(profession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessionExists(int id)
        {
            return _context.Professions.Any(e => e.Id == id);
        }
    }
}
