using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OppositeEnds.Models;
using System.Data.Entity;
using OppositeEnds.ViewModels;
using System.IO;

namespace OppositeEnds.Controllers
{
  

    public class HomeController : Controller
    {
        private OppositeEndsContext db = new OppositeEndsContext();

        public ActionResult Index()
        {
            var Floral = db.Florals.ToList();
            var Furniture = db.furnitures.ToList();
            var viewModels = new storefrontitemsView

       {
                florals = Floral,
                furnitures = Furniture
        };
            
               return View(viewModels);
            
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
        public ActionResult VintageIndex()
        {


            return View();
        }
        public ActionResult Show(int id)
        {
            // to do : Using the id passed in,build the path to your pdf file

            var pathToTheFile = Server.MapPath("~/Content/VCmenu.pdf");
            var fileStream = new FileStream(pathToTheFile,
                                                FileMode.Open,
                                                FileAccess.Read
                                            );
            return new FileStreamResult(fileStream, "application/pdf");
        }
    }
}