using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class JournalPhoto
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string PhotoPath { get; set; }
        public string Reduced { get; set; }
    }
}
