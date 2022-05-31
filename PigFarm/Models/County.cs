using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class County
    {
        public string CountyId { get; set; }
        public string CountyName { get; set; }
        public string Cmt { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? SigningId { get; set; }
        public string CountyNameOld { get; set; }
    }
}
