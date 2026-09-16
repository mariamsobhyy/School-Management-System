using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FristName { get; set; }


        public string LastName  { get; set; }

        public string Email { get; set; }


        public string PhoneNumber  { get; set; }

    
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
