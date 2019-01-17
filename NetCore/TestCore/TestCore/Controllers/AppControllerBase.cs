using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TestDataService.Models;
using TNT.Core.IoC.Container;

namespace TestCore.Controllers
{
    public abstract class AppControllerBase : ControllerBase
    {
        private IUnitOfWork uow;
        protected IUnitOfWork UoW
        {
            get
            {
                if (uow == null)
                    uow = this.GetIoC().Resolve<IUnitOfWork>();
                return uow; ;
            }
        }
    }
}