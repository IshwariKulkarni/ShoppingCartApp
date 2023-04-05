using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class TransactionDetail
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public string TransactionType { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        public float Amount { get; set; }

        [ForeignKey("OrderDetail")]
        public string OrderId { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }

        //public virtual Customer Customer { get; set; }
    }
}