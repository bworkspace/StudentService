using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentService.Model;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> students = new List<Student>()
       {
           new Student(){ Id=1, name="Mike", rollno=101},
           new Student(){ Id=2, name="Brad", rollno=102},
           new Student(){ Id=3, name="Dude", rollno=103},
           new Student(){ Id=4, name="Mosh", rollno=104},
       };

       [HttpGet]
       public IActionResult GetStudents()
        {
            if(students.Count == 0)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("GetStudent")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.SingleOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound();
            else
                return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            students.Add(student);
            if (students.Count == 0)
                return NotFound();
            else
                return Ok(student);
        }
        
        [HttpDelete]
        public IActionResult DeleteStudentById(int id)
        {
            var student = students.SingleOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound();
            if (students.Count == 0)
                return NotFound("Student ot found");

            return Ok(student);

        }
    }
}
