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

        public ActionResult Index()
        {
            calculate(3, 4); //initialize with 3 and 4
            return View();
        }

        [HttpPost]
        public ActionResult eval(double M, double N)
        {
            calculate(M, N);
            return View();
        }

        private void calculate(double M, double N)
        {
            ViewBag.Add = "M + N = " + (M + N).ToString();
            ViewBag.Subtract = "M - N = " + (M - N).ToString();
            ViewBag.Multiply = "M * N = " + (M * N).ToString();
            ViewBag.Divide = "M / N = " + ((int)(M / N)).ToString();
            ViewBag.Mod = "M % N = " + (M % N).ToString();
        }
    }
}
