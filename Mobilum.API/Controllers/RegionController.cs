using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mobilum.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilum.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService, ILogger<RegionController> logger)
        {
            _logger = logger;
            _regionService = regionService;
        }
        [HttpGet("DetectCountryFor")]
        public async Task<IActionResult> DetectCountryFor([FromQuery] string phone)
        {
            try
            {
                var country = await _regionService.DetectCountryFromPhoneNumber(phone);
                if (country == null)
                    return NotFound();

                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}
