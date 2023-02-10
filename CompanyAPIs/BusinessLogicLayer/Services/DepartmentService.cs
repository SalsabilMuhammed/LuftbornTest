using AutoMapper;
using BusinessLogicLayer.DTOs.DepartmentDTOs;
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
    public class DepartmentService : IDepartmentService
    {
        private readonly DataBaseContext _Db;
        private readonly IMapper _mapper;
        public DepartmentService(DataBaseContext Db, IMapper mapper)
        {
            _Db = Db;
            _mapper = mapper;
        }
        public async Task<GetDepartmentDTO> AddDepartment(AddDepartmentDTO addDepartmentDTO)
        {
            try
            {
                var AddedDepartment = await _Db.Departments.AddAsync(_mapper.Map<Department>(addDepartmentDTO));
                await _Db.SaveChangesAsync();
                return await GetDepartmentById(AddedDepartment.Entity.Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<GetDepartmentDTO> UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO)
        {
            try
            {
                Department? Department = await _Db.Departments.Where(x => x.Id == updateDepartmentDTO.Id).FirstOrDefaultAsync();
                if (Department == null)
                    return null;
                else
                {
                    _mapper.Map(updateDepartmentDTO, Department);
                    await _Db.SaveChangesAsync();
                    return _mapper.Map<GetDepartmentDTO>(Department);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<GetDepartmentDTO>> GetAllDepartments()
        {
            List<Department> Departments = await _Db.Departments.Select(x => new Department
            {
                Id = x.Id,
                Name = x.Name,
            }).AsNoTracking().ToListAsync();

            return _mapper.Map<List<GetDepartmentDTO>>(Departments);
        }
        public async Task<GetDepartmentDTO> GetDepartmentById(int id)
        {
            var Department = await _Db.Departments.FindAsync(id);
            return _mapper.Map<GetDepartmentDTO>(Department);
        }
        public async Task<bool> DeleteDepartment(int DepartmentId)
        {
            try
            {
                Department DeletedDepartment = await _Db.Departments.Where(x => x.Id == DepartmentId).FirstOrDefaultAsync();
                if (DeletedDepartment == null)
                    return false;
                _Db.Departments.Remove(DeletedDepartment);
                await _Db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
    }
}
