using Promoter.DataService.Models;
using Promoter.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.Global
{
    public static partial class G
    {

        public static void Configure()
        {

            MapperConfigs.Add(cfg =>
                {
                    cfg.CreateMap<Brand, BrandViewModel>().ReverseMap();
                    cfg.CreateMap<BrandAccount, BrandAccountViewModel>().ReverseMap();
                    cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
                    cfg.CreateMap<Membership, MembershipViewModel>().ReverseMap();
                    cfg.CreateMap<MembershipAccount, MembershipAccountViewModel>().ReverseMap();
                    cfg.CreateMap<MembershipCard, MembershipCardViewModel>().ReverseMap();
                }
            );
            G.DefaultConfigure();
        }
    }
}
