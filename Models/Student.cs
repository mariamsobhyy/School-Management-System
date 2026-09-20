using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School_Management_System.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FristName { get; set; }

        public string LastName { get; set; }


        public string Email { get; set; }


        public string PhoneNumber { get; set; }


        public DateOnly DateOfBirth { get; set; }



        public int ClassRoomId { get; set; }

        [JsonIgnore]
        public ClassRoom? ClassRoom { get; set; }


        public ICollection<Enrollment> enrollments { get; set; }
    }
}
