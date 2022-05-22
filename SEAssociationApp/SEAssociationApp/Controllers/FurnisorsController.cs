using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEProjectApp.DataAccess;
using SEProjectApp.DataModel;

namespace SEAssociationApp.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class FurnisorsController : Controller
    {
        private readonly AssociationContext _context;

        public FurnisorsController(AssociationContext context)
        {
            _context = context;
        }
        // GET: Furnisor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Furnisor.ToListAsync());
        }
        // GET: Furnisor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furnisor = await _context.Furnisor
                .FirstOrDefaultAsync(m => m.FurnisorId == id);
            if (furnisor == null)
            {
                return NotFound();
            }

            return View(furnisor);
        }
        // GET: Furnisor/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Furnisor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("FurnisorId,FurnisorName,StartDate,DueDate")] Furnisor furnisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(furnisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(furnisor);
        }
        // GET: Furnisor/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furnisor = await _context.Furnisor.FindAsync(id);
            if (furnisor == null)
            {
                return NotFound();
            }
            return View(furnisor);
        }

        // POST: Furnisor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("FurnisorId,FurnisorName,StartDate,DueDate")] Furnisor furnisor)
        {
            if (id != furnisor.FurnisorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(furnisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FurnisorExists(furnisor.FurnisorId))
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
            return View(furnisor);
        }
        [Authorize(Roles = "Admin")]
        // GET: Furnisor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furnisor = await _context.Furnisor
                .FirstOrDefaultAsync(m => m.FurnisorId == id);
            if (furnisor == null)
            {
                return NotFound();
            }

            return View(furnisor);
        }

        // POST: Furnisor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var furnisor = await _context.Furnisor.FindAsync(id);
            _context.Furnisor.Remove(furnisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FurnisorExists(int id)
        {
            return _context.Furnisor.Any(e => e.FurnisorId == id);
        }
    }
}
