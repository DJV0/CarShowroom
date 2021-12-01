using CarShowroom.Client.DTOs;
using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using CarShowroom.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeClient _employeeClient;
        public EmployeeService(IEmployeeClient employeeClient)
        {
            _employeeClient = employeeClient;
        }

        public async Task<bool> CreateEmployee(EmployeeDTO employee)
        {
            return await _employeeClient.Create(employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _employeeClient.Delete(id);
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            return await _employeeClient.GetById(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            return await _employeeClient.GetAll();
        }

        public async Task<bool> UpdateEmployee(int employeeId, EmployeeDTO employee)
        {
            return await _employeeClient.Update(employeeId, employee);
        }
    }
}
