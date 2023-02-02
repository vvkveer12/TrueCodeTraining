using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace TrueCode.Model
{
    public class OrderVmw
    {
        public OrderVmw()
        {
            CustomerList = new List<SelectListItem>();
            productVms = new List<ProductVm>();
        }
     
        public DateTime OrderDate  { get; set; }
        public List<SelectListItem> CustomerList  { get; set; }
        public int CustomerId { get; set; }
        public List<ProductVm> productVms { get; set; }
    }
}
