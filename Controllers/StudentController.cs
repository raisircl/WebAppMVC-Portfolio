using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebAppMVC.Models;
using Microsoft.Data.SqlClient; 
namespace WebAppMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly string constr;
        public StudentController(IConfiguration configuration)
        {
            constr = configuration.GetConnectionString("Default");
        }
        private IDbConnection CreateConnection() => new SqlConnection(constr);
        public async Task<IActionResult> Index()
        {
            //Student[] students = new Student[] {
            //    new Student() { Id=1001, Name="Ram", Age=20 }
            //    , new Student() { Id=1002, Name="Shyam", Age=22 }
            //    , new Student() { Id=1003, Name="Mohan", Age=21 }
            //    , new Student() { Id=1004, Name="Sohan", Age=23 }
            //};

            ////student.Id = 1001;
            ////student.Name = "John Doe";
            ////student.Age = 21;

            //ViewData["Title"] = "All Students";
            ////ViewBag.Message = "Welcome to the Student Index Page!";
            ////ViewData["rollno"] = 101;   
            ////ViewBag.Age = 20;   
            using var conn = CreateConnection();
            var sql = "SELECT * FROM tblstudents";
            var students= await conn.QueryAsync<Student>(sql);
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
        public async Task<IActionResult> Create(Student student)
        {
            ModelState.Remove("Id"); // to ignore Id validation as it is not entered by user    
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            using var conn = CreateConnection();
            var sql = "INSERT INTO tblstudents (Name, Age) VALUES (@Name, @Age)";
            var result = await conn.ExecuteAsync(sql, student);
            return RedirectToAction("Index"); //PRG
        }

        [HttpGet]
        public IActionResult Save(List<string> subjects)
        {
            return View();
        }
       
    }
}
