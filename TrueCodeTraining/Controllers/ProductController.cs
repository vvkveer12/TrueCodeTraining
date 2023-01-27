using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCode.Model;
using TrueCodeTraining.Repository;

namespace TrueCodeTraining.Controllers
{
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

    }
}