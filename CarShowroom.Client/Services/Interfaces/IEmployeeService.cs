using CarShowroom.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<bool> CreateEmployee(EmployeeDTO employee);
        Task<bool> UpdateEmployee(int employeeId, EmployeeDTO employee);
        Task<bool> DeleteEmployee(int id);
    }
}
