using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using School_Management_System.Data;
using School_Management_System.DTOs.DepartmentDto;
using School_Management_System.Mapper;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;



        public DepartmentController(AppDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<DepartmentProfile>());
            _mapper = config.CreateMapper();
        }




        [HttpGet]
        public IActionResult GetDepartments()
        {
            List<Department> departments = _context.Departments.ToList();

            /* List<DepartmentDto> result = new List<DepartmentDto>();

             foreach (Department department in departments)
             {
                 result.Add(new DepartmentDto
                 {
                     Id = department.Id,
                     Name = department.Name,
                     Description = department.Description
                 });
             }*/



            List<DepartmentDto> departmentDTOs = _mapper.Map<List<DepartmentDto>>(departments);
            if (departments == null || departments.Count == 0)
            {
                return NotFound("No departments found");
            }
            return Ok(departmentDTOs);
        }




        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dept = _context.Departments .FirstOrDefault(a => a.Id == id);

            var dep = _mapper.Map<DepartmentDto>(dept);
            return Ok(dep);
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateDepartmentDto createDepartmentDTO)
        {
            if (createDepartmentDTO == null)
            {
                return BadRequest("Department cannot be null");


            }
            //var department = new Department
            //{
            //    Name = createDepartmentDTO.Name,
            //    Description = createDepartmentDTO.Description
            //};

            var dep = _mapper.Map<Department>(createDepartmentDTO);
            _context.Departments.Add(dep);
            _context.SaveChanges();
            return CreatedAtAction(
                nameof(GetById),
                new { id = dep.Id },
                dep
                );
        }

        [HttpGet("Withdept")]

        public IActionResult GetDeptWithTeacher()
        {
            var m = _context.Departments.Include(t => t.teachers).ToList();
            return Ok(m);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id,UpdateDepartmentDto dto)
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
