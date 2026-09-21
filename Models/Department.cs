using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Department
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public ICollection<Teacher> teachers { get; set; } = new List<Teacher>();
    }
}
