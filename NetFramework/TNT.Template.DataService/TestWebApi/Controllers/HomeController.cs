using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDataService.Managers;
using TestDataService.Models;
using TestDataService.Models.Repositories;
using TNT.IoC.Container;

namespace TestWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var uow = TContainer.RequestScope.Resolve<IUnitOfWork>();
            var a = uow.Repository<IARepository>();
            var ent = a.FirstOrDefault();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
