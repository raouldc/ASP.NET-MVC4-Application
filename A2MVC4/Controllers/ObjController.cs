using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A2MVC4.Controllers
{
    public class ObjController : Controller
    {
        //
        // GET: /Obj/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HtmlObj()
        {
            var Products = ProductsList;
            var Categories = CategoriesList;
            var Suppliers = SuppliersList;

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
            //r.Skip(3).Take(3).Dump("r");
            List<JointProductModel> listP = (from p in r orderby p.ProductID select p).ToList();
            return View(listP);
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

        List<ProductModel> ProductsList = new List<ProductModel> { 
  new ProductModel (ProductID: 1, ProductName: "Chai!", CategoryID: 1, SupplierID: 1), 
  new ProductModel (ProductID: 2, ProductName: "Chang", CategoryID: 1, SupplierID: 29), 
  new ProductModel (ProductID: 3, ProductName: "Aniseed Syrup", CategoryID: 2, SupplierID: 1), 
  new ProductModel (ProductID: 4, ProductName: "Chef Anton's Cajun Seasoning", CategoryID: 2, SupplierID: 2), 
  new ProductModel (ProductID: 5, ProductName: "Chef Anton's Gumbo Mix", CategoryID: 2, SupplierID: 2), 
  new ProductModel (ProductID: 6, ProductName: "Grandma's Boysenberry Spread", CategoryID: 2, SupplierID: 3), 
  new ProductModel (ProductID: 7, ProductName: "Uncle Bob's Organic Dried Pears", CategoryID: 7, SupplierID: 3), 
  new ProductModel (ProductID: 8, ProductName: "Northwoods Cranberry Sauce", CategoryID: 2, SupplierID: 3), 
  new ProductModel (ProductID: 9, ProductName: "Mishi Kobe Niku", CategoryID: 6, SupplierID: 4), 
  new ProductModel (ProductID: 10, ProductName: "Ikura", CategoryID: 8, SupplierID: 4), 
  new ProductModel (ProductID: 11, ProductName: "Queso Cabrales", CategoryID: 4, SupplierID: 5), 
  new ProductModel (ProductID: 12, ProductName: "Queso Manchego La Pastora", CategoryID: 4, SupplierID: 5), 
  new ProductModel (ProductID: 13, ProductName: "Konbu", CategoryID: 8, SupplierID: 6), 
  new ProductModel (ProductID: 14, ProductName: "Tofu", CategoryID: 7, SupplierID: 6), 
  new ProductModel (ProductID: 15, ProductName: "Genen Shouyu", CategoryID: 2, SupplierID: 6), 
  new ProductModel (ProductID: 16, ProductName: "Pavlova", CategoryID: 3, SupplierID: 7), 
  new ProductModel (ProductID: 17, ProductName: "Alice Mutton", CategoryID: 6, SupplierID: 7), 
  new ProductModel (ProductID: 18, ProductName: "Carnarvon Tigers", CategoryID: 8, SupplierID: 7), 
  new ProductModel (ProductID: 19, ProductName: "Teatime Chocolate Biscuits", CategoryID: 3, SupplierID: 8), 
  new ProductModel (ProductID: 20, ProductName: "Sir Rodney's Marmalade", CategoryID: 3, SupplierID: 8), 
  new ProductModel (ProductID: 21, ProductName: "Sir Rodney's Scones", CategoryID: 3, SupplierID: 8), 
  new ProductModel (ProductID: 22, ProductName: "Gustaf's KnÃ¤ckebrÃ¶d", CategoryID: 5, SupplierID: 9), 
  new ProductModel (ProductID: 23, ProductName: "TunnbrÃ¶d", CategoryID: 5, SupplierID: 9), 
  new ProductModel (ProductID: 24, ProductName: "GuaranÃ¡ FantÃ¡stica", CategoryID: 1, SupplierID: 10), 
  new ProductModel (ProductID: 25, ProductName: "NuNuCa NuÃŸ-Nougat-Creme", CategoryID: 3, SupplierID: 11), 
  new ProductModel (ProductID: 26, ProductName: "GumbÃ¤r GummibÃ¤rchen", CategoryID: 3, SupplierID: 11), 
  new ProductModel (ProductID: 27, ProductName: "Schoggi Schokolade", CategoryID: 3, SupplierID: 11), 
  new ProductModel (ProductID: 28, ProductName: "RÃ¶ssle Sauerkraut", CategoryID: 7, SupplierID: 12), 
  new ProductModel (ProductID: 29, ProductName: "ThÃ¼ringer Rostbratwurst", CategoryID: 6, SupplierID: 12), 
  new ProductModel (ProductID: 30, ProductName: "Nord-Ost Matjeshering", CategoryID: 8, SupplierID: 13), 
  new ProductModel (ProductID: 31, ProductName: "Gorgonzola Telino", CategoryID: 4, SupplierID: 14), 
  new ProductModel (ProductID: 32, ProductName: "Mascarpone Fabioli", CategoryID: 4, SupplierID: 14), 
  new ProductModel (ProductID: 33, ProductName: "Geitost", CategoryID: 4, SupplierID: 15), 
  new ProductModel (ProductID: 34, ProductName: "Sasquatch Ale", CategoryID: 1, SupplierID: 16), 
  new ProductModel (ProductID: 35, ProductName: "Steeleye Stout", CategoryID: 1, SupplierID: 16), 
  new ProductModel (ProductID: 36, ProductName: "Inlagd Sill", CategoryID: 8, SupplierID: 17), 
  new ProductModel (ProductID: 37, ProductName: "Gravad lax", CategoryID: 8, SupplierID: 17), 
  new ProductModel (ProductID: 38, ProductName: "CÃ´te de Blaye", CategoryID: 1, SupplierID: 18), 
  new ProductModel (ProductID: 39, ProductName: "Chartreuse verte", CategoryID: 1, SupplierID: 18), 
  new ProductModel (ProductID: 40, ProductName: "Boston Crab Meat", CategoryID: 8, SupplierID: 19), 
  new ProductModel (ProductID: 41, ProductName: "Jack's New England Clam Chowder", CategoryID: 8, SupplierID: 19), 
  new ProductModel (ProductID: 42, ProductName: "Singaporean Hokkien Fried Mee", CategoryID: 5, SupplierID: 20), 
  new ProductModel (ProductID: 43, ProductName: "Ipoh Coffee", CategoryID: 1, SupplierID: 20), 
  new ProductModel (ProductID: 44, ProductName: "Gula Malacca", CategoryID: 2, SupplierID: 20), 
  new ProductModel (ProductID: 45, ProductName: "Rogede sild", CategoryID: 8, SupplierID: 21), 
  new ProductModel (ProductID: 46, ProductName: "Spegesild", CategoryID: 8, SupplierID: 21), 
  new ProductModel (ProductID: 47, ProductName: "Zaanse koeken", CategoryID: 3, SupplierID: 22), 
  new ProductModel (ProductID: 48, ProductName: "Chocolade", CategoryID: 3, SupplierID: 22), 
  new ProductModel (ProductID: 49, ProductName: "Maxilaku", CategoryID: 3, SupplierID: 23), 
  new ProductModel (ProductID: 50, ProductName: "Valkoinen suklaa", CategoryID: 3, SupplierID: 23), 
  new ProductModel (ProductID: 51, ProductName: "Manjimup Dried Apples", CategoryID: 7, SupplierID: 24), 
  new ProductModel (ProductID: 52, ProductName: "Filo Mix", CategoryID: 5, SupplierID: 24), 
  new ProductModel (ProductID: 53, ProductName: "Perth Pasties", CategoryID: 6, SupplierID: 24), 
  new ProductModel (ProductID: 54, ProductName: "TourtiÃ¨re", CategoryID: 6, SupplierID: 25), 
  new ProductModel (ProductID: 55, ProductName: "PÃ¢tÃ© chinois", CategoryID: 6, SupplierID: 25), 
  new ProductModel (ProductID: 56, ProductName: "Gnocchi di nonna Alice", CategoryID: 5, SupplierID: 26), 
  new ProductModel (ProductID: 57, ProductName: "Ravioli Angelo", CategoryID: 5, SupplierID: 26), 
  new ProductModel (ProductID: 58, ProductName: "Escargots de Bourgogne", CategoryID: 8, SupplierID: 27), 
  new ProductModel (ProductID: 59, ProductName: "Raclette Courdavault", CategoryID: 4, SupplierID: 28), 
  new ProductModel (ProductID: 60, ProductName: "Camembert Pierrot", CategoryID: 4, SupplierID: 28), 
  new ProductModel (ProductID: 61, ProductName: "Sirop d'Ã©rable", CategoryID: 2, SupplierID: 29), 
  new ProductModel (ProductID: 62, ProductName: "Tarte au sucre", CategoryID: 3, SupplierID: 29), 
  new ProductModel (ProductID: 63, ProductName: "Vegie-spread", CategoryID: 2, SupplierID: 7), 
  new ProductModel (ProductID: 64, ProductName: "Wimmers gute SemmelknÃ¶del", CategoryID: 5, SupplierID: 12), 
  new ProductModel (ProductID: 65, ProductName: "Louisiana Fiery Hot Pepper Sauce", CategoryID: 2, SupplierID: 2), 
  new ProductModel (ProductID: 66, ProductName: "Louisiana Hot Spiced Okra", CategoryID: 2, SupplierID: 2), 
  new ProductModel (ProductID: 67, ProductName: "Laughing Lumberjack Lager", CategoryID: 1, SupplierID: 16), 
  new ProductModel (ProductID: 68, ProductName: "Scottish Longbreads", CategoryID: 3, SupplierID: 8), 
  new ProductModel (ProductID: 69, ProductName: "Gudbrandsdalsost", CategoryID: 4, SupplierID: 15), 
  new ProductModel (ProductID: 70, ProductName: "Outback Lager", CategoryID: 1, SupplierID: 7), 
  new ProductModel (ProductID: 71, ProductName: "Flotemysost", CategoryID: 4, SupplierID: 15), 
  new ProductModel (ProductID: 72, ProductName: "Mozzarella di Giovanni", CategoryID: 4, SupplierID: 14), 
  new ProductModel (ProductID: 73, ProductName: "RÃ¶d Kaviar", CategoryID: 8, SupplierID: 17), 
  new ProductModel (ProductID: 74, ProductName: "Longlife Tofu", CategoryID: 7, SupplierID: 4), 
  new ProductModel (ProductID: 75, ProductName: "RhÃ¶nbrÃ¤u Klosterbier", CategoryID: 1, SupplierID: 12), 
  new ProductModel (ProductID: 76, ProductName: "LakkalikÃ¶Ã¶ri", CategoryID: 1, SupplierID: 23), 
  new ProductModel (ProductID: 77, ProductName: "Original Frankfurter grÃ¼ne SoÃŸe", CategoryID: 2, SupplierID: 12), 
};

        List<CategoryModel> CategoriesList = new List<CategoryModel> { 
  new CategoryModel (CategoryID: 1, CategoryName: "Beverages"), 
  new CategoryModel (CategoryID: 30, CategoryName: "Biscuits"), 
  new CategoryModel (CategoryID: 2, CategoryName: "Condiments"), 
  new CategoryModel (CategoryID: 3, CategoryName: "Confections"), 
  new CategoryModel (CategoryID: 4, CategoryName: "Dairy Products"), 
  new CategoryModel (CategoryID: 5, CategoryName: "Grains/Cereals"), 
  new CategoryModel (CategoryID: 6, CategoryName: "Meat/Poultry"), 
  new CategoryModel (CategoryID: 7, CategoryName: "Produce"), 
  new CategoryModel (CategoryID: 8, CategoryName: "Seafood"), 
};

        List<SupplierModel> SuppliersList = new List<SupplierModel> { 
  new SupplierModel (SupplierID: 1, CompanyName: "Exotic Liquids", Country: "UK"), 
  new SupplierModel (SupplierID: 2, CompanyName: "New Orleans Cajun Delights", Country: "USA"), 
  new SupplierModel (SupplierID: 3, CompanyName: "Grandma Kelly's Homestead", Country: "USA"), 
  new SupplierModel (SupplierID: 4, CompanyName: "Tokyo Traders", Country: "Japan"), 
  new SupplierModel (SupplierID: 5, CompanyName: "Cooperativa de Quesos 'Las Cabras'", Country: "Spain"), 
  new SupplierModel (SupplierID: 6, CompanyName: "Mayumi's", Country: "Japan"), 
  new SupplierModel (SupplierID: 7, CompanyName: "Pavlova, Ltd.", Country: "Australia"), 
  new SupplierModel (SupplierID: 8, CompanyName: "Specialty Biscuits, Ltd.", Country: "UK"), 
  new SupplierModel (SupplierID: 9, CompanyName: "PB KnÃ¤ckebrÃ¶d AB", Country: "Sweden"), 
  new SupplierModel (SupplierID: 10, CompanyName: "Refrescos Americanas LTDA", Country: "Brazil"), 
  new SupplierModel (SupplierID: 11, CompanyName: "Heli SÃ¼ÃŸwaren GmbH & Co. KG", Country: "Germany"), 
  new SupplierModel (SupplierID: 12, CompanyName: "Plutzer LebensmittelgroÃŸmÃ¤rkte AG", Country: "Germany"), 
  new SupplierModel (SupplierID: 13, CompanyName: "Nord-Ost-Fisch Handelsgesellschaft mbH", Country: "Germany"), 
  new SupplierModel (SupplierID: 14, CompanyName: "Formaggi Fortini s.r.l.", Country: "Italy"), 
  new SupplierModel (SupplierID: 15, CompanyName: "Norske Meierier", Country: "Norway"), 
  new SupplierModel (SupplierID: 16, CompanyName: "Bigfoot Breweries", Country: "USA"), 
  new SupplierModel (SupplierID: 17, CompanyName: "Svensk SjÃ¶fÃ¶da AB", Country: "Sweden"), 
  new SupplierModel (SupplierID: 18, CompanyName: "Aux joyeux ecclÃ©siastiques", Country: "France"), 
  new SupplierModel (SupplierID: 19, CompanyName: "New England Seafood Cannery", Country: "USA"), 
  new SupplierModel (SupplierID: 20, CompanyName: "Leka Trading", Country: "Singapore"), 
  new SupplierModel (SupplierID: 21, CompanyName: "Lyngbysild", Country: "Denmark"), 
  new SupplierModel (SupplierID: 22, CompanyName: "Zaanse Snoepfabriek", Country: "Netherlands"), 
  new SupplierModel (SupplierID: 23, CompanyName: "Karkki Oy", Country: "Finland"), 
  new SupplierModel (SupplierID: 24, CompanyName: "G'day, Mate", Country: "Australia"), 
  new SupplierModel (SupplierID: 25, CompanyName: "Ma Maison", Country: "Canada"), 
  new SupplierModel (SupplierID: 26, CompanyName: "Pasta Buttini s.r.l.", Country: "Italy"), 
  new SupplierModel (SupplierID: 27, CompanyName: "Escargots Nouveaux", Country: "France"), 
  new SupplierModel (SupplierID: 28, CompanyName: "Gai pÃ¢turage", Country: "France"), 
  new SupplierModel (SupplierID: 29, CompanyName: "ForÃªts d'Ã©rables", Country: "Canada"), 
};



    }
}
