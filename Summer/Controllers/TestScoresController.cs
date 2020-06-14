using Summer.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Summer.Controllers
{
    [Authorize]
    public class TestScoresController : Controller
    {
        private DataContext db = new DataContext();

        // GET: TestScores
        public ActionResult Index(string courseNameSearch, string studentNameSearch)
        {
            var testScores = db.TestScores.Include(t => t.Course).Include(t => t.Student);
            var testScoresList = from s in testScores select s;
            if (!string.IsNullOrEmpty(courseNameSearch))
            {
                testScoresList = testScoresList.Where(s => s.Course.CourseName.Contains(courseNameSearch));
            }
            if (!string.IsNullOrEmpty(studentNameSearch))
            {
                testScoresList = testScoresList.Where(s => s.Student.Name.Contains(studentNameSearch));
            }

            return View(testScoresList.ToList());
        }

        // GET: TestScores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestScore testScore = db.TestScores.Find(id);
            if (testScore == null)
            {
                return HttpNotFound();
            }
            return View(testScore);
        }

        // GET: TestScores/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name");
            return View();
        }

        // POST: TestScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,StudentId,StudentScore,Comment,DateTime")] TestScore testScore)
        {
            if (ModelState.IsValid)
            {
                db.TestScores.Add(testScore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", testScore.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", testScore.StudentId);
            return View(testScore);
        }

        // GET: TestScores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestScore testScore = db.TestScores.Find(id);
            if (testScore == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", testScore.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", testScore.StudentId);
            return View(testScore);
        }

        // POST: TestScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,StudentId,StudentScore,Comment,DateTime")] TestScore testScore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testScore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", testScore.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", testScore.StudentId);
            return View(testScore);
        }

        // GET: TestScores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestScore testScore = db.TestScores.Find(id);
            if (testScore == null)
            {
                return HttpNotFound();
            }
            return View(testScore);
        }

        // POST: TestScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestScore testScore = db.TestScores.Find(id);
            db.TestScores.Remove(testScore);
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
