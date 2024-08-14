using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Controllers
{
   
    [Route("api/license")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILiceseService _liceseService;
        public LicenseController(ILiceseService liceseService)
        {
            _liceseService = liceseService;
          
        }

        [HttpGet("/license")]
        public async Task<IActionResult> GetAll(){
            var licenses = await _liceseService.GetAllLicense();
            return Ok(licenses);
        }
        [HttpPost("/license")]
        public async Task<IActionResult> PublishLicense([FromBody] LicenseEvent2 licenseEvent2){
            return Ok(await _liceseService.PublishLicense(licenseEvent2));
        }
       
    }
}