using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Subject
    {
        public int Id { get; set; }
      
        public string Name { get; set; }

 
        public string Description { get; set; }

        public int MaxGrade{ get; set; }

      
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }


        public ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();
    }
}
