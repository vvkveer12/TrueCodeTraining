using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TrueCode.Model;
using TrueCodeTraining.Repository;

namespace TrueCodeTraining.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserVm userVm)
        {
           if(ModelState.IsValid) {
                if (userVm.UserName != null && userVm.Password != null) {
                    var data = new UserRepository();
                    var singleUser = data.LoginUser(userVm);
                    if (singleUser.UserName == userVm.UserName && singleUser.Password == userVm.Password) {
                        FormsAuthentication.SetAuthCookie(userVm.UserName, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
                
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddUser(UserVm userVm)
        {
            if(ModelState.IsValid) {
                var data = new UserRepository();
                var singleUser = data.GetAllUser(userVm);
                if (singleUser != null) {
                    if (singleUser.UserName == userVm.UserName || singleUser.Email == userVm.Email)
                        return Content("<script>alert('User Name or Email alredy exits');window.location.href='/home/index'</script>");
                }
                var userdata = data.AddUserData(userVm);
            }
            return RedirectToAction("Index", "account");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}