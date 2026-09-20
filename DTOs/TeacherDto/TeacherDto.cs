using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.TeacherDto
{
 

    public class TeacherDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}