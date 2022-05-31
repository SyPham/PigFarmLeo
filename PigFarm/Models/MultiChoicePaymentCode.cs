using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class MultiChoicePaymentCode
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string CodeNo { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
    }
}
