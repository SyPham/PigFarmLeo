using System;
using System.Collections.Generic;

namespace PigFarm.DTO
{
    public partial class DisinfectionDto
    {
        public decimal Id { get; set; }
        public string DisinfectionType { get; set; }
        public string DisinfectionNo { get; set; }
        public string DisinfectionName { get; set; }
        public string DisinfectionElement { get; set; }
        public string DisinfectionEffect { get; set; }
        public string DisinfectionSideEffect { get; set; }
        public string DisinfectionBreed { get; set; }
        public string DisinfectionRange { get; set; }
        public string DisinfectionCare { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string FarmGuid { get; set; }
        public string DisinfectionTypeName { get; set; }
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
