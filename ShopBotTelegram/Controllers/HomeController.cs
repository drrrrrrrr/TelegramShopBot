using ShopBotTelegram.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBotTelegram.Controllers
{
    public class HomeController : Controller
    {
        UpdateDbContext db = new UpdateDbContext();
        public ActionResult Index()
        {
            db.LastUpDates.Add(new LastUpDate { Lastupdate = "0" });
            db.SaveChanges();
            return View();
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