using System;
using System.Collections.Generic;


namespace PigFarm.DTO
{
    public partial class FeedMaterialDto
    {
        public decimal Id { get; set; }
        public string FeedMaterialType { get; set; }
        public string FeedMaterialNo { get; set; }
        public string FeedMaterialName { get; set; }
        public string FeedMaterialElement { get; set; }
        public string FeedMaterialEffect { get; set; }
        public string FeedMaterialSideEffect { get; set; }
        public string FeedMaterialBreed { get; set; }
        public string FeedMaterialRange { get; set; }
        public string FeedMaterialCare { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
         public DateTime? DeleteDate { get; set; }
        public decimal? DeleteBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string FarmGuid { get; set; }
        public string FeedMaterialTypeName { get; set; }

         public string VendorGuid { get; set; }
        public string Location { get; set; }
        public string Spec { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? ExpireDate { get; set; }

    }
}
