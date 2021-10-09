using AutoMapper;
using CarShowroom.BLL.Interfaces;
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
    }
}
