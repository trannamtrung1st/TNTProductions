using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TNT.Core.Helpers.DI;
using TNT.Core.Http.DI;

namespace TestWeb31.Pages
{
    [InjectionFilter]
    public class IndexModel : PageModel
    {
        [Inject]
        private readonly IWebHostEnvironment _env;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
