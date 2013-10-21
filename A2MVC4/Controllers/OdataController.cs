using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A2MVC4.Controllers
{
    public class OdataController : Controller
    {
        //
        // GET: /Odata/

        List<JointProductModel> JointProductModelList = new List<JointProductModel>();
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
            string sortTable = "";

            var nwd = new DataServiceContext(new Uri("http://services.odata.org/Northwind/Northwind.svc/"));

            switch (sort)
            {
                case "CategoryName": sortTable = "Category/CategoryName"; break;
                case "CompanyName": sortTable = "Supplier/CompanyName"; break;
                case "Country": sortTable = "Supplier/Country"; break;
                case "ProductID": sortTable = "ProductID"; break;
                case "ProductName": sortTable = "ProductName"; break;
            }

            var Products2 =
       (QueryOperationResponse<Product>)nwd.Execute<Product>(
       new Uri("http://services.odata.org/Northwind/Northwind.svc/Products()?$inlinecount=allpages&$orderby=" + sortTable + " " + sortDir.ToLower() + ",ProductID&$skip=" + (page - 1) * rowsPerPage + "&$top=" + rowsPerPage + "&$expand=Category,Supplier&$select=ProductID,ProductName,Category/CategoryName,Supplier/CompanyName,Supplier/Country"));             //Products2.Dump("Products2");
            var products2List = Products2.ToList();
            var m = Products2.TotalCount;
            //m.Dump("m");

            ViewBag.rows = (int)(Products2.TotalCount);

            var t = from p in products2List
                    select new JointProductModel
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        CategoryName = p.Category.CategoryName,
                        CompanyName = p.Supplier.CompanyName,
                        Country = p.Supplier.Country
                    };


            return View(t);
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


        public class JointProductModel
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
            public string CompanyName { get; set; }
            public string Country { get; set; }
        }

        // Custom Entities

        public partial class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public global::System.Nullable<int> SupplierID { get; set; }
            public global::System.Nullable<int> CategoryID { get; set; }
            //public string QuantityPerUnit { get; set; }
            //public global::System.Nullable<decimal> UnitPrice { get; set; }
            //public global::System.Nullable<short> UnitsInStock { get; set; }
            //public global::System.Nullable<short> UnitsOnOrder { get; set; }
            //public global::System.Nullable<short> ReorderLevel { get; set; }
            //public bool Discontinued { get; set; }
            public Category Category { get; set; }
            //public global::System.Data.Services.Client.DataServiceCollection<Order_Detail> Order_Details  { get; set; }
            public Supplier Supplier { get; set; }
        }

        public partial class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            //public string Description { get; set; }
            //public byte[] Picture { get; set; }
            //public global::System.Data.Services.Client.DataServiceCollection<Product> Products { get; set; }
        }

        public partial class Supplier
        {
            public int SupplierID { get; set; }
            public string CompanyName { get; set; }
            //public string ContactName { get; set; }
            //public string ContactTitle { get; set; }
            //public string Address { get; set; }
            //public string City { get; set; }
            //public string Region { get; set; }
            //public string PostalCode { get; set; }
            public string Country { get; set; }
            //public string Phone { get; set; }
            //public string Fax { get; set; }
            //public string HomePage { get; set; }
            //public global::System.Data.Services.Client.DataServiceCollection<Product> Products { get; set; }
        }
    }
}
