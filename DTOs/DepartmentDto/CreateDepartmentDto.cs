using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.DepartmentDto
{
    public class CreateDepartmentDto
    {

        
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
