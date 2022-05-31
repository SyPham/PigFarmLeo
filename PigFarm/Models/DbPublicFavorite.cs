using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class DbPublicFavorite
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string AccountGuid { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
