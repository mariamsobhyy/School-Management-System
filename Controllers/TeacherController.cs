using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.DTOs.TeacherDto;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase

    {

        private readonly AppDbContext _context;

        public TeacherController( AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = _context.Teachers.ToList();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _context.Teachers
                .FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }

            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDto dto)
        {
            var department = _context.Departments
                .FirstOrDefault(d => d.Id == dto.DepartmentId);

            if (department == null)
            {
                return NotFound("Department not found");
            }

            var teacher = new Teacher
            {
                FristName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Salary = dto.Salary,
                DepartmentId = dto.DepartmentId
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = teacher.Id },
                teacher
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(
            int id,
            UpdateTeacherDto dto)
        {
            var teacher = _context.Teachers
                .FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }

            var department = _context.Departments
                .FirstOrDefault(d => d.Id == dto.DepartmentId);

            if (department == null)
            {
                return NotFound("Department not found");
            }

            teacher.FristName = dto.FirstName;
            teacher.LastName = dto.LastName;
            teacher.Email = dto.Email;
            teacher.PhoneNumber = dto.PhoneNumber;
            teacher.Salary = dto.Salary;
            teacher.DepartmentId = dto.DepartmentId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTeacher(int id)
        {
            var teacher = _context.Teachers
                .FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();

            return NoContent();
        }
    }
}


