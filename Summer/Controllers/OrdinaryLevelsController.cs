using Summer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Summer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdinaryLevelsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: OrdinaryLevels
        public ActionResult Index()
        {
            var ordinaryLevels = db.OrdinaryLevels.Include(o => o.Student);
            return View(ordinaryLevels.ToList());
        }

        // GET: OrdinaryLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdinaryLevel ordinaryLevel = db.OrdinaryLevels.Find(id);
            if (ordinaryLevel == null)
            {
                return HttpNotFound();
            }
            return View(ordinaryLevel);
        }

        // GET: OrdinaryLevels/Create
        public ActionResult Create(int? id)
        {
            List<int> students = new List<int>();

            if (id == null)
            {
                var grades = db.Students.Include(g => g.OrdinaryLevel).ToList();
                var d = grades.Where(c => c.OrdinaryLevel == null);
                foreach (var V in d)
                {
                    students.Add(V.StudentId);
                }
            }

            else
            {
                var grades = db.Students.Include(g => g.OrdinaryLevel)
                    .Where(c => c.StudentId == id).ToList();
                foreach (var V in grades)
                {
                    students.Add(V.StudentId);
                }
            }

            ViewBag.Id = new SelectList(students);

            return View();
        }

        // POST: OrdinaryLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subject_1,Subject_2,Subject_3,Subject_4,Subject_5,Subject_6,Subject_7,Subject_8,Subject_9,Subject_10,Subject_11")] OrdinaryLevel ordinaryLevel)
        {
            if (ModelState.IsValid)
            {
                db.OrdinaryLevels.Add(ordinaryLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Students, "StudentId", "Name", ordinaryLevel.Id);
            return View(ordinaryLevel);
        }

        // GET: OrdinaryLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdinaryLevel ordinaryLevel = db.OrdinaryLevels.Find(id);
            if (ordinaryLevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Students, "StudentId", "Name", ordinaryLevel.Id);
            return View(ordinaryLevel);
        }

        // POST: OrdinaryLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject_1,Subject_2,Subject_3,Subject_4,Subject_5,Subject_6,Subject_7,Subject_8,Subject_9,Subject_10,Subject_11")] OrdinaryLevel ordinaryLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordinaryLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Students, "StudentId", "Name", ordinaryLevel.Id);
            return View(ordinaryLevel);
        }

        // GET: OrdinaryLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdinaryLevel ordinaryLevel = db.OrdinaryLevels.Find(id);
            if (ordinaryLevel == null)
            {
                return HttpNotFound();
            }
            return View(ordinaryLevel);
        }

        // POST: OrdinaryLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdinaryLevel ordinaryLevel = db.OrdinaryLevels.Find(id);
            db.OrdinaryLevels.Remove(ordinaryLevel);
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
    }
}
