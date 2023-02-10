using AutoMapper;
using BusinessLogicLayer.DTOs.DepartmentDTOs;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<AddDepartmentDTO, Department>();
            CreateMap<UpdateDepartmentDTO, Department>();
            CreateMap<Department, GetDepartmentDTO>();

            CreateMap<AddEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();
            CreateMap<Employee, GetEmployeeDTO>();
        }
    }
}
