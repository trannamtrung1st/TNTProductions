using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TOAuth.Controllers
{
    [Route("")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("Welcome to TOAuth Api");
        }

    }
}