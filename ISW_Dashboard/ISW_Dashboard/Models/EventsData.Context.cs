﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ISWEntities : DbContext
    {
        public ISWEntities()
            : base("name=ISWEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_ISW_Data> tbl_ISW_Data { get; set; }
        public virtual DbSet<tbl_ISW_Data_History> tbl_ISW_Data_History { get; set; }
        public virtual DbSet<ProjectVPN> ProjectVPNs { get; set; }
        public virtual DbSet<tbl_ISW_Data_duplicate> tbl_ISW_Data_duplicate { get; set; }
        public virtual DbSet<MigrationType> MigrationTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
