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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, IMapper mapper, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<OrderDTO>>(_orderService.GetAll()));
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDetailsDTO> Get(int id)
        {
            _logger.LogInformation($"Getting item with id {id}.");

            return Ok(_mapper.Map<OrderDetailsDTO>(_orderService.Get(id)));
        }

        [HttpPost]
        public ActionResult<OrderDetailsDTO> Post([FromBody] OrderDetailsDTO orderDetailsDTO)
        {
            var order = _orderService.Add(_mapper.Map<Order>(orderDetailsDTO));
            return CreatedAtAction(nameof(Get), new { id = order.Id }, _mapper.Map<OrderDetailsDTO>(order));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] OrderDetailsDTO orderDetailsDTO)
        {
            if (id != orderDetailsDTO.Id) ModelState.AddModelError("id", "Entered id doen't match with entity id");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _orderService.Update(_mapper.Map<Order>(orderDetailsDTO));
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return NoContent();
        }
    }
}
