//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PromotionDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PromotionDetail()
        {
            this.Promotions = new HashSet<Promotion>();
            this.Vouchers = new HashSet<Voucher>();
        }
    
        public int Id { get; set; }
        public Nullable<bool> IsDiscount { get; set; }
        public Nullable<int> DiscountAmount { get; set; }
        public Nullable<int> DiscountUnit { get; set; }
        public string DiscountUnitValue { get; set; }
        public Nullable<bool> IsGift { get; set; }
        public string GiftAmounts { get; set; }
        public string GiftCodesExpr { get; set; }
        public string GiftUnits { get; set; }
        public Nullable<bool> Deactive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promotion> Promotions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
