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
    
    public partial class LanguageValue
    {
        public int Id { get; set; }
        public int LanguageKeyId { get; set; }
        public int LanguageId { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual LanguageKey LanguageKey { get; set; }
    }
}
