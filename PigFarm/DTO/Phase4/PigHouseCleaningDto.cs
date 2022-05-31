using System;

namespace PigFarm.DTO
{
    public partial class PigHouseCleaningDto
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public string PigType { get; set; }
        public DateTime? RecordDate { get; set; }
        public string RecordReason { get; set; }
        public string RecordGuid { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string ApproveReason { get; set; }
        public string ApproveGuid { get; set; }
        public DateTime? RejectDate { get; set; }
        public string RejectReason { get; set; }
        public string RejectGuid { get; set; }
        public string Comment { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }

        public string TypeName { get; set; }
        public string PigTypeName { get; set; }
    }
}