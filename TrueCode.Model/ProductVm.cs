using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCode.Model
{
    public class ProductVm
    {
        public int ProductId { get; set; }
        [StringLength(200)]
        [Required]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
