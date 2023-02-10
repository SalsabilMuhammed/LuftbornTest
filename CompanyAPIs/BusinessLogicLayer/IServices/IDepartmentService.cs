using BusinessLogicLayer.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface IDepartmentService
    {
        Task<GetDepartmentDTO> AddDepartment(AddDepartmentDTO addDepartmentDTO);
        Task<GetDepartmentDTO> UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO);
        Task<List<GetDepartmentDTO>> GetAllDepartments();
        Task<GetDepartmentDTO> GetDepartmentById(int id);
        Task<bool> DeleteDepartment(int DepartmentId);
    }
}
