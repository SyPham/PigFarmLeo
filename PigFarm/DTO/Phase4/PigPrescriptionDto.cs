using System;

namespace PigFarm.DTO
{
    public partial class PigPrescriptionDto
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public string UpperGuid { get; set; }
        public DateTime? RecordDate { get; set; }
        public string RecordTime { get; set; }
        public string Prescription { get; set; }
        public string Comment { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string TypeName { get; set; }
    }
}