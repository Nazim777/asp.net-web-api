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
        
    }
}