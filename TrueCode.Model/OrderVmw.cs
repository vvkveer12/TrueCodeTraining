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
        public int ProducId { get; set; }
        public DateTime OrderDate  { get; set; }
        public List<ProductVm> OrderItmes  { get; set; }
        public List<SelectListItem> CustomerList  { get; set; }
    }
}
