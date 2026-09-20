using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.TeacherDto
{
    public class CreateTeacherDto
    {

      
        public string FirstName { get; set; } = string.Empty;

 
        public string LastName { get; set; } = string.Empty;

    
        public string Email { get; set; } = string.Empty;

      
  
        public string? PhoneNumber { get; set; }


        public decimal Salary { get; set; }

 
        public int DepartmentId { get; set; }
    }
}
