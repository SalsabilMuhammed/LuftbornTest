using BusinessLogicLayer.DTOs.DepartmentDTOs;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPIs.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        private readonly IEmployeeService _EmployeeService;
        public EmployeesController(IDepartmentService DepartmentService, IEmployeeService EmployeeService)
        {
            _DepartmentService = DepartmentService;
            _EmployeeService = EmployeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeById([FromQuery][Required] int EmployeeId)
        {
            GetEmployeeDTO Employee = await _EmployeeService.GetEmployeeById(EmployeeId);
            if (Employee == null)
                return NotFound();
            return Ok(Employee);
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartmentEmployees([FromQuery][Required] int DepartmentId)
        {
            List<GetEmployeeDTO> Employees = await _EmployeeService.GetDepartmentEmployees(DepartmentId);
            if (Employees == null || Employees.Count == 0)
                return NotFound();
            return Ok(Employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeDTO addEmployeeDTO)
        {
            GetDepartmentDTO getDepartmentDTO = await _DepartmentService.GetDepartmentById(addEmployeeDTO.DepartmentId);
            if (getDepartmentDTO == null)
                return NotFound();
            try
            {
                GetEmployeeDTO AddedEmployee = await _EmployeeService.AddEmployee(addEmployeeDTO);
                if (AddedEmployee == null)
                    return BadRequest();
                return Ok(AddedEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDTO updateEmployeeDTO)
        {
            try
            {
                GetEmployeeDTO UpdatedEmployee = await _EmployeeService.UpdateEmployee(updateEmployeeDTO);
                if (UpdatedEmployee == null)
                    return NotFound();
                return Ok(UpdatedEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [SwaggerOperation(Summary = "Enter Employee Id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromQuery] int EmployeeId)
        {
            try
            {
                bool Deleted = await _EmployeeService.DeleteEmployee(EmployeeId);
                if (Deleted == false)
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
