using Final_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels
{
    public class ProductViewModel
    {
     
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        [Required]
       
        public decimal Price { get; set; }

        [Display(Name = "Product Image")]
        public string? ImagePath { get; set; }

        [Display(Name = "Category Name")]

        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }

    }
}
