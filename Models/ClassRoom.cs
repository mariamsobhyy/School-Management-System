using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public int GradeLevel { get; set; }
  
        public int Capacity { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
