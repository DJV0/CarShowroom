using AutoMapper;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using CarShowroom.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public ClientController(IClientService service, IMapper mapper, ILogger<ClientController> logger)
        {
            _clientService = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ClientDTO>>(await _clientService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            _logger.LogInformation($"Getting item with id {id}.");

            return Ok(_mapper.Map<ClientDTO>(await _clientService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDTO clientDTO)
        {
            var client = await _clientService.AddAsync(_mapper.Map<Client>(clientDTO));
            return CreatedAtAction(nameof(Get), new { id = client.Id }, _mapper.Map<ClientDTO>(client));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientDTO client)
        {
            if (id != client.Id) ModelState.AddModelError("id", "Input id doen't match");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _clientService.UpdateAsync(_mapper.Map<Client>(client));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
