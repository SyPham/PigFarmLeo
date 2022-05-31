using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Feed
    {
        public decimal Id { get; set; }
        public string FeedType { get; set; }
        public string FeedNo { get; set; }
        public string FeedName { get; set; }
        public string FeedElement { get; set; }
        public string FeedEffect { get; set; }
        public string FeedSideEffect { get; set; }
        public string FeedBreed { get; set; }
        public string FeedRange { get; set; }
        public string FeedCare { get; set; }
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
        public string VendorGuid { get; set; }
        public string Location { get; set; }
        public string Spec { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? ExpireDate { get; set; }

    }
}
