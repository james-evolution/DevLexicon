using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevLexicon.Data;
using DevLexicon.Models;

namespace DevLexicon.Controllers
{
    public class TechTermsController : Controller
    {
        private readonly DevLexiconContext _context;

        public TechTermsController(DevLexiconContext context)
        {
            _context = context;
        }

        // GET: TechTerms
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var terms = from t in _context.TechTerm
                        select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                var lower = searchString.ToLower();
                terms = terms.Where(t => t.Name.ToLower().Contains(lower) || (t.Category ?? "").ToLower().Contains(lower));
            }

            return View(await terms.ToListAsync());
        }

        // GET: TechTerms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techTerm = await _context.TechTerm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (techTerm == null)
            {
                return NotFound();
            }

            return View(techTerm);
        }

        // GET: TechTerms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TechTerms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Definition,DocumentationLink,Category")] TechTerm techTerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(techTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(techTerm);
        }

        // GET: TechTerms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techTerm = await _context.TechTerm.FindAsync(id);
            if (techTerm == null)
            {
                return NotFound();
            }
            return View(techTerm);
        }

        // POST: TechTerms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Definition,DocumentationLink,Category")] TechTerm techTerm)
        {
            if (id != techTerm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(techTerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechTermExists(techTerm.Id))
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
            return View(techTerm);
        }

        // GET: TechTerms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techTerm = await _context.TechTerm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (techTerm == null)
            {
                return NotFound();
            }

            return View(techTerm);
        }

        // POST: TechTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var techTerm = await _context.TechTerm.FindAsync(id);
            if (techTerm != null)
            {
                _context.TechTerm.Remove(techTerm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechTermExists(int id)
        {
            return _context.TechTerm.Any(e => e.Id == id);
        }
    }
}
