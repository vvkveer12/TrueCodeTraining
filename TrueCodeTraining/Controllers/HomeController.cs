using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCode.Model;
using TrueCodeTraining.DbModel;
using TrueCodeTraining.Repository;

namespace TrueCodeTraining.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var getcustomer = new CustomerRepository();
            var data = getcustomer.GetAllCustomer();
            return View(data);
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            var comstomer = new CustomerRepository();
            comstomer.AddCustomer(customer);
            TempData["success"] = "Customer Record added Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            var deleteCustomer = new CustomerRepository();
            deleteCustomer.DeleteCustomer(id);
            TempData["success"] = "Customer Record deleted Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");
            var selectsingledata = new CustomerRepository();
            var singledata =  selectsingledata.EditeData((int)id);
            return View(singledata);

        }
        [HttpPost]
        public ActionResult Edit(CostomerVm customerVm)
        {
            var updatecustomer = new CustomerRepository();
            updatecustomer.UpdateCustomer(customerVm);
            TempData["success"] = "Customer Record Updated Successfully";
            return RedirectToAction("Index");
        }
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
     
        public ActionResult GetSingleOrder(int id)
        {
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}