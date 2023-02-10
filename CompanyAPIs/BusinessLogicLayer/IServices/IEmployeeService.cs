using BusinessLogicLayer.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface IEmployeeService
    {
        Task<GetEmployeeDTO> AddEmployee(AddEmployeeDTO AddEmployeeDTO);
        Task<GetEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO UpdateEmployeeDTO);
        Task<List<GetEmployeeDTO>> GetDepartmentEmployees(int DepartmentId);
        Task<GetEmployeeDTO> GetEmployeeById(int id);
        Task<bool> DeleteEmployee(int EmployeeId);
        Task<bool> DeleteDepartmentEmployees(int DepartmentId);
    }
}
