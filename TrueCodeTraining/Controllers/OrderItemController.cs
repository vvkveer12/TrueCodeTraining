using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCode.Model;
using TrueCodeTraining.DbModel;
using System.Web.WebPages.Html;
using TrueCodeTraining.Repository;
using Newtonsoft.Json;

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
            //orderVmw.OrderItmes = productRepository.GetAllProduct().Select(data => new System.Web.WebPages.Html.SelectListItem {
            //    Text = data.ProductName,
            //    Value = data.ProductId.ToString()
            //}).ToList();
            return View(orderVmw);
        }
        [HttpPost]
        public ActionResult Index(OrderVmw orderVmw)
        {
            if(ModelState.IsValid) {
                var orderRepository = new OrderRepository();
                orderRepository.AddOrder(orderVmw);
                return RedirectToAction("OrderItems");
            }
            return Content("<script>window.location.href='/orderitem/index'</script>");
            
        }
        public ActionResult TotalOrder()
        {
            var orderRepository = new OrderRepository();
            var data = orderRepository.GetAllOrderItems();
            return View("OrderItems", data);
        }
        public ActionResult GetProduct(int ? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");
            var productRepository = new ProductRepository();
            var data = productRepository.GetSingleProduct((int)id);
            var productData = JsonConvert.SerializeObject(data);
            return Json(productData,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllProduct()
        {
            var productRepository = new ProductRepository();
            var data = productRepository.GetAllProduct();
            var productData = JsonConvert.SerializeObject(data);
            return Json(productData, JsonRequestBehavior.AllowGet);
        }
     
    }
}