using Promoter.DataService.Models;
using Promoter.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.Global
{
    public partial class G
    {

        public static void Configure()
        {
            G.MapperConfigs.Add(
            cfg =>
            {
                cfg.CreateMap<PC_DateTimeFilter, PC_DateTimeFilterViewModel>().ReverseMap();
                cfg.CreateMap<PC_ProductFilter, PC_ProductFilterViewModel>().ReverseMap();
                cfg.CreateMap<PC_StoreFilter, PC_StoreFilterViewModel>().ReverseMap();
                cfg.CreateMap<Promotion, PromotionViewModel>().ReverseMap();
                cfg.CreateMap<PromotionAwardCashback, PromotionAwardCashbackViewModel>().ReverseMap();
                cfg.CreateMap<PromotionAwardDiscount, PromotionAwardDiscountViewModel>().ReverseMap();
                cfg.CreateMap<PromotionAwardGift, PromotionAwardGiftViewModel>().ReverseMap();
                cfg.CreateMap<PromotionConstraint, PromotionConstraintViewModel>().ReverseMap();
                cfg.CreateMap<PromotionDetail, PromotionDetailViewModel>().ReverseMap();
                cfg.CreateMap<Voucher, VoucherViewModel>().ReverseMap();
            });

            G.DefaultConfigure();
        }

    }
}
