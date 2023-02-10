using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.EmployeeDTOs
{
    public class AddEmployeeDTO
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
    }
}
