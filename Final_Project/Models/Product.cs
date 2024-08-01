using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Category Name")]

        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

       
    }
}
