using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.SubjectDto
{
    public class CreateSubjectDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(1, 100)]
        public int MaxGrade { get; set; }

        [Required]
        public int TeacherId { get; set; }
    }
}
