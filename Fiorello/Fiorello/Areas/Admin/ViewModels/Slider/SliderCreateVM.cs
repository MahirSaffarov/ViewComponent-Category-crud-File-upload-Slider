using System.ComponentModel.DataAnnotations;

namespace Fiorello.Areas.Admin.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required]
        public IFormFile Image  { get; set; }
    }
}
