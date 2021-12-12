using AutoMapper;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CarShowroom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Roles = "Admin,Manager")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _logger = logger;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(await _employeeService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            _logger.LogInformation($"Getting item with id {id}.");

            return Ok(_mapper.Map<EmployeeDTO>(await _employeeService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Post([FromBody] EmployeeDTO employeeDTO)
        {
            var employee = await _employeeService.AddAsync(_mapper.Map<Employee>(employeeDTO));
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, _mapper.Map<EmployeeDTO>(employee));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id) ModelState.AddModelError("id", "Entered id doen't match with entity id");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _employeeService.UpdateAsync(_mapper.Map<Employee>(employeeDTO));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
