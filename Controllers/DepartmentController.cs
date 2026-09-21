using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.DTOs.DepartmentDto;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult GetDepartments()
        {
            List<Department> departments = _context.Departments.ToList();

            List<DepartmentDto> result = new List<DepartmentDto>();

            foreach (Department department in departments)
            {
                result.Add(new DepartmentDto
                {
                    Id = department.Id,
                    Name = department.Name,
                    Description = department.Description
                });
            }

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Department department = _context.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            DepartmentDto result = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };

            return Ok(result);
        }

       
        [HttpPost]
        public IActionResult CreateDepartment(CreateDepartmentDto dto)
        {
            Department department = new Department
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Departments.Add(department);
            _context.SaveChanges();

            DepartmentDto result = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = department.Id },
                result
            );
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(
            int id,
            UpdateDepartmentDto dto)
        {
            Department department = _context.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            department.Name = dto.Name;
            department.Description = dto.Description;

            _context.SaveChanges();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            Department department = _context.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
