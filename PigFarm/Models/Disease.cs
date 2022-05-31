using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Disease
    {
        public decimal Id { get; set; }
        public string DiseaseType { get; set; }
        public string DiseaseNo { get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseElement { get; set; }
        public string DiseaseEffect { get; set; }
        public string DiseaseCare { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string FarmGuid { get; set; }
    }
}
