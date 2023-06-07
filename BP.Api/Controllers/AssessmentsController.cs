using BP.Service.DTOs.AssessmentDTOs;
using BP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BP.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AssessmentsController : ControllerBase
    {
        private readonly IAssessmentService _assessmentService;

        public AssessmentsController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] SortDTO sortDTO)
        //{
        //    return Ok(await _assessmentService.Get(sortDTO));
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _assessmentService.Get());
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _assessmentService.GetById(id));
        }

        //[HttpGet]
        //[Route("getalldata")]
        //public async Task<IActionResult> GetAllData()
        //{
        //    return Ok(await _assessmentService.GetAllData());
        //}

        [HttpPost]
        [Route("checkassessment")]
        public async Task<IActionResult> CheckAssessment(CheckAssessmentDTO checkAssessmentDTO)
        {
            return Ok(await _assessmentService.CheckAssessment(checkAssessmentDTO));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(AssessmentPostDTO assessmentPostDTO)
        {
            await _assessmentService.CreateAsync(assessmentPostDTO);

            return StatusCode(201);
        }

        [HttpPut]
        [Route("{id?}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int? id, AssessmentPutDTO assessmentPutDTO)
        {
            await _assessmentService.UpdateAsync(id, assessmentPutDTO);

            return Ok();
        }

        [HttpDelete]
        [Route("{id?}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _assessmentService.DeleteAsync(id));
        }
    }
}
