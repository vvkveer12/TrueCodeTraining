using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueCode.Model;

namespace TrueCodeTraining.Controllers
{
    public class OrderItemController : Controller
    {
        // GET: OrderItem
        public ActionResult Index()
        {
           
            return View();
        }
    }
}