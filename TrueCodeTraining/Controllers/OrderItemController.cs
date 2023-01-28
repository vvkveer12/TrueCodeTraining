using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCode.Model;
using TrueCodeTraining.DbModel;
using System.Web.WebPages.Html;
using TrueCodeTraining.Repository;

namespace TrueCodeTraining.Controllers
{
    [Authorize]
    public class OrderItemController : Controller
    {

        // GET: OrderItem
        public ActionResult Index()
        {
            var customeRepository = new CustomerRepository();
            var productRepository = new ProductRepository();
            var orderVmw = new OrderVmw();
            orderVmw.CustomerList = customeRepository.GetAllCustomer().Select(data => new System.Web.WebPages.Html.SelectListItem {
                Text = data.CustomerName,
                Value = data.CustomerId.ToString()
            }).ToList();
            orderVmw.OrderItmes = productRepository.GetAllProduct();
            return View(orderVmw);
        }
     
    }
}