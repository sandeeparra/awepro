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
    
    public partial class tbl_ISW_Data_duplicate
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CategoryName { get; set; }
        public string MigrationType { get; set; }
        public Nullable<int> MigrationWindow { get; set; }
        public Nullable<int> MigrationGroup { get; set; }
        public Nullable<System.DateTime> ExpectedKickOff { get; set; }
        public string MigratorName { get; set; }
        public string PeerReviewer { get; set; }
        public string DMName { get; set; }
        public Nullable<System.DateTime> LastKickOffEmailSent { get; set; }
        public Nullable<int> KickOffStatus { get; set; }
        public Nullable<int> ScheduleCount { get; set; }
        public Nullable<int> SuccessCount { get; set; }
        public Nullable<int> InProgressCount { get; set; }
        public Nullable<int> FailedCount { get; set; }
        public Nullable<int> CurrentPowerBICount { get; set; }
        public Nullable<int> PreviousPowerBICount { get; set; }
        public Nullable<int> EventStatus { get; set; }
        public Nullable<int> UpdateStatus { get; set; }
        public Nullable<System.DateTime> LastUpdateEmailSent { get; set; }
        public string CurrentSummary { get; set; }
        public string CommentsForDelayKickOff { get; set; }
        public Nullable<System.DateTime> NextUpdateTime { get; set; }
        public string Exception { get; set; }
        public Nullable<System.DateTime> ScheduledDate { get; set; }
        public string ActivityName { get; set; }
        public string updatedby { get; set; }
        public Nullable<System.DateTime> updateddate { get; set; }
        public Nullable<bool> MigrationApplied { get; set; }
        public string KBUsed { get; set; }
        public Nullable<int> Effort { get; set; }
        public Nullable<bool> PowerBIUpdated { get; set; }
        public Nullable<int> parent_id { get; set; }
        public string AssignBy { get; set; }
        public Nullable<System.DateTime> AssignDate { get; set; }
        public Nullable<System.DateTime> transferredDate { get; set; }
        public Nullable<System.DateTime> migrationCompleted { get; set; }
        public string ResourceDeliveryGroupName { get; set; }
        public Nullable<int> taskId { get; set; }
        public string unitId { get; set; }
        public string processlinename { get; set; }
        public string statusChar { get; set; }
    }
}
