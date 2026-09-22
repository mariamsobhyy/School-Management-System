using AutoMapper;
using School_Management_System.DTOs.ClassRoomDto;
using School_Management_System.Models;


namespace School_Management_System.Mapper
{
    public class ClassRoomProfile : Profile
    {
        public ClassRoomProfile()
        {
            CreateMap <ClassRoom , ClassroomDto>().ReverseMap();
            CreateMap<ClassRoom , CreateClassroomDto >().ReverseMap();  
        }
    }
}
