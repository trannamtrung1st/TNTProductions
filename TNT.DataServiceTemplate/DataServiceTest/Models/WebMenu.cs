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
    
    public partial class WebMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WebMenu()
        {
            this.WebMenu1 = new HashSet<WebMenu>();
        }
    
        public int Id { get; set; }
        public string MenuText { get; set; }
        public string MenuText1 { get; set; }
        public string MenuText2 { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public Nullable<int> ParentMenuId { get; set; }
        public Nullable<int> MenuLevel { get; set; }
        public Nullable<int> StoreFilter { get; set; }
        public bool Active { get; set; }
        public bool IsSystemMenu { get; set; }
        public int CategoryId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WebMenu> WebMenu1 { get; set; }
        public virtual WebMenu WebMenu2 { get; set; }
        public virtual WebMenuCategory WebMenuCategory { get; set; }
    }
}
