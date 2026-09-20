using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.DTOs.SubjectDto;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubjectController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _context.Subjects.ToList();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subject = _context.Subjects
                .FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                return NotFound("Subject not found");
            }

            return Ok(subject);
        }

        [HttpPost]
        public IActionResult CreateSubject(CreateSubjectDto dto)
        {
            var teacher = _context.Teachers
                .FirstOrDefault(t => t.Id == dto.TeacherId);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }

            var subject = new Subject
            {
                Name = dto.Name,
                Description = dto.Description,
                MaxGrade = dto.MaxGrade,
                TeacherId = dto.TeacherId
            };

            _context.Subjects.Add(subject);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = subject.Id },
                subject
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubject(
            int id,
            UpdateSubjectDto dto)
        {
            var subject = _context.Subjects
                .FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                return NotFound("Subject not found");
            }

            var teacher = _context.Teachers
                .FirstOrDefault(t => t.Id == dto.TeacherId);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }

            subject.Name = dto.Name;
            subject.Description = dto.Description;
            subject.MaxGrade = dto.MaxGrade;
            subject.TeacherId = dto.TeacherId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveSubject(int id)
        {
            var subject = _context.Subjects
                .FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                return NotFound("Subject not found");
            }

            _context.Subjects.Remove(subject);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
