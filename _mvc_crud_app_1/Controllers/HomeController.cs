using _mvc_crud_app_1.DB_Context_EF;
using _mvc_crud_app_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _mvc_crud_app_1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(employee obj)
        {
            chetu_employeeEntities obj1 = new chetu_employeeEntities();
            emp_regitration obj3 = new emp_regitration();
            obj3.id = obj.id;
            obj3.name = obj.name;
            obj3.email = obj.email;
            obj3.mobile = obj.mobile;
            obj3.city = obj.city;
            if (obj.id == 0)
            {
                obj1.emp_regitration.Add(obj3);
                obj1.SaveChanges();
            }
            else
            {
                obj1.Entry(obj3).State = System.Data.Entity.EntityState.Modified;
                obj1.SaveChanges();
            }

            return View();
        }
        public ActionResult delete(int ID)
        {
            chetu_employeeEntities obj1 = new chetu_employeeEntities();
            var delet = obj1.emp_regitration.Where(m => m.id == ID).First();
            obj1.emp_regitration.Remove(delet);
            obj1.SaveChanges();

            return RedirectToAction("Contact");
        }

        public ActionResult About()
        {
            
            return View();
        }
        public ActionResult edit(int id)
        {
            employee mod = new employee();
            chetu_employeeEntities obj1 = new chetu_employeeEntities();
            var edt = obj1.emp_regitration.Where(m => m.id == id).First();
             mod.id = edt.id;
             mod.name = edt.name;
             mod.email = edt.email;
             mod.city = edt.city;
             mod.mobile = edt.mobile;
            return View("Index", mod);
        }

        public ActionResult Contact()
        {
            chetu_employeeEntities obj1 = new chetu_employeeEntities();
            var obj = obj1.emp_regitration.ToList();

            return View(obj);
        }
    }
}