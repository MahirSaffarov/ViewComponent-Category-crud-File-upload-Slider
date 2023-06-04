using System.ComponentModel.DataAnnotations;

namespace Fiorello.Areas.Admin.ViewModels.Category
{
    public class CategoryCreateVM
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
