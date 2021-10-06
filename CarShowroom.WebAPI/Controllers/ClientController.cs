﻿using AutoMapper;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService service, IMapper mapper)
        {
            _clientService = service;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return Ok(_clientService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            return Ok(_clientService.Get(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClientDTO clientDTO)
        {
            var author = _clientService.Add(_mapper.Map<Client>(clientDTO));
            return CreatedAtAction(nameof(Get), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClientDTO client)
        {
            if (id != client.Id) ModelState.AddModelError("id", "Input id doen't match");
            _clientService.Update(_mapper.Map<Client>(client));
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _clientService.Delete(id);
            return NoContent();
        }
    }
}