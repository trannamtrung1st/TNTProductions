using PromoterDataService.Global;
using PromoterDataService.ViewModels;
using PromoterDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PromoterDataService.Models;

[assembly: PreApplicationStartMethod(typeof(PromoterApi.Configurations.PreApplicationStartConfig), "Configure")]
namespace PromoterApi.Configurations
{
    public static class PreApplicationStartConfig
    {

        public static void Configure()
        {
            G.AddMapperConfig(cfg =>
            {
                cfg.CreateMap<AffliatorCashbackDetail, AffliatorCashbackDetailViewModel>().ReverseMap();
                cfg.CreateMap<AppAction, AppActionViewModel>().ReverseMap();
                cfg.CreateMap<Campaign, CampaignViewModel>().ReverseMap();
                cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
                cfg.CreateMap<CustomerCashbackDetail, CustomerCashbackDetailViewModel>().ReverseMap();
                cfg.CreateMap<CustomerSegment, CustomerSegmentViewModel>().ReverseMap();
                cfg.CreateMap<GiftAppliedDetail, GiftAppliedDetailViewModel>().ReverseMap();
                cfg.CreateMap<GiftDetail, GiftDetailViewModel>().ReverseMap();
                cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
                cfg.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
                cfg.CreateMap<Partner, PartnerViewModel>().ReverseMap();
                cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                cfg.CreateMap<Promotion, PromotionViewModel>().ReverseMap();
                cfg.CreateMap<PromotionAppliedDetail, PromotionAppliedDetailViewModel>().ReverseMap();
                cfg.CreateMap<PromotionDetail, PromotionDetailViewModel>().ReverseMap();
                cfg.CreateMap<PromotionStoreRule, PromotionStoreRuleViewModel>().ReverseMap();
                cfg.CreateMap<Redemption, RedemptionViewModel>().ReverseMap();
                cfg.CreateMap<RedemptionRollback, RedemptionRollbackViewModel>().ReverseMap();
                cfg.CreateMap<Segment, SegmentViewModel>().ReverseMap();
                cfg.CreateMap<Store, StoreViewModel>().ReverseMap();
                cfg.CreateMap<ValidationRule, ValidationRuleViewModel>().ReverseMap();
                cfg.CreateMap<Voucher, VoucherViewModel>().ReverseMap();
                cfg.CreateMap<VoucherConfig, VoucherConfigViewModel>().ReverseMap();
            });
            G.DefaultConfigure();
        }

    }
}