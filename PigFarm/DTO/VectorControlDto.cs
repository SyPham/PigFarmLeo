using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.DTO
{
    public partial class VectorControlDto
    {
        public decimal Id { get; set; }
        public string VectorControlType { get; set; }
        public string VectorControlNo { get; set; }
        public string VectorControlName { get; set; }
        public string VectorControlElement { get; set; }
        public string VectorControlEffect { get; set; }
        public string VectorControlSideEffect { get; set; }
        public string VectorControlBreed { get; set; }
        public string VectorControlRange { get; set; }
        public string VectorControlCare { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string FarmGuid { get; set; }
        public string VectorControlTypeName { get; set; }
           public DateTime? DeleteDate { get; set; }
        public decimal? DeleteBy { get; set; }
         public string VendorGuid { get; set; }
        public string Location { get; set; }
        public string Spec { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? ExpireDate { get; set; }
    public string LocationName { get; set; }


    }
}
