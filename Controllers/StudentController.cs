using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.DTOs.StudentDto;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto dto)
        {
            var classroom = _context.Classrooms
                .FirstOrDefault(c => c.Id == dto.ClassRoomId);

            if (classroom == null)
            {
                return NotFound("ClassRoom not found");
            }

            var student = new Student
            {
                FristName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                ClassRoomId = dto.ClassRoomId
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(
            int id,
            UpdateStudentDto dto)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            var classroom = _context.Classrooms
                .FirstOrDefault(c => c.Id == dto.ClassRoomId);

            if (classroom == null)
            {
                return NotFound("ClassRoom not found");
            }

            student.FristName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;
            student.PhoneNumber = dto.PhoneNumber;
            student.DateOfBirth = dto.DateOfBirth;
            student.ClassRoomId = dto.ClassRoomId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveStudent(int id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }
    }

}

