using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CategoryName { get; set; }

    }
}