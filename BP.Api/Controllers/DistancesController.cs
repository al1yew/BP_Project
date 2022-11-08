using BP.Service.DTOs.DistanceDTOs;
using BP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class DistancesController : ControllerBase
    {
        private readonly IDistanceService _distanceService;

        public DistancesController(IDistanceService distanceService)
        {
            _distanceService = distanceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _distanceService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _distanceService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(DistancePostDTO distancePostDTO)
        {
            await _distanceService.CreateAsync(distancePostDTO);

            return StatusCode(201);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> Put(int? id, DistancePutDTO distancePutDTO)
        {
            await _distanceService.UpdateAsync(id, distancePutDTO);

            return Ok();
        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            await _distanceService.DeleteAsync(id);

            return Ok(await _distanceService.GetAllAsync());
        }
    }
}
