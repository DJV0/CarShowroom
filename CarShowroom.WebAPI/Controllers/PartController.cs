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

namespace CarShowroom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
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
        public ActionResult<IEnumerable<PartDTO>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<PartDTO>>(_partService.GetAll()));
        }

        [HttpGet("{id}")]
        public ActionResult<PartDetailsDTO> Get(int id)
        {
            _logger.LogInformation($"Getting item with id {id}.");

            return Ok(_mapper.Map<PartDetailsDTO>(_partService.Get(id)));
        }

        [HttpPost]
        public ActionResult<PartDTO> Post([FromBody] PartDTO partDTO)
        {
            var part = _partService.Add(_mapper.Map<Part>(partDTO));
            return CreatedAtAction(nameof(Get), new { id = part.Id }, _mapper.Map<PartDTO>(part));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PartDTO partDTO)
        {
            if (id != partDTO.Id) ModelState.AddModelError("id", "Entered id doen't match with entity id");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _partService.Update(_mapper.Map<Part>(partDTO));
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _partService.Delete(id);
            return NoContent();
        }

    }
}
