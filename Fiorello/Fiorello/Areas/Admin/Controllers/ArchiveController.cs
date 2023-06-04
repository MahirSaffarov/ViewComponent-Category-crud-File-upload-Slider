using Fiorello.Areas.Admin.ViewModels.Category;
using Fiorello.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly AppDbContext _context;

        public ArchiveController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Categories()
        {
            List<CategoryVM> list = new();

            var datas = await _context.categories.IgnoreQueryFilters().Where(m => m.SoftDelete).ToListAsync();

            foreach (var data in datas)
            {
                list.Add(new CategoryVM { Id = data.Id, Name = data.Name });
            }

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExtractCategory(int id)
        {
            var existCategory = await _context.categories.IgnoreQueryFilters().Where(m => m.SoftDelete).FirstOrDefaultAsync(c => c.Id == id);

            existCategory.SoftDelete = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Categories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.categories.IgnoreQueryFilters().Where(m => m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);

            _context.Remove(data);

            await _context.SaveChangesAsync();

            return RedirectToAction("Categories");
        }
    }
}
