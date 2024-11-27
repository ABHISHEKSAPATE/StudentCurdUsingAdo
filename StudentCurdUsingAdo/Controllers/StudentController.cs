using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCurdUsingAdo.Models;

namespace StudentCurdUsingAdo.Controllers
{
    public class StudentController : Controller
    {
        //you have to add
        private readonly IConfiguration configuration;
        StudentCurd db;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db=new StudentCurd(this.configuration);
           
        }




        // GET: StudentController //student list
        public ActionResult Index()

        {
            var response = db.GetStudents();
            return View(response);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var response = db.GetStudentById(id);
            return View(response);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stu)
        {
            try
            {
                int response = db.AddStudent(stu);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();

            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var res=db.GetStudentById(id);
            return View(res);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stu)
        {
            try
            {
                int response = db.UpdateStudent(stu);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var res= db.GetStudentById(id);
            return View(res);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ActionName("Delete")]//this inform CLR THANT DELETECONFIRM IS HTTPOST METHOD AGAINST DELETE
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id,Student stu)
        {
            try
            {
                int response = db.DeleteStudent(id);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
