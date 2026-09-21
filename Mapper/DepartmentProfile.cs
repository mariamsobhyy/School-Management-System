using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Identity.Client;
using System.Runtime;
using School_Management_System.Models;
using School_Management_System.DTOs.DepartmentDto;

namespace School_Management_System.Mapper
{
    public class DepartmentProfile : Profile


    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap <Department, CreateDepartmentDto>().ReverseMap();

        }
    }

   


    
}
