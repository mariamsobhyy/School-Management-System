using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.EnrollmentDto
{
    public class CreateEnrollmentDto
    {
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public decimal Grade { get; set; }
    }
}
