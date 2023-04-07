using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderId { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime DateOfOrder { get; set; }

        //public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [ForeignKey("Product")]
        public string ProductId { get; set; }


        [Required(ErrorMessage = "Required")]
        [ForeignKey("Customer")]
        public int UserId { get; set; }
        public Customer Customer { get; set; }

        public Product Product { get; set; }
    }
}