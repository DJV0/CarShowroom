using AutoMapper;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(_employeeService.GetAll()));
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDetailsDTO> Get(int id)
        {
            return Ok(_mapper.Map<EmployeeDetailsDTO>(_employeeService.Get(id)));
        }

        [HttpPost]
        public ActionResult<EmployeeDTO> Post([FromBody] EmployeeDTO employeeDTO)
        {
            var employee = _employeeService.Add(_mapper.Map<Employee>(employeeDTO));
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, _mapper.Map<EmployeeDTO>(employee));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id) ModelState.AddModelError("id", "Entered id doen't match with entity id");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _employeeService.Update(_mapper.Map<Employee>(employeeDTO));
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return NoContent();
        }
    }
}
