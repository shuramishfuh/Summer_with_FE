using Summer.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Summer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Students
        public ActionResult Index(string searchString)
        {
            var students = db.Students.Include(s => s.AdvanceLevel).Include(s => s.OrdinaryLevel);
            var studentList = from s in students select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                studentList = studentList.Where(s => s.Name.Contains(searchString));
            }

            return View(studentList.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.AdvanceLevels, "Id", "Subject_1");
            ViewBag.StudentId = new SelectList(db.OrdinaryLevels, "Id", "Subject_1");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,Name,Sex,Age,School,FutureCareerChoice,Tel,YearOfAttendance")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.AdvanceLevels, "Id", "Subject_1", student.StudentId);
            ViewBag.StudentId = new SelectList(db.OrdinaryLevels, "Id", "Subject_1", student.StudentId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.AdvanceLevels, "Id", "Subject_1", student.StudentId);
            ViewBag.StudentId = new SelectList(db.OrdinaryLevels, "Id", "Subject_1", student.StudentId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,Name,Sex,Age,School,FutureCareerChoice,Tel,YearOfAttendance")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.AdvanceLevels, "Id", "Subject_1", student.StudentId);
            ViewBag.StudentId = new SelectList(db.OrdinaryLevels, "Id", "Subject_1", student.StudentId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
