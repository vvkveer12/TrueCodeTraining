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
        public ActionResult DeleteProduct(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");
            var orderRepository = new ProductRepository();
            orderRepository.DeleteProduct((int)id);
            return RedirectToAction("Index");
        }
        public ActionResult GetSingleProduct(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");
            var productRepository = new ProductRepository();
            var singleProduct = productRepository.GetSingleProduct((int)id);
            return View(singleProduct);
        }
        [HttpPost]
        public ActionResult GetSingleProduct(ProductVm productVm)
        {
            var updateProduct = new ProductRepository();
            updateProduct.UpdateProduct(productVm);
            TempData["success"] = "Product Record Updated Successfully";
            return RedirectToAction("Index");
        }

    }
}