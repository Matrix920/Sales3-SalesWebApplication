using E_salesperson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_salesperson.Controllers
{
    public class SalesPersonController : Controller
    {
        SalesPersonDBEntitiesE dbtities = new SalesPersonDBEntitiesE();

        // GET: SalesPerson
        public ActionResult AddNewCommission(string error)
        {
            ViewBag.error = error;
            int id = (int)Session["id"];
            var salesperson = dbtities.SalesPersonT.Where(s => s.SalesPersonID == id).SingleOrDefault();


            return View(salesperson);
        }

        [HttpPost]
        public ActionResult AddNewCommissionD(string SalesPersonID, string SalesPersonRegion, 
            string CommMonth, string CommYear, string CommSouthern, string CommCoastal,
                                          string CommNorthern, string CommEastern, string CommLebanon)
        {
            int south = Int32.Parse(CommSouthern);
            int coast = Int32.Parse(CommCoastal);
            int north = Int32.Parse(CommNorthern);
            int east = Int32.Parse(CommEastern);
            int leban = Int32.Parse(CommLebanon);

            double southernRegion = 0;
            double coastalRegion = 0;
            double northernRegion = 0;
            double easternRegion = 0;
            double lebanonRegion = 0;


            if (SalesPersonRegion.Equals("southern"))
            {

                if (south > 1000000)
                    southernRegion += ((1000000 * 0.05) + ((south - 1000000) * 0.07));
                else
                    southernRegion += (south * 0.05);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.03) + ((coast - 1000000) * 0.04));
                else
                    coastalRegion += (coast * 0.03);

                if (north > 1000000) northernRegion += ((1000000 * 0.03) + ((north - 1000000) * 0.04));
                else northernRegion += (north * 0.03);

                if (east > 1000000)
                    easternRegion += ((1000000 * 0.03) + ((east - 1000000) * 0.04));
                else
                    easternRegion += (east * 0.03);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.03) + ((leban - 1000000) * 0.04));
                else
                    lebanonRegion += (leban * 0.03);

            }
            else if (SalesPersonRegion.Equals("coastal"))
            {

                if (south > 1000000)
                    southernRegion += ((1000000 * 0.03) + ((south - 1000000) * 0.04));
                else
                    southernRegion += (south * 0.03);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.05) + ((coast - 1000000) * 0.07));
                else
                    coastalRegion += (coast * 0.05);

                if (north > 1000000)
                    northernRegion += ((1000000 * 0.03) + ((north - 1000000) * 0.04));
                else
                    northernRegion += (north * 0.03);

                if (east > 1000000)
                    easternRegion += ((1000000 * 0.03) + ((east - 1000000) * 0.04));
                else
                    easternRegion += (east * 0.03);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.03) + ((leban - 1000000) * 0.04));
                else
                    lebanonRegion += (leban * 0.03);

            }
            else if (SalesPersonRegion.Equals("northern"))
            {

                if (south > 1000000)
                    southernRegion += ((1000000 * 0.03) + ((south - 1000000) * 0.04));
                else
                    southernRegion += (south * 0.03);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.03) + ((coast - 1000000) * 0.04));
                else
                    coastalRegion += (coast * 0.03);

                if (north > 1000000)
                    northernRegion += ((1000000 * 0.05) + ((north - 1000000) * 0.07));
                else
                    northernRegion += (north * 0.05);

                if (east > 1000000)
                    easternRegion += ((1000000 * 0.03) + ((east - 1000000) * 0.04));
                else
                    easternRegion += (east * 0.03);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.03) + ((leban - 1000000) * 0.04));
                else
                    lebanonRegion += (leban * 0.03);

            }
            else if (SalesPersonRegion.Equals("eastern"))
            {

                if (south > 1000000)
                    southernRegion += ((1000000 * 0.03) + ((south - 1000000) * 0.04));
                else
                    southernRegion += (south * 0.03);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.03) + ((coast - 1000000) * 0.04));
                else
                    coastalRegion += (coast * 0.03);

                if (north > 1000000)
                    northernRegion += ((1000000 * 0.03) + ((north - 1000000) * 0.04));
                else
                    northernRegion += (north * 0.03);

                if (east > 1000000)
                    easternRegion += ((1000000 * 0.05) + ((east - 1000000) * 0.07));
                else
                    easternRegion += (east * 0.05);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.03) + ((leban - 1000000) * 0.04));
                else
                    lebanonRegion += (leban * 0.03);
            }
            else if (SalesPersonRegion.Equals("lebanon"))
            {


                if (south > 1000000)
                    southernRegion += ((1000000 * 0.03) + ((south - 1000000) * 0.04));
                else
                    southernRegion += (south * 0.03);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.03) + ((coast - 1000000) * 0.04));
                else
                    coastalRegion += (coast * 0.03);

                if (north > 1000000)
                    northernRegion += ((1000000 * 0.03) + ((north - 1000000) * 0.04));
                else
                    northernRegion += (north * 0.03);

                if (east > 1000000)
                    easternRegion += ((1000000 * 0.03) + ((east - 1000000) * 0.04));
                else
                    easternRegion += (east * 0.03);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.05) + ((leban - 1000000) * 0.07));
                else
                    lebanonRegion += (leban * 0.05);


            }

            try
            {
                var comnew = new CommissionT();
                comnew.SalesPersonID = Int32.Parse(SalesPersonID);

                try
                {
                    comnew.CommMonth = Int32.Parse(CommMonth);
                    comnew.CommYear = Int32.Parse(CommYear);
                }
                catch
                {
                    string str = "check Month Or Year .. error";
                    return RedirectToAction("AddNewCommission", new { error = str });
                }
                comnew.CommSouthern = Convert.ToDecimal(southernRegion);
                comnew.CommCoastal = Convert.ToDecimal(coastalRegion);
                comnew.CommNorthern = Convert.ToDecimal(northernRegion);
                comnew.CommEastern = Convert.ToDecimal(easternRegion);
                comnew.CommLebanon = Convert.ToDecimal(lebanonRegion);
                comnew.CommTotal = Convert.ToDecimal(southernRegion + coastalRegion + northernRegion + easternRegion + lebanonRegion);
                dbtities.CommissionT.Add(comnew);
                dbtities.SaveChanges();

                return RedirectToAction("DisplayCommissionD", new { id = comnew.CommID.ToString() });
            }
            catch
            {
                string str = "check data .. error";
                return RedirectToAction("AddNewCommission", new { error = str });
            }


            
        }


        [HttpPost]
        public ActionResult AddNewCommission(string id,string region, string month,string year,string southern ,string coastal,
                                           string northern,string eastern,string lebanon )
        {



            int south = Int32.Parse(southern);
            int coast = Int32.Parse(coastal);
            int north = Int32.Parse(northern);
            int east = Int32.Parse(eastern);
            int leban = Int32.Parse(lebanon);

            double southernRegion = 0;
            double coastalRegion = 0;
            double northernRegion = 0;
            double easternRegion = 0;
            double lebanonRegion = 0;

           
                if (region.Equals("southern")){

                if (south > 1000000)
                    southernRegion += ((1000000 * 0.05) + ((south - 1000000) * 0.07));
                else
                    southernRegion += (south * 0.05);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.03) + ((coast - 1000000) * 0.04));
                else
                    coastalRegion += (coast * 0.03);

                if (north > 1000000) northernRegion += ((1000000 * 0.03) + ((north - 1000000) * 0.04));
                else northernRegion += (north * 0.03);

                if (east > 1000000)
                    easternRegion += ((1000000 * 0.03) + ((east - 1000000) * 0.04));
                else
                    easternRegion += (east * 0.03);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.03) + ((leban - 1000000) * 0.04));
                else
                    lebanonRegion += (leban * 0.03);

            }else if (region.Equals("coastal"))
            {

                if (south > 1000000)
                    southernRegion += ((1000000 * 0.03) + ((south - 1000000) * 0.04));
                else
                    southernRegion += (south * 0.03);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.05) + ((coast - 1000000) * 0.07));
                    else
                    coastalRegion += (coast * 0.05);
                                
                if (north > 1000000)
                    northernRegion += ((1000000 * 0.03) + ((north - 1000000) * 0.04));
                    else
                    northernRegion += (north * 0.03);

                if (east > 1000000)
                    easternRegion += ((1000000 * 0.03) + ((east - 1000000) * 0.04));
                    else
                    easternRegion += (east * 0.03);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.03) + ((leban - 1000000) * 0.04));
                    else
                    lebanonRegion += (leban * 0.03);

            }
            else if (region.Equals("northern"))
            {

                if (south > 1000000)
                    southernRegion += ((1000000 * 0.03) + ((south - 1000000) * 0.04));
                else
                    southernRegion += (south * 0.03);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.03) + ((coast - 1000000) * 0.04));
                else
                    coastalRegion += (coast * 0.03);

                if (north > 1000000)
                    northernRegion += ((1000000 * 0.05) + ((north - 1000000) * 0.07));
                else
                    northernRegion += (north * 0.05);
                
                if (east > 1000000)
                    easternRegion += ((1000000 * 0.03) + ((east - 1000000) * 0.04));
                else
                    easternRegion += (east * 0.03);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.03) + ((leban - 1000000) * 0.04));
                else
                    lebanonRegion += (leban * 0.03);

            }
            else if (region.Equals("eastern"))
            {
                
                if (south > 1000000)
                    southernRegion += ((1000000 * 0.03) + ((south - 1000000) * 0.04));
                else
                    southernRegion += (south * 0.03);

                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.03) + ((coast - 1000000) * 0.04));
                else
                    coastalRegion += (coast * 0.03);

                if (north > 1000000)
                    northernRegion += ((1000000 * 0.03) + ((north - 1000000) * 0.04));
                else
                    northernRegion += (north * 0.03);
                              
                if (east > 1000000)
                    easternRegion += ((1000000 * 0.05) + ((east - 1000000) * 0.07));
                else
                    easternRegion += (east * 0.05);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.03) + ((leban - 1000000) * 0.04));
                else
                    lebanonRegion += (leban * 0.03);
            }
            else if (region.Equals("lebanon"))
            {


                if (south > 1000000)
                    southernRegion += ((1000000 * 0.03) + ((south - 1000000) * 0.04));
                else
                    southernRegion += (south * 0.03);
               
                if (coast > 1000000)
                    coastalRegion += ((1000000 * 0.03) + ((coast - 1000000) * 0.04));
                else
                    coastalRegion += (coast * 0.03);

                if (north > 1000000)
                    northernRegion += ((1000000 * 0.03) + ((north - 1000000) * 0.04));
                else
                    northernRegion += (north * 0.03);

                if (east > 1000000)
                    easternRegion += ((1000000 * 0.03) + ((east - 1000000) * 0.04));
                else
                    easternRegion += (east * 0.03);

                if (leban > 1000000)
                    lebanonRegion += ((1000000 * 0.05) + ((leban - 1000000) * 0.07));
                else
                    lebanonRegion += (leban * 0.05);


            }
            var comnew = new CommissionT();
            try
            {
              
                comnew.SalesPersonID = Int32.Parse(id);

                try { 
                comnew.CommMonth = Int32.Parse(month);
                comnew.CommYear = Int32.Parse(year);
                }
                catch
                {
                    string str = "check Month Or Year .. error";
                    return RedirectToAction("AddNewCommission", new { error = str });
                }
                comnew.CommSouthern = Convert.ToDecimal(southernRegion);
                comnew.CommCoastal = Convert.ToDecimal(coastalRegion);
                comnew.CommNorthern = Convert.ToDecimal(northernRegion);
                comnew.CommEastern = Convert.ToDecimal(easternRegion);
                comnew.CommLebanon = Convert.ToDecimal(lebanonRegion);
                comnew.CommTotal = Convert.ToDecimal(southernRegion +coastalRegion+ northernRegion+ easternRegion+ lebanonRegion);

                dbtities.CommissionT.Add(comnew);
                dbtities.SaveChanges();
            }
            catch {
                string str= "check data .. error";
                return RedirectToAction("AddNewCommission",new { error = str });
            }


            return RedirectToAction("DisplayCommission",new { id = comnew.CommID.ToString() });
        }
        public ActionResult DisplayCommission(string id)
        {
            int comid = Int32.Parse(id);
            
            var com = dbtities.CommissionT.Where(p => p.CommID == comid).SingleOrDefault();


            return View(com);
        }










        public ActionResult DisplayCommissionD(string id)
        {
            int comID = Int32.Parse(id);
            var com = dbtities.CommissionT.Where(p => p.CommID == comID).Select(person => new
            {
                SalesPersonNumber = person.SalesPersonT.SalesPersonNumber,
                SalesPersonRegioin = person.SalesPersonT.SalesPersonRegion,
                SalesPersonRegisterDay = person.SalesPersonT.SalesPersonRegisterDay,
                SalesPersonRegisterMonth = person.SalesPersonT.SalesPersonRegisterMonth,
                SalesPersonRegisterYear = person.SalesPersonT.SalesPersonRegisterYear,
                SalesPersonName = person.SalesPersonT.SalesPersonName,
                CommNorthern = person.CommNorthern,
                CommSouthern = person.CommSouthern,
                CommEastern = person.CommEastern,
                CommCoastal = person.CommCoastal,
                CommLebanon = person.CommLebanon,
                CommTotal = person.CommTotal,
                CommMonth = person.CommMonth,
                CommYear = person.CommYear
            }).SingleOrDefault();


            return Json(com, JsonRequestBehavior.AllowGet);
        }
    }
}