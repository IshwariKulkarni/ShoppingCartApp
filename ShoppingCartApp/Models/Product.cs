using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class Product
    {
        [Key]

        public string ProductId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ProductCategory { get; set; }
        [Required(ErrorMessage = "Required")]
        public float ProductPrice { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ProductQuantity { get; set; }
        public string ProductDescription { get; set; }

        [ForeignKey("Category")]
        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}