using BusinessLogicLayer.DTOs.DepartmentDTOs;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CompanyAPIs.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        private readonly IEmployeeService _EmployeeService;
        public DepartmentsController(IDepartmentService DepartmentService, IEmployeeService EmployeeService)
        {
            _DepartmentService = DepartmentService;
            _EmployeeService = EmployeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            List<GetDepartmentDTO> Departments = await _DepartmentService.GetAllDepartments();
            if (Departments == null || Departments.Count == 0)
                return NotFound();
            return Ok(Departments);
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentDTO addDepartmentDTO)
        {
            try
            {
                GetDepartmentDTO AddedDepartment = await _DepartmentService.AddDepartment(addDepartmentDTO);
                return Ok(AddedDepartment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentDTO updateDepartmentDTO)
        {
            try
            {
                GetDepartmentDTO UpdatedDepartment = await _DepartmentService.UpdateDepartment(updateDepartmentDTO);
                if (UpdatedDepartment == null)
                    return NotFound();
                return Ok(UpdatedDepartment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [SwaggerOperation(Summary = "Enter Department Id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment([FromQuery] int DepartmentId)
        {
            GetDepartmentDTO getDepartmentDTO = await _DepartmentService.GetDepartmentById(DepartmentId);
            if (getDepartmentDTO == null)
                return NotFound();
            try
            {
                bool Deleted = await _EmployeeService.DeleteDepartmentEmployees(DepartmentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            try
            {
                bool Deleted = await _DepartmentService.DeleteDepartment(DepartmentId);
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
