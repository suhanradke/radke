using OppositeEnds.Models;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace OppositeEnds.Controllers
{
    public class FloralsController : Controller

    {
        private OppositeEndsContext db = new OppositeEndsContext();
       
        [Authorize]
        //GET: Florals
        public ActionResult Index()
        {
            return View(db.Florals.ToList());
        }

        // GET: Florals/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floral floral = db.Florals.Find(id);
            if (floral == null)
            {
                return HttpNotFound();
            }
            return View(floral);
        }

        // GET: Florals/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Florals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Quantity,Category,Picture")] Floral floral)
        {
            if (ModelState.IsValid)
            {
    
           
               db.Florals.Add(floral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

            return View(floral);
        }

        // GET: Florals/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floral floral = db.Florals.Find(id);
            if (floral == null)
            {
                return HttpNotFound();
            }
            return View(floral);
        }

        // POST: Florals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "FloralId,Name,Price,Quantity,Details,Category,Picture")] Floral floral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(floral);
        }

        // GET: Florals/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floral floral = db.Florals.Find(id);
            if (floral == null)
            {
                return HttpNotFound();
            }
            return View(floral);
        }

        // POST: Florals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Floral floral = db.Florals.Find(id);
            db.Florals.Remove(floral);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: FloralFront

        //public ActionResult FloralFront()
        //{
        //   var floral = db.Florals.ToList();

        //    return View(floral);

        
        //}
        public ActionResult FloralFront(string sortOrder, string currentFilter, string searchString, string searchCategory, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
            if (searchString != null || searchCategory != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                searchCategory = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
           

            var florals = from s in db.Florals
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                florals = florals.Where(s => s.Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchCategory))
            {
                florals = florals.Where(s => s.Category.Contains(searchCategory));
                ViewBag.Message = "Search results for";
                ViewBag.Search = searchCategory;
            }
            switch (sortOrder)
            {
                case "name_desc":
                    florals = florals.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    florals = florals.OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    florals = florals.OrderByDescending(s => s.Price);
                    break;
                default:
                    florals = florals.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(florals.ToPagedList(pageNumber, pageSize));


        }

        // GET: FloralFront

        public ActionResult productdetails(int? id)
        {
            var florals = db.Florals.SingleOrDefault(c => c.FloralId == id);
            if (florals == null)
            {
                return HttpNotFound();
            }
            return View(florals);
        }

    }
}
