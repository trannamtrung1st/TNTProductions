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
    
    public partial class ImageCollectionItem
    {
        public int Id { get; set; }
        public int ImageCollectionId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
        public int Position { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    
        public virtual ImageCollection ImageCollection { get; set; }
    }
}
