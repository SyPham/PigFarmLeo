using System;
namespace PigFarm.DTO
{
    public partial class PigCodeDto
    {
        public decimal Id { get; set; }
        public string EarNo { get; set; }
        public string EarTag { get; set; }
        public string Rfid { get; set; }
        public string PedigreeGuid { get; set; }
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