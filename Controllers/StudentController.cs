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
            List<Student> students = _context.Students.ToList();

            List<StudentDto> result = new List<StudentDto>();

            foreach (Student student in students)
            {
                result.Add(new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FristName,
                    LastName = student.LastName,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    DateOfBirth = student.DateOfBirth,
                    ClassRoomId = student.ClassRoomId
                });
            }

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Student student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            StudentDto result = new StudentDto
            {
                Id = student.Id,
                FirstName = student.FristName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                DateOfBirth = student.DateOfBirth,
                ClassRoomId = student.ClassRoomId
            };

            return Ok(result);
        }


        [HttpGet ("Order By name")]

        public IActionResult GetByName()
        {
            var student = _context.Students.OrderBy(x => x.LastName).ToList();

            return Ok(student);
        }
       
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto dto)
        {
            ClassRoom classroom = _context.Classrooms.Find(dto.ClassRoomId);

            if (classroom == null)
            {
                return BadRequest("ClassRoom not found");
            }

            Student student = new Student
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

            StudentDto result = new StudentDto
            {
                Id = student.Id,
                FirstName = student.FristName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                DateOfBirth = student.DateOfBirth,
                ClassRoomId = student.ClassRoomId
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                result
            );
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentDto dto)
        {
            Student student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            ClassRoom classroom = _context.Classrooms.Find(dto.ClassRoomId);

            if (classroom == null)
            {
                return BadRequest("ClassRoom not found");
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
        public IActionResult DeleteStudent(int id)
        {
            Student student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
