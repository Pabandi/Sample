﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult PartialHeader()
        {
            return PartialView();
        }



        public ActionResult PartialFooter()
        {
            return PartialView();
        }
    }
}