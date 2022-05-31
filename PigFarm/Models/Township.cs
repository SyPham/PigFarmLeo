using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Township
    {
        public string CountyId { get; set; }
        public string TownshipId { get; set; }
        public string TownshipName { get; set; }
        public string Cmt { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public string MlsId { get; set; }
        public string CountyIdOld { get; set; }
        public string TownshipNameOld { get; set; }
    }
}
