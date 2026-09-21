using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.DTOs.EnrollmentDto;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEnrollments()
        {
            List<Enrollment> enrollments = _context.Enrollments.ToList();

            List<EnrollmentDto> result = new List<EnrollmentDto>();

            foreach (Enrollment enrollment in enrollments)
            {
                result.Add(new EnrollmentDto
                {
                    Id = enrollment.Id,
                    StudentId = enrollment.StudentId,
                    SubjectId = enrollment.SubjectId,
                    EnrollmentDate = enrollment.EnrollmentDate,
                    Grade = enrollment.Grade
                });
            }

            return Ok(result);
        }

     
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Enrollment enrollment = _context.Enrollments.Find(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            EnrollmentDto result = new EnrollmentDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                SubjectId = enrollment.SubjectId,
                EnrollmentDate = enrollment.EnrollmentDate,
                Grade = enrollment.Grade
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateEnrollment(CreateEnrollmentDto dto)
        {
            Student student = _context.Students.Find(dto.StudentId);

            if (student == null)
            {
                return BadRequest("Student not found");
            }

            Subject subject = _context.Subjects.Find(dto.SubjectId);

            if (subject == null)
            {
                return BadRequest("Subject not found");
            }

            Enrollment enrollment = new Enrollment
            {
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId,
                EnrollmentDate = dto.EnrollmentDate,
                Grade = dto.Grade
            };

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            EnrollmentDto result = new EnrollmentDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                SubjectId = enrollment.SubjectId,
                EnrollmentDate = enrollment.EnrollmentDate,
                Grade = enrollment.Grade
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = enrollment.Id },
                result
            );
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(
            int id,
            UpdateEnrollmentDto dto)
        {
            Enrollment enrollment = _context.Enrollments.Find(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            Student student = _context.Students.Find(dto.StudentId);

            if (student == null)
            {
                return BadRequest("Student not found");
            }

            Subject subject = _context.Subjects.Find(dto.SubjectId);

            if (subject == null)
            {
                return BadRequest("Subject not found");
            }

            enrollment.StudentId = dto.StudentId;
            enrollment.SubjectId = dto.SubjectId;
            enrollment.EnrollmentDate = dto.EnrollmentDate;
            enrollment.Grade = dto.Grade;

            _context.SaveChanges();

            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            Enrollment enrollment = _context.Enrollments.Find(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
