using ShopBotTelegram.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace ShopBotTelegram.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            List<Product> product;
            using (UpdateDbContext db = new UpdateDbContext())
            {
               // var products = db.Products.Include(p => p.Category);
                product =db.Products.ToList();
                var cat = db.Categorys.ToList();
                string s = "sadsa";
            }
           
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}