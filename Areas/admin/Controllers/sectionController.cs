using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pallada.Data;
using pallada.Models.Uslugi;

namespace pallada.Areas.admin.Controllers
{
    [Area("admin")]
    public class sectionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public sectionController(ApplicationDbContext context)
        {
            _context = context;
        }
                
        public async Task<IEnumerable<categoryModel>> getCategory()
        {
            return await _context.categoryModel.ToListAsync();
        }
        // GET: admin/section
        public async Task<IActionResult> Index()
        {
            return View(await _context.sectionModel.ToListAsync());
        }

        // GET: admin/section/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionModel = await _context.sectionModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sectionModel == null)
            {
                return NotFound();
            }

            return View(sectionModel);
        }

        // GET: admin/section/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/section/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCategory,Name")] sectionModel sectionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sectionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectionModel);
        }

        // GET: admin/section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionModel = await _context.sectionModel.FindAsync(id);
            if (sectionModel == null)
            {
                return NotFound();
            }
            return View(sectionModel);
        }

        // POST: admin/section/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCategory,Name")] sectionModel sectionModel)
        {
            if (id != sectionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sectionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sectionModelExists(sectionModel.Id))
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
            return View(sectionModel);
        }

        // GET: admin/section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionModel = await _context.sectionModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sectionModel == null)
            {
                return NotFound();
            }

            return View(sectionModel);
        }

        // POST: admin/section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sectionModel = await _context.sectionModel.FindAsync(id);
            _context.sectionModel.Remove(sectionModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sectionModelExists(int id)
        {
            return _context.sectionModel.Any(e => e.Id == id);
        }
    }
}
