using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PigFarm.DTO
{
    public class BomFeedDto
    {
        public int Id { get; set; }
        public string BomGuid { get; set; }
        public string FeedType { get; set; }
        public string FeedName { get; set; }
        public string FeedMethod { get; set; }
        public string FeedAvoid { get; set; }
        public string FeedMaterial1 { get; set; }
        public string FeedMaterial2 { get; set; }
        public string FeedMaterial3 { get; set; }
        public string FeedMaterial4 { get; set; }
        public string FeedMaterial5 { get; set; }
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
        public string FeedTypeName { get; set; }

        public string FeedMaterial1Name { get; set; }
        public string FeedMaterial2Name { get; set; }
        public string FeedMaterial3Name { get; set; }
        public string FeedMaterial4Name { get; set; }
        public string FeedMaterial5Name { get; set; }
        public string MethodTypeName { get; set; }
    }
}
