using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataBaseContext _Db;
        private readonly IMapper _mapper;
        public EmployeeService(DataBaseContext Db, IMapper mapper)
        {
            _Db = Db;
            _mapper = mapper;
        }
        public async Task<GetEmployeeDTO> AddEmployee(AddEmployeeDTO AddEmployeeDTO)
        {

            try
            {
                var AddedEmployee = await _Db.Employees.AddAsync(_mapper.Map<Employee>(AddEmployeeDTO));
                await _Db.SaveChangesAsync();
                return await GetEmployeeById(AddedEmployee.Entity.Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<GetEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO UpdateEmployeeDTO)
        {
            try
            {
                Employee? Employee = await _Db.Employees.Where(x => x.Id == UpdateEmployeeDTO.Id).FirstOrDefaultAsync();
                if (Employee == null)
                    return null;
                else
                {
                    _mapper.Map(UpdateEmployeeDTO, Employee);
                    await _Db.SaveChangesAsync();
                    return _mapper.Map<GetEmployeeDTO>(Employee);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<GetEmployeeDTO>> GetDepartmentEmployees(int DepartmentId)
        {
            List<Employee> Employees = await _Db.Employees.Select(x => new Employee
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).Where(x => x.DepartmentId == DepartmentId).AsNoTracking().ToListAsync();

            return _mapper.Map<List<GetEmployeeDTO>>(Employees);
        }
        public async Task<bool> DeleteEmployee(int EmployeeId)
        {
            try
            {
                Employee DeletedEmployee = await _Db.Employees.Where(x => x.Id == EmployeeId).FirstOrDefaultAsync();
                if (DeletedEmployee == null)
                    return false;
                _Db.Employees.Remove(DeletedEmployee);
                await _Db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
        public async Task<bool> DeleteDepartmentEmployees(int DepartmentId)
        {
            try
            {
                _Db.Employees.RemoveRange(_Db.Employees.Where(x => x.DepartmentId == DepartmentId));
                await _Db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
        public async Task<GetEmployeeDTO> GetEmployeeById(int id)
        {
            var Employee = await _Db.Employees.FindAsync(id);
            return _mapper.Map<GetEmployeeDTO>(Employee);
        }
    }
}
