using E_salesperson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_salesperson.Controllers
{
    public class LoginController : Controller
    {
        SalesPersonDBEntitiesE dbtities = new SalesPersonDBEntitiesE();

        // GET: Login
        public ActionResult Login()
        {
            Session["admin"] = false;
            Session["id"] = 0;
            return View();
        }


        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            if(username.Equals("admin") && password.Equals("admin"))
            {
                Session["admin"] = true;
                return RedirectToAction("CompanyLogo", "CompanyLogo");
            }
            var user = dbtities.SalesPersonT.Where(u => u.SalesPersonName.Equals(username)
                         && u.SalesPersonPassword.Equals(password)).SingleOrDefault();
           
            if(user != null)
            {
                Session["admin"] = false;
                int id = user.SalesPersonID;
                Session["id"] = id;
                return RedirectToAction("CompanyLogo", "CompanyLogo");
            }
            ViewBag.error = "username or password is wrong";
            return View();
        }

        [HttpPost]
        public ActionResult LoginD(string SalesPersonName, string SalesPersonPassword)
        {
            if (SalesPersonName.Equals("admin") && SalesPersonPassword.Equals("admin"))
            { 
                return Json(new { IsAdmin = true, IsLogin = true }, JsonRequestBehavior.AllowGet);
            }
            var user = dbtities.SalesPersonT.Where(u => u.SalesPersonName.Equals(SalesPersonName)
                         && u.SalesPersonPassword.Equals(SalesPersonPassword)).SingleOrDefault();

            if (user != null)
            {
                return Json(new
                {
                    IsLogin = true,
                    IsAdmin = false ,
                    SalesPersonID =user.SalesPersonID,
                    SalesPersonNumber=user.SalesPersonNumber,
                    SalesPersonRegion=user.SalesPersonRegion,
                    SalesPersonImageSrc=user.SalesPersonImageSrc,
                    SalesPersonRegisterDay=user.SalesPersonRegisterDay,
                    SalesPersonRegisterMonth=user.SalesPersonRegisterMonth,
                    SalesPersonRegisterYear=user.SalesPersonRegisterYear


                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { IsLogin = false }, JsonRequestBehavior.AllowGet);
        }
    }
}