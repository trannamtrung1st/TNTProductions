//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Promoter.DataService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PromotionDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PromotionDetail()
        {
            this.PromotionAwardCashbacks = new HashSet<PromotionAwardCashback>();
            this.PromotionAwardDiscounts = new HashSet<PromotionAwardDiscount>();
            this.PromotionAwardGifts = new HashSet<PromotionAwardGift>();
            this.PromotionConstraints = new HashSet<PromotionConstraint>();
            this.Vouchers = new HashSet<Voucher>();
        }
    
        public int PromotionDetailId { get; set; }
        public string DetailCode { get; set; }
        public string Description { get; set; }
        public Nullable<int> ApplyQuantity { get; set; }
        public Nullable<int> AppliedQuantity { get; set; }
        public bool HasVoucher { get; set; }
        public Nullable<int> VoucherQuantity { get; set; }
        public Nullable<int> VoucherUsedQuantity { get; set; }
        public bool AwardDiscount { get; set; }
        public bool AwardGift { get; set; }
        public bool AwardCashback { get; set; }
        public Nullable<int> AutoGenLength { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string Pattern { get; set; }
        public Nullable<int> PromotionPartnerId { get; set; }
        public int PromotionId { get; set; }
        public bool Active { get; set; }
    
        public virtual Promotion Promotion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionAwardCashback> PromotionAwardCashbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionAwardDiscount> PromotionAwardDiscounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionAwardGift> PromotionAwardGifts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionConstraint> PromotionConstraints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
