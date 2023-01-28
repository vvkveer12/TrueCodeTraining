using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCode.Model;
using TrueCodeTraining.Repository;

namespace TrueCodeTraining.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var productRepository = new ProductRepository();
            var allProduct = productRepository.GetAllProduct();
            return View(allProduct);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductVm productVm)
        {
            var productRepository = new ProductRepository();
            productRepository.AddProduct(productVm);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int? ProductId)
        {
            var orderRepository = new OrderRepository();
            orderRepository.DeleteOrder((int)ProductId);
            return RedirectToAction("Index");
        }
        public ActionResult GetSingleProduct(int? ProductId)
        {
            var orderRepository = new OrderRepository();
            var singleProduct = orderRepository.GetSingleOrder(ProductId);
            return View(singleProduct);
        }

    }
}