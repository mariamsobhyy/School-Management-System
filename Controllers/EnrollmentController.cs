using Microsoft.AspNetCore.Http;
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

        public EnrollmentController (AppDbContext context)
        {
           _context = context;
        }
   


        [HttpGet]
        public IActionResult GetEnrollments()
        {
            var enrollments = _context.Enrollments.ToList();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enrollment = _context.Enrollments
                .FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound("Enrollment not found");
            }

            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult CreateEnrollment(
            CreateEnrollmentDto dto)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id == dto.StudentId);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            var subject = _context.Subjects
                .FirstOrDefault(s => s.Id == dto.SubjectId);

            if (subject == null)
            {
                return NotFound("Subject not found");
            }

            var existingEnrollment = _context.Enrollments
                .FirstOrDefault(e =>
                    e.StudentId == dto.StudentId &&
                    e.SubjectId == dto.SubjectId);

            if (existingEnrollment != null)
            {
                return BadRequest(
                    "Student is already enrolled in this subject");
            }

            var enrollment = new Enrollment
            {
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId,
                EnrollmentDate = dto.EnrollmentDate,
                Grade = dto.Grade
            };

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = enrollment.Id },
                enrollment
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(
            int id,
            UpdateEnrollmentDto dto)
        {
            var enrollment = _context.Enrollments
                .FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound("Enrollment not found");
            }

            var student = _context.Students
                .FirstOrDefault(s => s.Id == dto.StudentId);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            var subject = _context.Subjects
                .FirstOrDefault(s => s.Id == dto.SubjectId);

            if (subject == null)
            {
                return NotFound("Subject not found");
            }

            enrollment.StudentId = dto.StudentId;
            enrollment.SubjectId = dto.SubjectId;
            enrollment.EnrollmentDate = dto.EnrollmentDate;
            enrollment.Grade = dto.Grade;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveEnrollment(int id)
        {
            var enrollment = _context.Enrollments
                .FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound("Enrollment not found");
            }

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();

            return NoContent();
        }
    }
}