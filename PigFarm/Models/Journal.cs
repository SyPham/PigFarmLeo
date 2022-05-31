using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Journal
    {
        public decimal Id { get; set; }
        public decimal? OrganizationId { get; set; }
        public decimal? SiteId { get; set; }
        public string UpperGuid { get; set; }
        public string AccountGuid { get; set; }
        public string NurseGuid { get; set; }
        public string PatientGuid { get; set; }
        public decimal? JournalYear { get; set; }
        public decimal? JournalMonth { get; set; }
        public decimal? JournalDay { get; set; }
        public DateTime? JournalDate { get; set; }
        public string JournalSubject { get; set; }
        public string JournalBody { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public string CancelFlag { get; set; }
        public string Guid { get; set; }
        public string TempFlag { get; set; }
        public decimal? Temperature { get; set; }
        public string TemperatureTime { get; set; }
        public decimal? Temperature1 { get; set; }
        public string Temperature1Time { get; set; }
        public decimal? Temperature2 { get; set; }
        public string Temperature2Time { get; set; }
        public decimal? Temperature3 { get; set; }
        public string Temperature3Time { get; set; }
    }
}
