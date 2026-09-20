using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
         
        public DepartmentController ( AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _context.Departments
                .FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound("Department not found");
            }

            return Ok(department);
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateDepartmentDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Departments.Add(department);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = department.Id },
                department
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, UpdateDepartmentDto dto)
        {
            var department = _context.Departments
                .FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound("Department not found");
            }

            department.Name = dto.Name;
            department.Description = dto.Description;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveDepartment(int id)
        {
            var department = _context.Departments
                .FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound("Department not found");
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return NoContent();
        }
    }
}