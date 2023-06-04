using Fiorello.Areas.Admin.ViewModels.Category;
using Fiorello.Data;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CategoryVM> list = new();

            var datas = await _appDbContext.categories.OrderByDescending(m=>m.Id).ToListAsync();

            foreach (var data in datas)
            {
                list.Add(new CategoryVM
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM request)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }

            Category newCategory = new() { Name = request.Name };

            await _appDbContext.categories.AddAsync(newCategory);

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var existCategory = await _appDbContext.categories.FirstOrDefaultAsync(c => c.Id == id);

            if (existCategory is null) return NotFound();

            CategoryEditVM model = new()
            {
                Id = existCategory.Id,
                Name = existCategory.Name,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM request)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return View();

            var existCategory = await _appDbContext.categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (existCategory is null) return NotFound();

            if(existCategory.Name.Trim() == request.Name.Trim()) return RedirectToAction("Index");

            Category category = new() { Id = request.Id, Name = request.Name };

            _appDbContext.Update(category);

            //existCategory.Name = request.Name;

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var existCategory = await _appDbContext.categories.FirstOrDefaultAsync(m => m.Id == id);

            existCategory.SoftDelete = true;

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
