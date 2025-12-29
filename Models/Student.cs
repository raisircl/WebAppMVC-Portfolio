using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Id can not be blank")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter the name of student.")]
        public string? Name { get; set; }
       
        [Range(1, 120,ErrorMessage ="Age should be between 1-120")]
        public int Age { get; set; }

    }
}
