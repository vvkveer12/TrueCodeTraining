using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCode.Model
{
    public class CostomerVm
    {
        public int CustomerId { get; set; }
        [StringLength(200)]
        public string CustomerName { get; set; }
        [StringLength(300)]
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
