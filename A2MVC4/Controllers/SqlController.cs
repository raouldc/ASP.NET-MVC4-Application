using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A2MVC4.Controllers
{
    public class SqlController : Controller
    {
        //
        // GET: /Sql/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WebGrid(int page = 1, int rowsPerPage = 10, string sort = "ProductId", string sortDir = "ASC")
        {
            NorthwindConnection nwd = new northwndEntities();

            var r =
                from p in nwd.Products
                join c in nwd.Categories
                on p.CategoryID equals c.CategoryID
                join s in nwd.Suppliers
                on p.SupplierID equals s.SupplierID
                orderby c.CategoryName, p.ProductID
                select new JointProductModel
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    CategoryName = c.CategoryName,
                    CompanyName = s.CompanyName,
                    Country = s.Country
                };

            ViewBag.rows = (int)(r.Count() / (double)rowsPerPage * 10.0);

            JointProductModelList = (from p in r
                                     orderby p.ProductID
                                     select p).ToList();

            if (rowsPerPage != null)
            {
                this.rowsPerPage = Convert.ToInt32(rowsPerPage);
                @ViewBag.rowsPerPage = rowsPerPage;
            }

            var currentPage = GetListPage(page, rowsPerPage, sort, sortDir);

            var data = new PagedJointProductModel()
            {
                TotalRows = JointProductModelList.Count(),
                PageSize = rowsPerPage,
                PagedProductModel = currentPage
            };
            //var r = JointProductModelList.OrderBy(p => p.ProductID).Skip((page - 1) * rowsPerPage).Take(rowsPerPage).ToList();

            return View(data);
        }
    }
}
