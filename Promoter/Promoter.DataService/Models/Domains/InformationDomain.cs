using Promoter.DataService.APIs.Models;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.Models.Domains
{
    public class InformationDomain : BaseDomain
    {

        #region Constructor
        public InformationDomain() : base()
        {
        }

        public InformationDomain(IUnitOfWork uow) : base(uow)
        {
        }

        public InformationDomain(PromoterEntities db) : base(db)
        {
        }
        #endregion

        public IQueryable<Brand> GetBrand(BrandRequest req)
        {
            var bService = UoW.Service<IBrandService>();
            var brand = bService.GetBrand(req);
            return brand;
        }

    }
}
