using BP.Service.DTOs.FrequencyDTOs;
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
    public class FrequenciesController : ControllerBase
    {
        private readonly IFrequencyService _frequencyService;

        public FrequenciesController(IFrequencyService frequencyService)
        {
            _frequencyService = frequencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _frequencyService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _frequencyService.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(FrequencyPostDTO frequencyPostDTO)
        {
            await _frequencyService.CreateAsync(frequencyPostDTO);

            return StatusCode(201);
        }

        [HttpPut]
        [Route("{id?}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int? id, FrequencyPutDTO frequencyPutDTO)
        {
            await _frequencyService.UpdateAsync(id, frequencyPutDTO);

            return Ok();
        }

        [HttpDelete]
        [Route("{id?}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            await _frequencyService.DeleteAsync(id);

            return Ok(await _frequencyService.GetAllAsync());
        }
    }
}
