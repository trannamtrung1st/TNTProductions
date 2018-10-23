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
    
    public partial class StoreTheme
    {
        public int StoreThemeId { get; set; }
        public int StoreId { get; set; }
        public string ThemeName { get; set; }
        public int ThemeId { get; set; }
        public string StoreThemeName { get; set; }
        public string ThemeLogoUrl { get; set; }
        public string CustomThemeStyle { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsUsing { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    
        public virtual Store Store { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
