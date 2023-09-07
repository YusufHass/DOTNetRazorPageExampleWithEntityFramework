using System.ComponentModel.DataAnnotations;

namespace RazorPageExampleWithEntityFramework.Entity
{
    public class Product
    {
        
        [Key]
        [Display(Name = "Product ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(25, ErrorMessage = "Name should be 1-25 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Model")]
        [StringLength(50, ErrorMessage = "Model should be 1-25 characters")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public int Price { get; set; }
    }
}
