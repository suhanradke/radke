using OppositeEnds.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OppositeEnds.Controllers
{
    public class FurnitureFrontController : Controller
    {

        private OppositeEndsContext db = new OppositeEndsContext();

        //private OppositeEndsContext _context;
        //public FurnitureFrontController()
        //{
        //    _context = new OppositeEndsContext();
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        // GET: FurnitureFront
       
        public ActionResult Index()
        {

            var furnitures = db.furnitures.ToList();
         
            return View(furnitures);
        }

        public ActionResult productdetails(int? id)
        {
            var furniture = db.furnitures.SingleOrDefault(c => c.Id == id);
            if(furniture==null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

    }
}