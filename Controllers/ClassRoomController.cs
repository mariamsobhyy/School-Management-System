using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.DTOs.ClassRoomDto;
using School_Management_System.DTOs.StudentDto;
using School_Management_System.Mapper;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public ClassRoomController(AppDbContext context)
        {
            _context = context;
            var confg = new MapperConfiguration(cfg => cfg.AddProfile<ClassRoomProfile>());
            _mapper = confg.CreateMapper();
        }


        [HttpGet]
        public IActionResult GetClassRooms()
        {
            List<ClassRoom> classrooms = _context.Classrooms.ToList();

            //List<ClassroomDto> result = new List<ClassroomDto>();

            //foreach (ClassRoom classroom in classrooms)
            //{
            //    result.Add(new ClassroomDto
            //    {
            //        Id = classroom.Id,
            //        Name = classroom.Name,
            //        GradeLevel = classroom.GradeLevel,
            //        Capacity = classroom.Capacity
            //    });
            //}

            List<ClassroomDto> classroomDtos = _mapper.Map<List<ClassroomDto>>(classrooms);

            if (classrooms == null || classrooms.Count == 0)
            {
                return NotFound("classrooms not found");
            }




            return Ok(classroomDtos);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClassRoom classroom = _context.Classrooms.Find(id);

            if (classroom == null)
            {
                return NotFound();
            }

            ClassroomDto result = new ClassroomDto
            {
                Id = classroom.Id,
                Name = classroom.Name,
                GradeLevel = classroom.GradeLevel,
                Capacity = classroom.Capacity
            };

            return Ok(result);
        }

       
        [HttpPost]
        public IActionResult CreateClassRoom(CreateClassroomDto dto)
        {
            ClassRoom classroom = new ClassRoom
            {
                Name = dto.Name,
                GradeLevel = dto.GradeLevel,
                Capacity = dto.Capacity
            };

            _context.Classrooms.Add(classroom);
            _context.SaveChanges();

            ClassroomDto result = new ClassroomDto
            {
                Id = classroom.Id,
                Name = classroom.Name,
                GradeLevel = classroom.GradeLevel,
                Capacity = classroom.Capacity
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = classroom.Id },
                result
            );
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateClassRoom(int id, UpdateClassroomDto dto)
        {
            ClassRoom classroom = _context.Classrooms.Find(id);

            if (classroom == null)
            {
                return NotFound();
            }

            classroom.Name = dto.Name;
            classroom.GradeLevel = dto.GradeLevel;
            classroom.Capacity = dto.Capacity;

            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteClassRoom(int id)
        {
            ClassRoom classroom = _context.Classrooms.Find(id);

            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
