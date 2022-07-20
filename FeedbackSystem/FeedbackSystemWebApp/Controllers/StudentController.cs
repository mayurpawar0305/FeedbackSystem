using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace FeedbackSystemWebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> student = FeedbackManager.GetAll();
            return View(student);
        }
        public ActionResult Details(string module)
        {
            Student student = FeedbackManager.GetByModule(module);
            return View(student);
        }
        public ActionResult Delete(int feedbackid)
        {
            bool status = FeedbackManager.Delete(feedbackid);
            if (status)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(int feedbackid,string studentname,DateTime date,string module,string faculty,int problemsolvingrating,int presentationrating,string comments)
        {
            Student std = new Student
            {
                FeedbackId = feedbackid,
                StudentName = studentname,
                Date = date,
                Module = module,
                Faculty = faculty,
                ProblemSolvingRating = problemsolvingrating,
                PresentationSkill = presentationrating,
                Comments = comments

            };
            FeedbackManager.Insert(std);
            return RedirectToAction("index");
        }
        public ActionResult Update(string module)
        {
            Student student = FeedbackManager.GetByModule(module);
            return View();
        }
        [HttpPost]
        public ActionResult Update(int feedbackid, string studentname, DateTime date, string module, string faculty, int problemsolvingrating, int presentationrating, string comments)
        {
            Student std = new Student
            {
                FeedbackId = feedbackid,
                StudentName = studentname,
                Date = date,
                Module = module,
                Faculty = faculty,
                ProblemSolvingRating = problemsolvingrating,
                PresentationSkill = presentationrating,
                Comments = comments

            };
            FeedbackManager.Update(std);
            return RedirectToAction("index");
        }
    }
}