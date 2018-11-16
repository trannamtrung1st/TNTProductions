﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PromoterDataService.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PromoterEntities : DbContext
    {
        public PromoterEntities()
            : base("name=PromoterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AffliatorCashbackDetail> AffliatorCashbackDetails { get; set; }
        public virtual DbSet<AppAction> AppActions { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCashbackDetail> CustomerCashbackDetails { get; set; }
        public virtual DbSet<CustomerSegment> CustomerSegments { get; set; }
        public virtual DbSet<GiftAppliedDetail> GiftAppliedDetails { get; set; }
        public virtual DbSet<GiftDetail> GiftDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<PromotionAppliedDetail> PromotionAppliedDetails { get; set; }
        public virtual DbSet<PromotionApplySituation> PromotionApplySituations { get; set; }
        public virtual DbSet<PromotionDetail> PromotionDetails { get; set; }
        public virtual DbSet<PromotionStoreRule> PromotionStoreRules { get; set; }
        public virtual DbSet<PromotionType> PromotionTypes { get; set; }
        public virtual DbSet<Redemption> Redemptions { get; set; }
        public virtual DbSet<RedemptionRollback> RedemptionRollbacks { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<ValidationRule> ValidationRules { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<VoucherConfig> VoucherConfigs { get; set; }
    }
}
