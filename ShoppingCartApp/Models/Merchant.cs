using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class Merchant
    {
        [Key]
        public string MerchantId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string MerchantName { get; set; }

        [Required(ErrorMessage = "Contact Required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MerchantContact { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
ErrorMessage = "Invalid email format")]
        public string MerchantEmail { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string MerchantPassword { get; set; }

    }
}