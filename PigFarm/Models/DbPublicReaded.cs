using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class DbPublicReaded
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string AccountGuid { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
