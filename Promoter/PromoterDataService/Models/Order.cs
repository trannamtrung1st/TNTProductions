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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
            this.PromotionAppliedDetails = new HashSet<PromotionAppliedDetail>();
        }
    
        public int Id { get; set; }
        public string Code { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<double> FinalAmount { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string CashierObject { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> StoreId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionAppliedDetail> PromotionAppliedDetails { get; set; }
    }
}
