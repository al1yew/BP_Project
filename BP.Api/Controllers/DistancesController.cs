using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DistancesController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            return Content("DistancesController");
        }
    }
}
