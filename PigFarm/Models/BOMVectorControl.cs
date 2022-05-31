using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class BomVectorControl
    {
        public int Id { get; set; }
        public string BomGuid { get; set; }
        public string VectorControlType { get; set; }
        public string VectorControlName { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string VectorControlGuid { get; set; }
        public string UseType { get; set; }
        public string UseUnit { get; set; }
        public string Capacity { get; set; }
        public string Frequency { get; set; }
        public string ApplyDays { get; set; }
    }
}
