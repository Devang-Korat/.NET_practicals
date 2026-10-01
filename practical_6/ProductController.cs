using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pr6.Models;

namespace pr6.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> p = new List<Product>();
            p = GetProducts();
            return View(p);
        }

        public ActionResult Details(int id) {
            List<Product> PALL = GetProducts();
            Product P1 = PALL.FirstOrDefault(p => p.ProductId == id);
            return View(P1);
        }

        private List<Product> GetProducts() {
            return new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    Description = "Dell Laptop",
                    Price = 55000,
                    Category = "Electronics"
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Mobile",
                    Description = "Samsung Mobile",
                    Price = 55000,
                    Category = "Electronics"
                }
            };
        }
    }
}
