using BP.Service.DTOs.WeightDTOs;
using BP.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace BP.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class WeightsController : ControllerBase
    {
        private readonly IWeightService _weightService;

        public WeightsController(IWeightService weightService)
        {
            _weightService = weightService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _weightService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _weightService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(WeightPostDTO weightPostDTO)
        {
            await _weightService.CreateAsync(weightPostDTO);

            return StatusCode(201);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> Put(int? id, WeightPutDTO weightPutDTO)
        {
            await _weightService.UpdateAsync(id, weightPutDTO);

            return Ok();
        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            await _weightService.DeleteAsync(id);

            return Ok(await _weightService.GetAllAsync());
        }

    }
}
