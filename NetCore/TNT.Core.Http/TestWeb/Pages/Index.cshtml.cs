using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TNT.Core.Helpers.DI;
using TNT.Core.Http.DI;

namespace TestWeb.Pages
{
    [InjectionFilter]
    public class IndexModel : PageModel
    {
        [Inject]
        private readonly IHostingEnvironment _env;

        public void OnGet()
        {
        }
    }
}
