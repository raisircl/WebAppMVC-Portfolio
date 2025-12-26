using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student[] students = new Student[] {
                new Student() { Id=1001, Name="Ram", Age=20 }
                , new Student() { Id=1002, Name="Shyam", Age=22 }
                , new Student() { Id=1003, Name="Mohan", Age=21 }
                , new Student() { Id=1004, Name="Sohan", Age=23 }
            };

            //student.Id = 1001;
            //student.Name = "John Doe";
            //student.Age = 21;

            ViewData["Title"] = "All Students";
            //ViewBag.Message = "Welcome to the Student Index Page!";
            //ViewData["rollno"] = 101;   
            //ViewBag.Age = 20;   
            return View(students);
        }
        public IActionResult Details([FromRoute]int id)
        {
            Student student = new Student() { Id = id, Name = "Ram", Age = 20 };
            return View(student);
        }
        //[Route("deepak")]
        public IActionResult Search(string name, int age)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm]Student student)
        {
            // Save the student to the database (not implemented here)
            // For now, just redirect to the Index action
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Save(List<string> subjects)
        {
            return View();
        }
       
    }
}
