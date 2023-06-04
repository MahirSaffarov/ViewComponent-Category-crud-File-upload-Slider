using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Fiorello.ViewModels;

namespace Fiorello.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public SliderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Slider> sliders = await _context.sliders.Where(m => !m.SoftDelete).ToListAsync();
            SlidersInfo sliderInfo = await _context.slidersInfos.Where(m => !m.SoftDelete).FirstOrDefaultAsync();

            SliderVM sliderVM = new() 
            {
                Sliders = sliders,
                SliderInfo = sliderInfo
            };

            return await Task.FromResult(View(sliderVM));
        }
    }
}
