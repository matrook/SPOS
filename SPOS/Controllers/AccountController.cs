using SPOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SPOS.Controllers
{
    public class AccountController : Controller
    {
        SPOSEntities context = new SPOSEntities();
        //GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            bool isValid = context.Users.Any(x=>x.UserName==model.UserName && x.Password==model.Password && x.IsRemoved== true);
            if (isValid)
            {


               
                //Any Logic
                //return View("Index", "_WebmasterLayout", model);



                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return RedirectToAction("Index", "Home");
                
            }

            ModelState.AddModelError("", "Invalid User Name and Password");
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
    
      [HttpPost]
        public ActionResult SignUp(User model)
        {         
                context.Users.Add(model);
                context.SaveChanges();
          
                return RedirectToAction("Login");
        }
        public ActionResult LogOut()
        {
            /*HttpContext.Session.Remove(SessionKeys.UserType);*///This will remove all keys from session variable. For example, if your session contains id, name, phone number, email etc.
            HttpContext.Session.RemoveAll();//This will remove all session from application
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }

}