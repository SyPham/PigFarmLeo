using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class DbPublicWebPrint
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
    }
}
