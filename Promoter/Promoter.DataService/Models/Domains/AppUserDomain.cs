using Promoter.DataService.Managers;
using Promoter.DataService.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.Models.Domains
{
    public class AppUserDomain : BaseDomain
    {
        #region Constructor
        public AppUserDomain() : base()
        {
        }

        public AppUserDomain(IUnitOfWork uow) : base(uow)
        {
        }

        public AppUserDomain(PromoterEntities db) : base(db)
        {
        }
        #endregion

        public void CreateBrand(Brand brand)
        {
            var bService = UoW.Service<IBrandService>();
            bService.Add(brand);
            UoW.SaveChanges();
        }

        public void CreateCustomer(Customer customer)
        {
            var cService = UoW.Service<ICustomerService>();
            cService.Add(customer);
            UoW.SaveChanges();
        }

        public void CreateBrandAccount(BrandAccount brandAccount)
        {
            var bAccService = UoW.Service<IBrandAccountService>();
            bAccService.Add(brandAccount);
            UoW.SaveChanges();
        }

        public void RegisterBrandMembership(int customerId, int brandId)
        {
            var cService = UoW.Service<ICustomerService>();
            var customer = cService.FindById(customerId);
            //Send request to brand and wait for accept
        }

        public void AcceptBrandMembership(int brandId, int customerId)
        {
            var trans = UoW.BeginTransaction();
            var mService = UoW.Service<IMembershipService>();
            var mCardService = UoW.Service<IMembershipCardService>();
            var mAccService = UoW.Service<IMembershipAccountService>();

            var membership = new Membership()
            {
                BrandId = brandId,
                CustomerId = customerId,
                Since = DateTime.Now
            };

            var mCard = new MembershipCard()
            {
                Code = "ASBIEWPWEWE",
                Membership = membership,
                Type = 1
            };

            var mAcc = new MembershipAccount()
            {
                Code = "DA(@!#!@ASD",
                Balance = 0,
                Membership = membership,
                Type = 0
            };

            mService.Add(membership);
            mCardService.Add(mCard);
            mAccService.Add(mAcc);
            UoW.SaveChanges();
            trans.Commit();
        }

    }
}
