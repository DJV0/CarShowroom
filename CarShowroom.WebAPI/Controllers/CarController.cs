using AutoMapper;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ILogger<CarController> _logger;
        public CarController(ICarService carService, IMapper mapper, ILogger<CarController> logger)
        {
            _carService = carService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<CarDTO>>(await _carService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> Get(int id)
        {
            _logger.LogInformation($"Getting item with id {id}.");

            return Ok(_mapper.Map<CarDTO>(await _carService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> Post([FromBody] CarDTO carDTO)
        {
            var car = await _carService.AddAsync(_mapper.Map<Car>(carDTO));
            return CreatedAtAction(nameof(Get), new { id = car.Id }, _mapper.Map<CarDTO>(car));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CarDTO carDTO)
        {
            if (id != carDTO.Id) ModelState.AddModelError("id", "Entered id doen't match with entity id");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _carService.UpdateAsync(_mapper.Map<Car>(carDTO));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _carService.DeleteAsync(id);
            return NoContent();
        }
    }
}
