using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class DbPublicPatient
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string PatientGuid { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public string CancelFlag { get; set; }
    }
}
