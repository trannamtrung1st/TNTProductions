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
    
    public partial class Membership
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Membership()
        {
            this.MembershipAccounts = new HashSet<MembershipAccount>();
            this.MembershipCards = new HashSet<MembershipCard>();
        }
    
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<System.DateTime> Since { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MembershipAccount> MembershipAccounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MembershipCard> MembershipCards { get; set; }
    }
}
