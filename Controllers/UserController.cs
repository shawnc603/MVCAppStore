using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppStore.Models;
using System.Web.Security;

namespace MVCAppStore.Controllers
{
    public class UserController : Controller
    {
        DataAccess.DataAccess _daccess = new DataAccess.DataAccess();

        // GET: Employee/AddEmployee    
        public ActionResult UserAdd()
        {
            return View();
        }

        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult UserAdd(Users User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _daccess.InsertUsers(User);
                    ViewBag.Message = "User Registration successfull!";
                }

                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Login login)
        {
            if (ModelState.IsValid)
            {
                if (_daccess.IsValid(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login incorrect!");
                }
            }
            return View(login);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }



}
