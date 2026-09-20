using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.StudentDto
{
    public class CreateStudentDto
    {
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

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public int ClassRoomId { get; set; }
    }
}
