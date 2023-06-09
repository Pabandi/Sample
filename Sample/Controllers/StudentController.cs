using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sample.Models;



namespace Sample.Controllers
{
    public class StudentController : Controller
    {
        StudentEntities db = new StudentEntities();


        // GET: Student
        public ActionResult Index()
        {
            var students = db.T_Student.ToList();
            
            return View(students);
        }

        [HttpGet]
        public  ActionResult Create()
        {
            return View();  
        }



        [HttpPost]
        public ActionResult Create( [Bind(Include = "Name, Family, Mobile, email, gender" )] T_Student student)
        {
            if (ModelState.IsValid)
            {
                student.IsActive = true;
                db.T_Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
         
        }

        public ActionResult Details(int id)
        {
            var student = db.T_Student.Find(id);    
            return View(student);
        }



        [HttpGet]
        public  ActionResult Edite()
        {
            return View();  
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {

            var student = db.T_Student.Find(id);
            return View(student);
        }


        [HttpPost , ActionName("Delete")]
        public ActionResult Deletes( int id)
        {
            var student = db.T_Student.Find(id);
            if (student != null)
            {
                db.T_Student.Remove(student);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
