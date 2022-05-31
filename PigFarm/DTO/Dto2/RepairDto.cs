using System;

namespace PigFarm.DTO
{
    public partial class RepairDto
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public DateTime? RepairDate { get; set; }
        public string RepairTime { get; set; }
        public string RepairNo { get; set; }
        public string RepairName { get; set; }
        public string RepairComment { get; set; }
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
    }
}