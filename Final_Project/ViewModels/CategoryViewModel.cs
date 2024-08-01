using Final_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels
{
    public class CategoryViewModel
    {
      
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
