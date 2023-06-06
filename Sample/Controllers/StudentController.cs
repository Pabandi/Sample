using System;
using System.Collections.Generic;
using System.Linq;
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
            var students = db.T_Student;

            return View(students);
        }
    }
}