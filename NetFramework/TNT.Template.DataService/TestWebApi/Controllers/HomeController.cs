using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDataService.Models;
using TestDataService.Models.Repositories;
using TNT.IoC.Container;

namespace TestWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Test()
        {
            var uow = TContainer.RequestScope.Resolve<IUnitOfWork>();
            var a = uow.Repository<IAppUserRepository>();
            var ent = a.FirstOrDefault();
            return Json(ent, JsonRequestBehavior.AllowGet);
        }
    }
}
