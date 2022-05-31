using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class DbPublicGp
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
    }
}
