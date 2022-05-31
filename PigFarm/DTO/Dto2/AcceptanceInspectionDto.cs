using System;

namespace PigFarm.DTO
{
    public partial class AcceptanceInspectionDto
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string AcceptanceGuid { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string InspectionTime { get; set; }
        public string InspectionDept { get; set; }
        public string InspectionReason { get; set; }
        public string AccountGuid { get; set; }
        public DateTime? RejectDate { get; set; }
        public string RejectReason { get; set; }
        public string RejectGuid { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string InspectionDeptName { get; set; }
    }
}