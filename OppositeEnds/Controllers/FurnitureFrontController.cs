using OppositeEnds.Models;
using PagedList;
using System;
using System.Linq;
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

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var furnitures = from s in db.furnitures
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                furnitures = furnitures.Where(s => s.Name.Contains(searchString)
                                       || s.Category.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    furnitures = furnitures.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    furnitures = furnitures.OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    furnitures = furnitures.OrderByDescending(s => s.Price);
                    break;
                default:
                    furnitures = furnitures.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(furnitures.ToPagedList(pageNumber, pageSize));


        }

        public ActionResult productdetails(int? id)
        {
            var furniture = db.furnitures.SingleOrDefault(c => c.FurnitureId == id);
            if(furniture==null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

    }
}