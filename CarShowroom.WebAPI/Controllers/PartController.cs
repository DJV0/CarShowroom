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
    [Authorize(Roles ="Admin,Manager")]
    public class PartController : ControllerBase
    {
        private readonly IPartService _partService;
        private readonly IMapper _mapper;
        private readonly ILogger<PartController> _logger;
        public PartController(IPartService partService, IMapper mapper, ILogger<PartController> logger)
        {
            _partService = partService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartDTO>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<PartDTO>>(await _partService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartDTO>> Get(int id)
        {
            _logger.LogInformation($"Getting item with id {id}.");

            return Ok(_mapper.Map<PartDTO>(await _partService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult<PartDTO>> Post([FromBody] PartDTO partDTO)
        {
            var part = await _partService.AddAsync(_mapper.Map<Part>(partDTO));
            return CreatedAtAction(nameof(Get), new { id = part.Id }, _mapper.Map<PartDTO>(part));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PartDTO partDTO)
        {
            if (id != partDTO.Id) ModelState.AddModelError("id", "Entered id doen't match with entity id");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _partService.UpdateAsync(_mapper.Map<Part>(partDTO));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _partService.DeleteAsync(id);
            return NoContent();
        }

    }
}
