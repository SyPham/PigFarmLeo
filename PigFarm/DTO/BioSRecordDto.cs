using System;

namespace PigFarm.DTO
{
    public partial class BioSRecordDto
    {
        public decimal Id { get; set; }
        public string BioSMasterGuid { get; set; }
        public string Vaccine { get; set; }
        public string UseType { get; set; }
        public string Capacity { get; set; }
        public string Frequency { get; set; }
        public DateTime? RecordDate { get; set; }
        public string RecordTime { get; set; }
        public string Comment { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public decimal? DeleteBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string VaccineName { get; set; }
        public string UseTypeName { get; set; }

    }

}