//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataServiceTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partner()
        {
            this.PartnerMappings = new HashSet<PartnerMapping>();
        }
    
        public int ID { get; set; }
        public string PartnerCode { get; set; }
        public string PartnerName { get; set; }
        public Nullable<int> PartnerType { get; set; }
        public string AvatarUrl { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public string PartnerAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartnerMapping> PartnerMappings { get; set; }
    }
}
