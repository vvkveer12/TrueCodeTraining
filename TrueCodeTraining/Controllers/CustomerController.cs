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
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
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
            var singledata = selectsingledata.EditeData((int)id);
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
    }
}