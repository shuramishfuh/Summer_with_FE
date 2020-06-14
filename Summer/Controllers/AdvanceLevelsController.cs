using Summer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Summer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdvanceLevelsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AdvanceLevels
        public ActionResult Index()
        {
            var advanceLevels = db.AdvanceLevels.Include(a => a.Student);
            return View(advanceLevels.ToList());
        }

        // GET: AdvanceLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceLevel advanceLevel = db.AdvanceLevels.Find(id);
            if (advanceLevel == null)
            {
                return HttpNotFound();
            }
            return View(advanceLevel);
        }

        // GET: AdvanceLevels/Create
        public ActionResult Create(int? id)
        {
            List<int> students = new List<int>();

            if (id == null)
            {
                var grades = db.Students.Include(g => g.AdvanceLevel).ToList();
                var d = grades.Where(c => c.AdvanceLevel == null);
                foreach (var V in d)
                {
                    students.Add(V.StudentId);
                }
            }

            else
            {
                var grades = db.Students.Include(g => g.AdvanceLevel)
                    .Where(c => c.StudentId == id).ToList();
                foreach (var V in grades)
                {
                    students.Add(V.StudentId);
                }
            }

            ViewBag.Id = new SelectList(students);



            return View();
        }


        // POST: AdvanceLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subject_1,Subject_2,Subject_3,Subject_4,Subject_5")] AdvanceLevel advanceLevel)
        {
            if (ModelState.IsValid)
            {
                db.AdvanceLevels.Add(advanceLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Students, "StudentId", "Name", advanceLevel.Id);
            return View(advanceLevel);
        }




        // GET: AdvanceLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceLevel advanceLevel = db.AdvanceLevels.Find(id);
            if (advanceLevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Students, "StudentId", "Name", advanceLevel.Id);
            return View(advanceLevel);
        }

        // POST: AdvanceLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject_1,Subject_2,Subject_3,Subject_4,Subject_5")] AdvanceLevel advanceLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advanceLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Students, "StudentId", "Name", advanceLevel.Id);
            return View(advanceLevel);
        }

        // GET: AdvanceLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceLevel advanceLevel = db.AdvanceLevels.Find(id);
            if (advanceLevel == null)
            {
                return HttpNotFound();
            }
            return View(advanceLevel);
        }

        // POST: AdvanceLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvanceLevel advanceLevel = db.AdvanceLevels.Find(id);
            db.AdvanceLevels.Remove(advanceLevel);
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
