//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IoCTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeSkill
    {
        public string EmpCode { get; set; }
        public int SkillId { get; set; }
        public Nullable<int> ExpYears { get; set; }
    
        public virtual EmployeeCRM EmployeeCRM { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
