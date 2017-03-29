using OppositeEnds.Models;
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
        // GET: Florals
        public ActionResult Index()
        {
            return View(db.Florals.ToList());
        }

        // GET: Florals/Details/5
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Florals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Quantity,Category,Picture")] Floral floral)
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

        public ActionResult FloralFront()
        {
           var floral = db.Florals.ToList();

            return View(floral);

        
        }

        // GET: FloralFront
        
        public ActionResult productdetails(int? id)
        {
            var florals = db.Florals.SingleOrDefault(c => c.Id == id);
            if (florals == null)
            {
                return HttpNotFound();
            }
            return View(florals);
        }
    }
}
