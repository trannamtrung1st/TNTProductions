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
    
    public partial class InventoryDateReportItem
    {
        public int ItemID { get; set; }
        public double Quantity { get; set; }
        public int ReportID { get; set; }
        public Nullable<double> ImportAmount { get; set; }
        public Nullable<double> ExportAmount { get; set; }
        public Nullable<double> CancelAmount { get; set; }
        public Nullable<double> SoldAmount { get; set; }
        public Nullable<double> ReturnAmount { get; set; }
        public Nullable<double> ChangeInventoryAmount { get; set; }
        public Nullable<double> TheoryAmount { get; set; }
        public Nullable<double> RealAmount { get; set; }
        public Nullable<double> TotalExport { get; set; }
        public Nullable<double> TotalImport { get; set; }
        public Nullable<double> ReceivedChangeInventoryAmount { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public double Price { get; set; }
    
        public virtual InventoryDateReport InventoryDateReport { get; set; }
        public virtual ProductItem ProductItem { get; set; }
    }
}
