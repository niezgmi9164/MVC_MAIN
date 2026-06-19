using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZadaniaZespolu.Data;
using ZadaniaZespolu.Models;

namespace ZadaniaZespolu.Controllers
{
    public class ZadaniaController : Controller
    {
        private readonly ZadaniaZespoluContext _context;

        public ZadaniaController(ZadaniaZespoluContext context)
        {
            _context = context;
        }

        // GET: Zadania
        public async Task<IActionResult> Index(string szukanyTekst, string projekt, Status? status)
        {
            // Lista projektów do listy rozwijanej (unikalne wartości).
            IQueryable<string> projektyZapytanie = from z in _context.Zadanie
                                                   orderby z.Projekt
                                                   select z.Projekt;

            var zadania = from z in _context.Zadanie
                          select z;

            // Wyszukiwanie po tytule.
            if (!string.IsNullOrEmpty(szukanyTekst))
            {
                zadania = zadania.Where(z => z.Tytul.Contains(szukanyTekst));
            }

            // Filtrowanie po projekcie.
            if (!string.IsNullOrEmpty(projekt))
            {
                zadania = zadania.Where(z => z.Projekt == projekt);
            }

            // Filtrowanie po statusie.
            if (status != null)
            {
                zadania = zadania.Where(z => z.Status == status);
            }

            var model = new ZadanieFiltrViewModel
            {
                Projekty = new SelectList(await projektyZapytanie.Distinct().ToListAsync()),
                Zadania = await zadania.ToListAsync(),
                SzukanyTekst = szukanyTekst,
                Projekt = projekt,
                Status = status
            };

            return View(model);
        }

        // GET: Zadania/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zadanie == null)
            {
                return NotFound();
            }

            return View(zadanie);
        }

        // GET: Zadania/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zadania/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,Osoba,Projekt,Status,Priorytet,TerminWykonania")] Zadanie zadanie)
        {
            if (ModelState.IsValid)
            {
                zadanie.DataUtworzenia = DateTime.Now;
                _context.Add(zadanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zadanie);
        }

        // GET: Zadania/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie.FindAsync(id);
            if (zadanie == null)
            {
                return NotFound();
            }
            return View(zadanie);
        }

        // POST: Zadania/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,Osoba,Projekt,Status,Priorytet,TerminWykonania,DataUtworzenia")] Zadanie zadanie)
        {
            if (id != zadanie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zadanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZadanieExists(zadanie.Id))
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
            return View(zadanie);
        }

        // GET: Zadania/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zadanie == null)
            {
                return NotFound();
            }

            return View(zadanie);
        }

        // POST: Zadania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zadanie = await _context.Zadanie.FindAsync(id);
            if (zadanie != null)
            {
                _context.Zadanie.Remove(zadanie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZadanieExists(int id)
        {
            return _context.Zadanie.Any(e => e.Id == id);
        }
    }
}
