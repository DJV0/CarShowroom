﻿using AutoMapper;
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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarDTO>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<CarDTO>>(_carService.GetAll()));
        }

        [HttpGet("{id}")]
        public ActionResult<CarDTO> Get(int id)
        {
            return Ok(_mapper.Map<CarDTO>(_carService.Get(id)));
        }

        [HttpPost]
        public ActionResult<CarDTO> Post([FromBody] CarDTO carDTO)
        {
            var car = _carService.Add(_mapper.Map<Car>(carDTO));
            return CreatedAtAction(nameof(Get), new { id = car.Id }, _mapper.Map<CarDTO>(car));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _carService.Delete(id);
            return NoContent();
        }
    }
}
