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
    
    public partial class PromotionType
    {
        public int PromotionDetailID { get; set; }
        public int Type { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual PromotionDetail PromotionDetail { get; set; }
    }
}
