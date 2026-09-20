using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.DTOs.ClassRoomDto;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassRoomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClassRooms()
        {
            var classrooms = _context.Classrooms.Include(c => c.Students).ToList();
            return Ok(classrooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classroom = _context.Classrooms.Include( c => c.Students)
                .FirstOrDefault(c => c.Id == id);

            if (classroom == null)
            {
                return NotFound("ClassRoom not found");
            }

            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult CreateClassRoom(CreateClassroomDto dto)
        {
            var classroom = new ClassRoom
            {
                Name = dto.Name,
                GradeLevel = dto.GradeLevel,
                Capacity = dto.Capacity
            };

            _context.Classrooms.Add(classroom);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = classroom.Id },
                classroom
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassRoom(
            int id,
            UpdateClassroomDto dto)
        {
            var classroom = _context.Classrooms
                .FirstOrDefault(c => c.Id == id);

            if (classroom == null)
            {
                return NotFound("ClassRoom not found");
            }

            classroom.Name = dto.Name;
            classroom.GradeLevel = dto.GradeLevel;
            classroom.Capacity = dto.Capacity;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveClassRoom(int id)
        {
            var classroom = _context.Classrooms
                .FirstOrDefault(c => c.Id == id);

            if (classroom == null)
            {
                return NotFound("ClassRoom not found");
            }

            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

