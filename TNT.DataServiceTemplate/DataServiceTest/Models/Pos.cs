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
    
    public partial class Pos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pos()
        {
            this.Stores = new HashSet<Store>();
        }
    
        public int PosId { get; set; }
        public string MacId { get; set; }
        public string PosConfig { get; set; }
        public string PosCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store> Stores { get; set; }
    }
}
