using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMVCExam.Models
{
    public class ProductModel
    {
        [Display(Name = "ProductId")]
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Product Name")]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please Enter Rate of Product")]
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please give Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Appropriate Category Name")]
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }
    }
}