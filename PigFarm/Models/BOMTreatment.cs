using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class BomTreatment
    {
        public int Id { get; set; }
        public string BomGuid { get; set; }
        public string TreatmentType { get; set; }
        public string TreatmentName { get; set; }
        public string TreatmentMethod { get; set; }
        public string TreatmentMedicine { get; set; }
        public string TreatmentCare { get; set; }
        public string MethodType { get; set; }
        public decimal? MethodFreq { get; set; }
        public decimal? MethodUseTime { get; set; }
        public decimal? MethodAmount { get; set; }
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
