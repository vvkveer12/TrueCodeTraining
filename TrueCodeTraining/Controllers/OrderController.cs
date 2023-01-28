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
    public class OrderController : Controller
    {
        // GET: Order

        public ActionResult OrderData()
        {
            var getcustomer = new CustomerRepository();
            var data = getcustomer.GetAllCustomer();
            ViewBag.customerData = data;
            var getOrder = new OrderRepository();
            var orderData = getOrder.GetOrder();
            return View(orderData);
        }
        public ActionResult DeleteOrder(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("OrderData");
            var deleteOrder = new OrderRepository();
            deleteOrder.DeleteOrder((int)id);
            return RedirectToAction("OrderData");
        }
        [HttpPost]
        public ActionResult OrderData(OrderVm order)
        {
            var getOrder = new OrderRepository();
            var orderData = getOrder.AddOrderData(order);
            return RedirectToAction("OrderData");
        }

        public ActionResult GetSingleOrder(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("OrderData");
            var getcustomer = new CustomerRepository();
            var data = getcustomer.GetAllCustomer();
            ViewBag.customerData = data;
            var orderRepositoty = new OrderRepository();
            var singleOrderData = orderRepositoty.GetSingleOrder(id);
            return View("EditOrder", singleOrderData);
        }
        [HttpPost]
        public ActionResult UpdateOrder(OrderVm orderVm)
        {
            var updateOrder = new OrderRepository();
            updateOrder.UpdateOrder(orderVm);
            return RedirectToAction("OrderData");
        }
    }
}