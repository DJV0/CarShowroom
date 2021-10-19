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
        public ActionResult<IEnumerable<ClientDTO>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ClientDTO>>(_clientService.GetAll()));
        }

        [HttpGet("{id}")]
        public ActionResult<ClientDetailsDTO> Get(int id)
        {
            _logger.LogInformation($"Getting item with id {id}.");

            return Ok(_mapper.Map<ClientDetailsDTO>(_clientService.Get(id)));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClientDTO clientDTO)
        {
            var client = _clientService.Add(_mapper.Map<Client>(clientDTO));
            return CreatedAtAction(nameof(Get), new { id = client.Id }, _mapper.Map<ClientDTO>(client));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClientDTO client)
        {
            if (id != client.Id) ModelState.AddModelError("id", "Input id doen't match");
            if (!ModelState.IsValid) return BadRequest(ModelState);
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
