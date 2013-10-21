using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A2MVC4.Controllers
{
    public class ArithController : Controller
    {
        //
        // GET: /Arith/

        public ActionResult Index(double m = 3, double n = 4)
        {
            ViewBag.m = m;
            ViewBag.n = n;
            calculate(m, n); //initialize with 3 and 4
            return View();
        }

        private void calculate(double M, double N)
        {
            ViewBag.Add = "M + N = " + (M + N).ToString();
            ViewBag.Subtract = "M - N = " + (M - N).ToString();
            ViewBag.Multiply = "M * N = " + (M * N).ToString();
            if (N == 0)
            {
                ViewBag.Divide = "M / N = ?";
                ViewBag.Mod = "M % N = ?";
            }
            else
            {
                ViewBag.Divide = "M / N = " + ((int)(M / N)).ToString();
                ViewBag.Mod = "M % N = " + (M % N).ToString();
            }

        }
    }
}
