using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _210940320047.Models
{
    public class Product
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = " {0} Can not be empty")]
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage = "{0} Should be of less than {1} characters")]
        public string ProductName { get; set; }

        
        [Display(Name = "Rate")]
        [Required(ErrorMessage = " {0} Can not be empty")]
        [DataType(DataType.Currency)]
        [Range(1, 99999999999999999, ErrorMessage ="{0} Can not be empty and must be greater than {1}")]
    
        public decimal Rate { get; set; }

        [Required(ErrorMessage = " {0} Can not be empty")]
        [Display(Name = "Product Description")]
        [StringLength(200, ErrorMessage = "{0} Should be of less than {1} characters and more than {2} characters", MinimumLength = 5)]
        public string Description { get; set; }

        [Required(ErrorMessage = " {0} Can not be empty")]
        [Display(Name = "Category Name")]
        [StringLength(50, ErrorMessage = "{0} Should be of less than {1} characters")]
        public string CategoryName { get; set; }

    }
}