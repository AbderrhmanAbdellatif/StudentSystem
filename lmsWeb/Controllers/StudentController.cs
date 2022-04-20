using lms.DataAccess;
using lms.Models;
using Microsoft.AspNetCore.Mvc;

namespace lmsWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objectStudnetList = _db.students;// data in database came like list here
            return View(objectStudnetList);
        }
        //GET
        public IActionResult Create() {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student stu)
        {
            if (stu.Name == stu.lessons_code.ToString()) {

                ModelState.AddModelError("lessonError", "please input valid lesson code");
            }
            if (stu.Name == stu.lessonsDate.ToString())
            {

                ModelState.AddModelError("DataError", "please input valid Date");
            }

            if (ModelState.IsValid) { 
            _db.students.Add(stu);
            _db.SaveChanges();
            TempData["success"] = "Studnet Created Successfully";
            return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
           // var StudnetfromDb = _db.students.Find(id);
           var StudnetfromDb = _db.students.FirstOrDefault(x => x.Name == "id");

            if (StudnetfromDb == null )
            {
                return NotFound();
            }
                return View(StudnetfromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student stu)
        {
            if (stu.Name == stu.lessons_code.ToString())
            {

                ModelState.AddModelError("lessonError", "please input valid lesson code");
            }
            if (stu.Name == stu.lessonsDate.ToString())
            {

                ModelState.AddModelError("DataError", "please input valid Date");
            }

            if (ModelState.IsValid)
            {
                _db.students.Update(stu);
                _db.SaveChanges();
                TempData["success"] = "Studnet Update Successfully";
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var StundetFromDB = _db.students.Find(id);


            if (StundetFromDB == null)
            {
                return NotFound();
            }

            return View(StundetFromDB);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.students.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Studnet Remove Successfully";
            return RedirectToAction("Index");

        }

       
    }
}
