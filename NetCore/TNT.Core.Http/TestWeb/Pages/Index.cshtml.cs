using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TNT.Core.Http;

namespace TestWeb.Pages
{
    public class IndexModel : PageModel
    {
        [Inject]
        private IHostingEnvironment _env { get; set; }

        public override Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            HttpContext.Inject(this);
            return base.OnPageHandlerSelectionAsync(context);
        }

        public IndexModel()
        {
        }

        public void OnGet()
        {
        }
    }
}
