using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCupOverflows.Models
{
    public class ProductUploadModel
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "Product Name is Required.")]
        [Display(Name = "Product Name")]
        [StringLength(24, ErrorMessage = "Product Name should be less than or 24 characters long.")]
        public string Name { get; set; } // Name of product

        [Required(ErrorMessage = "Category is Required.")]
        [Display(Name = "Category")]
        [StringLength(10, ErrorMessage = "Category should be less than or 10 characters long.")]
        public string Category { get; set; } // Drink | Dish

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Price is Required.")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } // From 0$

        [Required(ErrorMessage = "Specification is Required.")]
        public string Specification { get; set; } // Description

        public bool RestrictedAge { get; set; } // If Today - Birthday >= 18

        [Required]
        public string Branch { get; set; }
    }
}