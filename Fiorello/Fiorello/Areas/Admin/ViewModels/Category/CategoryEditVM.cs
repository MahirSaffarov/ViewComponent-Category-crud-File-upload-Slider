using System.ComponentModel.DataAnnotations;

namespace Fiorello.Areas.Admin.ViewModels.Category
{
    public class CategoryEditVM
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
