using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class SysLogUser
    {
        public decimal SluId { get; set; }
        public string SluType { get; set; }
        public string SluModule { get; set; }
        public string SluPage { get; set; }
        public string SluIp { get; set; }
        public string SluWip { get; set; }
        public decimal? AccountId { get; set; }
        public string SluFid { get; set; }
        public string SluUid { get; set; }
        public DateTime? SluDate { get; set; }
        public string SluTime { get; set; }
        public string SluText { get; set; }
        public string SluFunction { get; set; }
        public string SluUrl { get; set; }
        public string SluSql { get; set; }
    }
}
