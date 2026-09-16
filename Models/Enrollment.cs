using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
    
        public int StudentId { get; set; }
        public Student Student { get; set; }


        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


        public DateTime EnrollmentDate { get; set; }

 
        public decimal Grade { get; set; }


    }
}
