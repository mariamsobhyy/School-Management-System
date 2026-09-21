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

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public IActionResult GetTeachers()
        {
            List<Teacher> teachers = _context.Teachers.ToList();

            List<TeacherDto> result = new List<TeacherDto>();

            foreach (Teacher teacher in teachers)
            {
                result.Add(new TeacherDto
                {
                    Id = teacher.Id,
                    FirstName = teacher.FristName,
                    LastName = teacher.LastName,
                    Email = teacher.Email,
                    PhoneNumber = teacher.PhoneNumber,
                    Salary = teacher.Salary,
                    DepartmentId = teacher.DepartmentId
                });
            }

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);

            if (teacher == null)
            {
                return NotFound();
            }

            TeacherDto result = new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FristName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
                Salary = teacher.Salary,
                DepartmentId = teacher.DepartmentId
            };

            return Ok(result);
        }

        
        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDto dto)
        {
            Teacher teacher = new Teacher
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

            TeacherDto result = new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FristName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
                Salary = teacher.Salary,
                DepartmentId = teacher.DepartmentId
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = teacher.Id },
                result
            );
        }

      
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, UpdateTeacherDto dto)
        {
            Teacher teacher = _context.Teachers.Find(id);

            if (teacher == null)
            {
                return NotFound();
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
        public IActionResult DeleteTeacher(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);

            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
