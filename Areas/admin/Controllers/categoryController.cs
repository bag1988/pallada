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
    public class categoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public categoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: admin/category
        public async Task<IActionResult> Index()
        {
            return View(await _context.categoryModel.ToListAsync());
        }

        // GET: admin/category/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.categoryModel
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // GET: admin/category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] categoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                if (_context.categoryModel.FirstOrDefault(x => x.Name == categoryModel.Name) != null)
                {
                    ModelState.AddModelError("name", "Данное имя уже содержится в базе!");
                    return View(categoryModel);
                }

                _context.Add(categoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryModel);
        }

        // GET: admin/category/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.categoryModel.FindAsync(Id);
            if (categoryModel == null)
            {
                return NotFound();
            }
            return View(categoryModel);
        }

        // POST: admin/category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,Name")] categoryModel categoryModel)
        {
            if (Id != categoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categoryModelExists(categoryModel.Id))
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
            return View(categoryModel);
        }

        // GET: admin/category/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.categoryModel
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // POST: admin/category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var categoryModel = await _context.categoryModel.FindAsync(Id);
            _context.categoryModel.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool categoryModelExists(int Id)
        {
            return _context.categoryModel.Any(e => e.Id == Id);
        }
    }
}
