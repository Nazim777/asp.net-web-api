using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Controllers
{
     [Route("api/user")]
     [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
            
        }
         [HttpGet]
        public async Task<IActionResult> GetAll(){
            var users = await _userServices.GetALlUserAsync();
            return Ok(users);

        }
        [HttpPost]
        public async Task<IActionResult>AddUser([FromBody] User user){
           string msg = await _userServices.PostUserAsync(user);
            return Ok(msg);
        }
         [HttpGet("/publishlicense")]
         public async Task<IActionResult> AllLicense(){
            var licenses = await _userServices.GetAllLicense();
            return Ok(licenses);
         }
        [HttpPost("/publishlicense")]
        public async Task<IActionResult>LicenseEventPublish([FromBody] LicenseEvent licenseEvent){
           string msg = await _userServices.PublishLicenseEvent(licenseEvent);
            return Ok(msg);
        }
        
    }
}