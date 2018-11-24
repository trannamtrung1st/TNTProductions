using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Promoter.DataService.Utilities;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Repositories;
using Promoter.DataService.Global;
using TNT.IoContainer.Wrapper;
using Promoter.DataService.APIs.Models;

namespace Promoter.DataService.Models.Services
{
    public partial interface IBrandService : IBaseService<Brand, int>
    {
        IQueryable<Brand> GetBrand(BrandRequest req);
    }

    public partial class BrandService : BaseService<Brand, int>, IBrandService
    {
        public BrandService(IUnitOfWork uow)
        {
            repository = uow.Scope.Resolve<IBrandRepository>(uow);
        }

        public BrandService(PromoterEntities context)
        {
            repository = G.TContainer.Resolve<IBrandRepository>(context);
        }

        public IQueryable<Brand> GetBrand(BrandRequest req)
        {
            var brand = GetActive();
            if (req == null)
                return brand;
            if (req.brand_id != null)
                brand = brand.Where(br => br.Id == req.brand_id);
            return brand;
        }
    }
}
