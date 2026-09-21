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
            List<Subject> subjects = _context.Subjects.ToList();

            List<SubjectDto> result = new List<SubjectDto>();

            foreach (Subject subject in subjects)
            {
                result.Add(new SubjectDto
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Description = subject.Description,
                    MaxGrade = subject.MaxGrade,
                    TeacherId = subject.TeacherId
                });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Subject subject = _context.Subjects.Find(id);

            if (subject == null)
            {
                return NotFound();
            }

            SubjectDto result = new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                MaxGrade = subject.MaxGrade,
                TeacherId = subject.TeacherId
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateSubject(CreateSubjectDto dto)
        {
            Teacher teacher = _context.Teachers.Find(dto.TeacherId);

            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }

            Subject subject = new Subject
            {
                Name = dto.Name,
                Description = dto.Description,
                MaxGrade = dto.MaxGrade,
                TeacherId = dto.TeacherId
            };

            _context.Subjects.Add(subject);
            _context.SaveChanges();

            SubjectDto result = new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                MaxGrade = subject.MaxGrade,
                TeacherId = subject.TeacherId
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = subject.Id },
                result
            );
        }


        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id, UpdateSubjectDto dto)
        {
            Subject subject = _context.Subjects.Find(id);

            if (subject == null)
            {
                return NotFound();
            }

            Teacher teacher = _context.Teachers.Find(dto.TeacherId);

            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }

            subject.Name = dto.Name;
            subject.Description = dto.Description;
            subject.MaxGrade = dto.MaxGrade;
            subject.TeacherId = dto.TeacherId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            Subject subject = _context.Subjects.Find(id);

            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
