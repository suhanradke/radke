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
        private OppositeEndsContext _Context;

        public FurnitureFrontController()
        {

            _Context = new OppositeEndsContext();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        // GET: FurnitureFront
        public ActionResult Index()
        {
            return View();
        }
    }
}