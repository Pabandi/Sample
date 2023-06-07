﻿using System;
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
    }
}