using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDataService.Models;
using TestDataService.Models.Domains;
using TestDataService.Models.Repositories;

namespace TestCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : AppControllerBase
    {
        [Authorize("Basic")]
        public ActionResult Test()
        {
            return Ok(UoW.Repository<IAppUserRepository>().FirstOrDefault());
        }


    }
}