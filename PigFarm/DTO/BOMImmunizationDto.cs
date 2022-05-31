using System;

namespace PigFarm.DTO
{
    public class BomImmunizationDto
    {
        public int Id { get; set; }
        public string BomGuid { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string DiseaseGuid { get; set; }
        public string MedicineGuid { get; set; }
        public string UseType { get; set; }
        public string UseUnit { get; set; }
        public string Capacity { get; set; }
        public string Frequency { get; set; }
        public string Needle { get; set; }
        public string ApplyDays { get; set; }

        public string Disease { get; set; }
        public string Medicine { get; set; }
        public string UseTypeName { get; set; }
        public string UseUnitName { get; set; }
        public string CapacityName { get; set; }
        public string FrequencyName { get; set; }
        public string NeedleName { get; set; }
        public string ApplyDaysName { get; set; }
    }
}
