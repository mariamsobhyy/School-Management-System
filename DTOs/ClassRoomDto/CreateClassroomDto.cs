using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.ClassRoomDto
{
    public class CreateClassroomDto
    {
        public string Name { get; set; } = string.Empty;

        [Range(1, 12)]
        public int GradeLevel { get; set; }

        [Range(1, 100)]
        public int Capacity { get; set; }
    }
}
