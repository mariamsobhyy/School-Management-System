using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
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
        public ActionResult<IEnumerable<Department>> GetDepartments()
        { 
           return _context.Departments.ToList(); 
        }

    }
}
