using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class Cart
    {
        [Key]
        public string CartId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public string ProductId { get; set; }
    }
}