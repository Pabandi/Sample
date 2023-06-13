using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
            
            return PartialView(students);
        }




        [HttpGet]
        public  ActionResult Create()
        {
            return View();  
        }



        [HttpPost]
        public ActionResult Create( [Bind(Include = "Name, Family, Mobile, email, gender" )] T_Student student)
        {
            if (student.Name == null)
            {
                ModelState.AddModelError("Name", "this field cannot be empty");
            }
            if (student.Family == null)
            {
                ModelState.AddModelError("family", "this field cannot be empty");
            }
            if (student.Mobile == null)
            {
                ModelState.AddModelError("mobile", "this field cannot be empty");
            }
            else
            {
                if (!Regex.IsMatch(student.Mobile, "^\\+?[1-9][0-9]{7,14}$"))
                {
                    ModelState.AddModelError("mobile", "this pattern is not true(+12223334444)");
                }
            }
            if (student.email == null)
            {
                ModelState.AddModelError("email", "this field cannot be empty");
            }
            else
            {
                if (!Regex.IsMatch(student.email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
                {
                    ModelState.AddModelError("email", "this pattern is not true");
                }
            }
         
            if (ModelState.IsValid)
            {
                
                student.IsActive = true;
                db.T_Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
         
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = db.T_Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
    

        [HttpGet]
        public  ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = db.T_Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id ,Name, Family, Mobile, email, gender , IsActive")] T_Student student)
        {
            if (student.Name == null)
            {
                ModelState.AddModelError("Name", "this field cannot be empty");
            }
            if (student.Family == null)
            {
                ModelState.AddModelError("family", "this field cannot be empty");
            }
            if (student.Mobile == null)
            {
                ModelState.AddModelError("mobile", "this field cannot be empty");
            }
            else
            {
                if (!Regex.IsMatch(student.Mobile, "^\\+?[1-9][0-9]{7,14}$"))
                {
                    ModelState.AddModelError("mobile", "this pattern is not true(+12223334444)");
                }
            }
            if (student.email == null)
            {
                ModelState.AddModelError("email", "this field cannot be empty");
            }
            else
            {
                if (!Regex.IsMatch(student.email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
                {
                    ModelState.AddModelError("email", "this pattern is not true");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);


        }




        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (HttpStatusCode.BadRequest);
            }

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
