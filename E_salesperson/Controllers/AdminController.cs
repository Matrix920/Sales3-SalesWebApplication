using E_salesperson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_salesperson.Controllers
{
    public class AdminController : Controller
    {
        SalesPersonDBEntitiesE dbtities = new SalesPersonDBEntitiesE();

        // GET: Admin
        public ActionResult AllSalesPerson(string error)
        {
            ViewBag.error = error;
            var SalesPersons = dbtities.SalesPersonT.ToList();
            return View(SalesPersons);
        }

      

        public ActionResult DeleteSalesPerson(int id)
        {
            var SalesPersons = dbtities.SalesPersonT.
                                Where(sp => sp.SalesPersonID == id).SingleOrDefault();

            if (SalesPersons != null)
            {
                var co = dbtities.CommissionT.Where(c => c.SalesPersonID == SalesPersons.SalesPersonID).ToList();
                dbtities.CommissionT.RemoveRange(co);
                dbtities.SaveChanges();

                dbtities.SalesPersonT.Remove(SalesPersons);
                dbtities.SaveChanges();
            }
           
            return RedirectToAction("AllSalesPerson");
        }

        public ActionResult DeleteSalesPersonD(String SalesPersonID)
        {
            int id = Int32.Parse(SalesPersonID);

            var SalesPersons = dbtities.SalesPersonT.
                                Where(sp => sp.SalesPersonID == id).SingleOrDefault();

            if (SalesPersons != null)
            {
                var co = dbtities.CommissionT.Where(c => c.SalesPersonID == SalesPersons.SalesPersonID).ToList();
                dbtities.CommissionT.RemoveRange(co);
                dbtities.SaveChanges();
                dbtities.SalesPersonT.Remove(SalesPersons);
                dbtities.SaveChanges();
            }

            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSalesPersonsD()
        {
            var persons = dbtities.SalesPersonT.Select(p => new
            {
                SalesPersonID = p.SalesPersonID,
                SalesPersonNumber = p.SalesPersonNumber,
                SalesPersonName = p.SalesPersonName,
                SalesPersonImageSrc = p.SalesPersonImageSrc,
                SalesPersonRegisterDay = p.SalesPersonRegisterDay,
                SalesPersonRegisterMonth = p.SalesPersonRegisterMonth,
                SalesPersonRegisterYear = p.SalesPersonRegisterYear,
                SalesPersonRegion = p.SalesPersonRegion,
                SalesPersonPassword=p.SalesPersonPassword
            }).ToList();
            return Json(persons, JsonRequestBehavior.AllowGet);
        }



        public ActionResult EditSalesPerson(int id )
        {
            var SalesPersons = dbtities.SalesPersonT.
                               Where(sp => sp.SalesPersonID == id).SingleOrDefault();


            return View(SalesPersons);
        }

        [HttpPost]
        public ActionResult EditSalesPerson(string id,string username, 
            string password,string region, HttpPostedFileBase file)
        {
            int id1 = Int32.Parse(id);
            var SalesPersons = dbtities.SalesPersonT.
                               Where(sp => sp.SalesPersonID == id1).SingleOrDefault();

            string fileName = "";
            if (file != null && file.ContentLength > 0)
            {
                fileName = System.IO.Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath("~/Image/" + fileName));
                SalesPersons.SalesPersonImageSrc= "Image/" + fileName;
            }

            
            SalesPersons.SalesPersonName = username;
            SalesPersons.SalesPersonPassword = password;
            SalesPersons.SalesPersonRegion = region;

            dbtities.SaveChanges();

            return RedirectToAction("AllSalesPerson");
        }

        [HttpPost]
        public ActionResult EditSalesPersonD(string SalesPersonID, string SalesPersonName,
           string SalesPersonPassword, string SalesPersonRegion, String SalesPersonImageSrc)
        {
            int id1 = Int32.Parse(SalesPersonID);
            var SalesPersons = dbtities.SalesPersonT.
                               Where(sp => sp.SalesPersonID == id1).SingleOrDefault();

            

            SalesPersons.SalesPersonName = SalesPersonName;
            SalesPersons.SalesPersonPassword = SalesPersonPassword;
            SalesPersons.SalesPersonRegion = SalesPersonRegion;

            dbtities.SaveChanges();

            return Json(new { Sucess = true }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddSalesPerson(string number,string name ,string pass ,string region,
                    string day,string month ,string year, HttpPostedFileBase file)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(number);
            }
            catch
            {
              

                return RedirectToAction("AllSalesPerson",new {error = "error in information .. Check it again" });
        }
            var sp = dbtities.SalesPersonT.Where(s => s.SalesPersonNumber == num).SingleOrDefault();
            if(sp != null)
            {
                

                return RedirectToAction("AllSalesPerson", new { error = "error .. Number is exist" });
            }


            string fileName = "";
            if (file !=null && file.ContentLength>0)
            {
                 fileName = System.IO.Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath("~/Image/" + fileName));
                
            }
            var newperson = new SalesPersonT();

            try
            {
                newperson.SalesPersonNumber = Int32.Parse(number);
                newperson.SalesPersonName = name;
                newperson.SalesPersonPassword = pass;
                newperson.SalesPersonRegion = region;
                newperson.SalesPersonRegisterDay= Int32.Parse(day);
                newperson.SalesPersonRegisterMonth = Int32.Parse(month);
                newperson.SalesPersonRegisterYear = Int32.Parse(year);
                newperson.SalesPersonImageSrc = "Image/" + fileName;
                dbtities.SalesPersonT.Add(newperson);
                dbtities.SaveChanges();

            }
            catch  {
                return RedirectToAction("AllSalesPerson", new { error = "error in information .. Check it again" });

            }

            return RedirectToAction("AllSalesPerson");

        }

        [HttpPost]
        public ActionResult AddSalesPersonD(string SalesPersonNumber, string SalesPersonName,
            string SalesPersonPassword, string SalesPersonRegion,
                    string SalesPersonRegisterDay, string SalesPersonRegisterMonth,
                    string SalesPersonRegisterYear, String SalesPersonImageSrc)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(SalesPersonNumber);
            }
            catch
            {


                return RedirectToAction("AllSalesPerson", new { error = "error in information .. Check it again" });
            }
            var sp = dbtities.SalesPersonT.Where(s => s.SalesPersonNumber == num).SingleOrDefault();
            if (sp != null)
            {


                return RedirectToAction("AllSalesPerson", new { error = "error .. Number is exist" });
            }

            var newperson = new SalesPersonT();

            try
            {
                newperson.SalesPersonNumber = Int32.Parse(SalesPersonNumber);
                newperson.SalesPersonName = SalesPersonName;
                newperson.SalesPersonPassword = SalesPersonPassword;
                newperson.SalesPersonRegion = SalesPersonRegion;
                newperson.SalesPersonRegisterDay = Int32.Parse(SalesPersonRegisterDay);
                newperson.SalesPersonRegisterMonth = Int32.Parse(SalesPersonRegisterMonth);
                newperson.SalesPersonRegisterYear = Int32.Parse(SalesPersonRegisterYear);

                dbtities.SalesPersonT.Add(newperson);
                dbtities.SaveChanges();

            }
            catch
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SearchD(string SalesPersonName,
            string CommMonth, string CommYear)
        {
            int m = Int32.Parse(CommMonth);
            int y = Int32.Parse(CommYear);


            var result = (from person in dbtities.SalesPersonT
                          join comms in dbtities.CommissionT on person.SalesPersonID equals comms.SalesPersonID
                          where person.SalesPersonName.Contains(SalesPersonName)
                          && comms.CommYear == y
                          && comms.CommMonth == m
                          select new
                          {
                              SalesPersonNumber = person.SalesPersonNumber,
                              SalesPersonRegioin=person.SalesPersonRegion,
                              SalesPersonRegisterDay=person.SalesPersonRegisterDay,
                              SalesPersonRegisterMonth=person.SalesPersonRegisterMonth,
                              SalesPersonRegisterYear=person.SalesPersonRegisterYear,
                              SalesPersonName=person.SalesPersonName,
                              CommNorthern=comms.CommNorthern,
                              CommSouthern=comms.CommSouthern,
                              CommEastern=comms.CommEastern,
                              CommCoastal=comms.CommCoastal,
                              CommLebanon=comms.CommLebanon,
                              CommTotal=comms.CommTotal,
                              CommMonth=comms.CommMonth,
                              CommYear=comms.CommYear
                          }).ToList();




            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string name,string month,string year)
        {
            int m = Int32.Parse(month);
            int y = Int32.Parse(year);


            var result = (from person in dbtities.SalesPersonT
                          join comms in dbtities.CommissionT on person.SalesPersonID equals comms.SalesPersonID
                          where person.SalesPersonName.Contains(name)
                          && comms.CommYear == y
                          && comms.CommMonth == m
                          select comms).ToList();


            
            return View(result);
        }

    }
}