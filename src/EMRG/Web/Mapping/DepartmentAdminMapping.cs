using AutoMapper;
using Brotal.Extensions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.DepartmentAdmin.Pages.Students;

namespace Web.Mapping
{
    public class DepartmentAdminMapping : Profile
    {
        public DepartmentAdminMapping()
        {
            CreateMap<StudentInputModel, Student>()
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth.ParseDate())
                );
            CreateMap<Student, StudentInputModel>()
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth.LocalDate())
                );
        }
    }
}
