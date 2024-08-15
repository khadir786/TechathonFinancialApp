using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechathonFinancial.Data;
using TechathonFinancial.Models;

namespace TechathonFinancial.Controllers
{
    public class WordDefinitionsController : Controller
    {
        private readonly WordDbContext _context;

        public WordDefinitionsController(WordDbContext context)
        {
            _context = context;
        }

        public IActionResult Home()
        {
            var words = _context.WordDefinition.ToList();
            var randomWords = words.OrderBy(r => Guid.NewGuid()).ToList();

            foreach (var word in words)
            {
                Console.WriteLine(word.Word);
            }
            return View();
        }

        // GET: WordDefinitions
        public async Task<IActionResult> Index()
        {
            return View(await _context.WordDefinition.ToListAsync());
        }

        // GET: WordDefinitions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wordDefinition = await _context.WordDefinition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wordDefinition == null)
            {
                return NotFound();
            }

            return View(wordDefinition);
        }

        // GET: WordDefinitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WordDefinitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Word,Abbreviation,Definition")] WordDefinition wordDefinition)
        {
            if (ModelState.IsValid)
            {
                wordDefinition.Id = Guid.NewGuid();
                _context.Add(wordDefinition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wordDefinition);
        }

        // GET: WordDefinitions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wordDefinition = await _context.WordDefinition.FindAsync(id);
            if (wordDefinition == null)
            {
                return NotFound();
            }
            return View(wordDefinition);
        }

        // POST: WordDefinitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Word,Abbreviation,Definition")] WordDefinition wordDefinition)
        {
            if (id != wordDefinition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wordDefinition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WordDefinitionExists(wordDefinition.Id))
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
            return View(wordDefinition);
        }

        // GET: WordDefinitions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wordDefinition = await _context.WordDefinition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wordDefinition == null)
            {
                return NotFound();
            }

            return View(wordDefinition);
        }

        // POST: WordDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var wordDefinition = await _context.WordDefinition.FindAsync(id);
            if (wordDefinition != null)
            {
                _context.WordDefinition.Remove(wordDefinition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WordDefinitionExists(Guid id)
        {
            return _context.WordDefinition.Any(e => e.Id == id);
        }
    }
}
