using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace A2MVC4.Controllers
{
    public class XmlController : Controller
    {
        //
        // GET: /Xml/
        int rowsPerPage = 10;
        string sort = "";
        bool sortBool;
        string sortDir
        {
            set
            {
                if (value.Equals("ASC")) sortBool = true;
                else if (value.Equals("DES")) sortBool = false;
            }
        }
        int page = 1;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WebGrid(int page = 1, int rowsPerPage = 10, string sort = "ProductId", string sortDir = "ASC")
        {
            var Products =
                XElement.Load(Server.MapPath("~/App_Data/XProducts.xml")).
                Elements("Product").
                Select(x => new ProductModel(
                    (int)x.Element("ProductID"),
                    (string)x.Element("ProductName"),
                    (int)x.Element("CategoryID"),
                    (int)x.Element("SupplierID")
                ));

            var Categories =
                XElement.Load(Server.MapPath("~/App_Data/XCategories.xml")).
                Elements("Category").
                Select(x => new CategoryModel(
                    (int)x.Element("CategoryID"),
                    (string)x.Element("CategoryName")
                ));

            var Suppliers =
                XElement.Load(Server.MapPath("~/App_Data/XSuppliers.xml")).
                Elements("Supplier").
                Select(x => new SupplierModel(
                    (int)x.Element("SupplierID"),
                    (string)x.Element("CompanyName"),
                    (string)x.Element("Country")
                ));

            int n = Products.Count();
            //n.Dump("n");

            var r =
                from p in Products
                join c in Categories
                on p.CategoryID equals c.CategoryID
                join s in Suppliers
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
            JointProductModelList = r.ToList();

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
            return View(data);
        }


        private IEnumerable<JointProductModel> GetListPage(int page, int rowsPerPage, string sort, string sortDir)
        {
            if (page < 1)
                page = 1;
            if (sort == "ProductID")

                switch (sortDir)
                {
                    case "ASC":
                        return JointProductModelList.OrderBy(x => x.ProductID)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();

                    case "DESC":
                        return JointProductModelList.OrderByDescending(x => x.ProductID)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();
                    default: return JointProductModelList.OrderBy(x => x.ProductID)
                         .Skip((page - 1) * rowsPerPage)
                         .Take(rowsPerPage)
                         .ToList();

                }

            else if (sort == "ProductName")
                switch (sortDir)
                {
                    case "ASC":
                        return JointProductModelList.OrderBy(x => x.ProductName)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();

                    case "DESC":
                        return JointProductModelList.OrderByDescending(x => x.ProductName)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();
                    default: return JointProductModelList.OrderBy(x => x.ProductID)
                     .Skip((page - 1) * rowsPerPage)
                     .Take(rowsPerPage)
                     .ToList();
                }
            else if (sort == "CategoryName")
                switch (sortDir)
                {
                    case "ASC":
                        return JointProductModelList.OrderBy(x => x.CategoryName)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();

                    case "DESC":
                        return JointProductModelList.OrderByDescending(x => x.CategoryName)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();
                    default: return JointProductModelList.OrderBy(x => x.ProductID)
                     .Skip((page - 1) * rowsPerPage)
                     .Take(rowsPerPage)
                     .ToList();
                }
            else if (sort == "CompanyName")
                switch (sortDir)
                {
                    case "ASC":
                        return JointProductModelList.OrderBy(x => x.CompanyName)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();

                    case "DESC":
                        return JointProductModelList.OrderByDescending(x => x.CompanyName)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();
                    default: return JointProductModelList.OrderBy(x => x.ProductID)
                     .Skip((page - 1) * rowsPerPage)
                     .Take(rowsPerPage)
                     .ToList();
                }
            else if (sort == "Country")
                switch (sortDir)
                {
                    case "ASC":
                        return JointProductModelList.OrderBy(x => x.Country)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();

                    case "DESC":
                        return JointProductModelList.OrderByDescending(x => x.Country)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();
                    default: return JointProductModelList.OrderBy(x => x.Country)
                     .Skip((page - 1) * rowsPerPage)
                     .Take(rowsPerPage)
                     .ToList();
                }
            else
                switch (sortDir)
                {
                    case "ASC":
                        return JointProductModelList.OrderBy(x => x.ProductID)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();

                    case "DESC":
                        return JointProductModelList.OrderByDescending(x => x.ProductID)
                        .Skip((page - 1) * rowsPerPage)
                        .Take(rowsPerPage)
                        .ToList();
                    default: return JointProductModelList.OrderBy(x => x.ProductID)
                     .Skip((page - 1) * rowsPerPage)
                     .Take(rowsPerPage)
                     .ToList();
                }
        }

        public class PagedJointProductModel
        {
            public int TotalRows { get; set; }
            public IEnumerable<JointProductModel> PagedProductModel { get; set; }
            public int PageSize { get; set; }
        }

        List<JointProductModel> JointProductModelList = new List<JointProductModel>();

        void Main()
        {
            
            //r.Skip(3).Take(3).Dump("r");
        }

        public class JointProductModel
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
            public string CompanyName { get; set; }
            public string Country { get; set; }
        }

        public class ProductModel
        {
            public ProductModel(int ProductID, string ProductName, int CategoryID, int SupplierID)
            {
                this.ProductID = ProductID;
                this.ProductName = ProductName;
                this.CategoryID = CategoryID;
                this.SupplierID = SupplierID;
            }
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int? CategoryID { get; set; }
            public int? SupplierID { get; set; }
        }

        public class CategoryModel
        {
            public CategoryModel(int CategoryID, string CategoryName)
            {
                this.CategoryID = CategoryID;
                this.CategoryName = CategoryName;
            }
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }

        public class SupplierModel
        {
            public SupplierModel(int SupplierID, string CompanyName, string Country)
            {
                this.SupplierID = SupplierID;
                this.CompanyName = CompanyName;
                this.Country = Country;
            }
            public int SupplierID { get; set; }
            public string CompanyName { get; set; }
            public string Country { get; set; }
        }

    }
}
