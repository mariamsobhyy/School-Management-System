using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.EnrollmentDto
{
    public class EnrollmentDto
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public decimal Grade { get; set; }
    }
}

