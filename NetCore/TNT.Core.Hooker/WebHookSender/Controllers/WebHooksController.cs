using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TNT.Core.Helpers.Cryptography;

namespace WebHookSender.Controllers
{
    [Route("api/webhooks")]
    [ApiController]
    public class WebHooksController : ControllerBase
    {

        [HttpPost("")]
        public IActionResult Create(WebhookViewModel model)
        {
            if (model.AppKey.StartsWith("TNT"))
            {
                WebhookViewModel.WebHooks.Add(model);
                return NoContent();
            }
            return Unauthorized();
        }

        private static HttpClient http = new HttpClient();
        private static DataHasher dataHasher = new DefaultDataHasher();

        public class Action
        {
            public string Data { get; set; }
        }

        [HttpGet("notify")]
        public IActionResult NotifyReceivers()
        {
            foreach (var wh in WebhookViewModel.WebHooks)
            {
                var mess = new HttpRequestMessage()
                {
                    Content = new ObjectContent<Action>(
                        new Action
                        {
                            Data = "Notified" + WebhookViewModel.WebHooks.Count
                        }, new JsonMediaTypeFormatter()),
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(wh.CallbackUrl)
                };
                string guid = Guid.NewGuid().ToString();
                string sign = wh.SecretKey + guid;
                mess.Headers.Add("X-TNT-Seed", guid);
                mess.Headers.Add("X-TNT-Signature", dataHasher.Hash(sign));
                http.SendAsync(mess);
            }
            return Ok();
        }

    }

    public class WebhookViewModel
    {
        public static List<WebhookViewModel> WebHooks { get; } = new List<WebhookViewModel>();

        public string CallbackUrl;
        public string SecretKey;
        public string AppKey;
    }
}