using Fiorello.Areas.Admin.ViewModels.Slider;
using Fiorello.Data;
using Fiorello.Helpers;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SliderVM> sliderList = new();

            List<Slider> sliders = await _context.sliders.ToListAsync();

            foreach (Slider slider in sliders)
            {
                SliderVM model = new()
                {
                    Id = slider.Id,
                    Image = slider.Image,
                    CreateDate = slider.CreatedDate.ToString("dd-MM-yyyy")
                };

                sliderList.Add(model);
            }

            return View(sliderList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Slider dbSlider = await _context.sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (dbSlider is null) return NotFound();

            SliderDetailVM model = new()
            {
                Image = dbSlider.Image,
                CreateDate = dbSlider.CreatedDate.ToString("dd-MM-yyyy"),
            };

            return View(model);


        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid) return View();

            if (!request.Image.CheckFileType("image/")) 
            {
                ModelState.AddModelError("Image", "Please select only image file.");
                return View();
            }

            if(request.Image.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Please select under 200KB image");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + request.Image.FileName;

            await request.Image.SaveFileAsync(fileName, _env.WebRootPath, "img");
    
            Slider slider = new()
            {
                Image = fileName
            };

            await _context.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
