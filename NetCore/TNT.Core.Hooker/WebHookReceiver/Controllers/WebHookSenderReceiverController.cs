using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNT.Core.Helpers.Cryptography;

namespace WebHookReceiver.Controllers
{
    [Route("api/receiver")]
    [ApiController]
    public class WebHookSenderReceiverController : ControllerBase
    {
        private static DataHasher dataHasher = new DefaultDataHasher();
        private static List<Action> Actions = new List<Action>();
        private static string secretKey = "TNT";

        [HttpPost("")]
        public IActionResult Handler(Action action)
        {
            var seed = Request.Headers["X-TNT-Seed"].FirstOrDefault();
            var sign = dataHasher.Hash(secretKey + seed);
            if (!sign.Equals(Request.Headers["X-TNT-Signature"].FirstOrDefault()))
                return BadRequest();
            Actions.Add(action);
            return NoContent();
        }

        public class Action
        {
            public string Data { get; set; }
        }

    }
    
}