//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISW_Dashboard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer_History
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> MigrationType { get; set; }
        public Nullable<System.DateTime> AssignedDate { get; set; }
        public Nullable<System.DateTime> UnassignedDate { get; set; }
        public Nullable<bool> HVC { get; set; }
        public Nullable<bool> Exception { get; set; }
        public string ExceptionDetail { get; set; }
        public string updatedby { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> state { get; set; }
    }
}