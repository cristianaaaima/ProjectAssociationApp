using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEProjectApp.DataAccess;
using SEProjectApp.DataModel;

namespace SEAssociationApp.Controllers
{
    public class ReportsController : Controller
    {
       // [Authorize(Roles = "Admin")]
       
            private readonly AssociationContext _context;

            public ReportsController(AssociationContext context)
            {
                _context = context;
            }

            // GET: Reports
            public async Task<IActionResult> Index()
            {
                var tenantsAssDbContext = _context.Invoice.Include(i => i.Apartment);
                return View(await tenantsAssDbContext.ToListAsync());
            }

            // GET: Reports/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var invoice = await _context.Invoice
                    .Include(i => i.Apartment)
                    .FirstOrDefaultAsync(m => m.InvoiceId == id);
                if (invoice == null)
                {
                    return NotFound();
                }

                return View(invoice);
            }

            // GET: Reports/Create
            public IActionResult Create()
            {
                ViewData["ApartmentId"] = new SelectList(_context.Apartment, "ApartmentId", "ApartmentId");
                return View();
            }

            // POST: Reports/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("InvoiceId,UserName,ApartmentNo,Price,Status,DueDate,Description,ApartmentId")] Invoice invoice)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(invoice);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ApartmentId"] = new SelectList(_context.Apartment, "ApartmentId", "ApartmentId", invoice.ApartmentId);
                return View(invoice);
            }

            // GET: Reports/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var invoice = await _context.Invoice.FindAsync(id);
                if (invoice == null)
                {
                    return NotFound();
                }
                ViewData["ApartmentId"] = new SelectList(_context.Apartment, "ApartmentId", "ApartmentId", invoice.ApartmentId);
                return View(invoice);
            }

            // POST: Reports/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("InvoiceId,UserName,ApartmentNo,Price,Status,DueDate,Description,ApartmentId")] Invoice invoice)
            {
                if (id != invoice.InvoiceId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(invoice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!InvoiceExists(invoice.InvoiceId))
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
                ViewData["ApartmentId"] = new SelectList(_context.Apartment, "ApartmentId", "ApartmentId", invoice.ApartmentId);
                return View(invoice);
            }

            // GET: Reports/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var invoice = await _context.Invoice
                    .Include(i => i.Apartment)
                    .FirstOrDefaultAsync(m => m.InvoiceId == id);
                if (invoice == null)
                {
                    return NotFound();
                }

                return View(invoice);
            }

            // POST: Reports/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var invoice = await _context.Invoice.FindAsync(id);
                _context.Invoice.Remove(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool InvoiceExists(int id)
            {
                return _context.Invoice.Any(e => e.InvoiceId == id);
            }
        }
    }
