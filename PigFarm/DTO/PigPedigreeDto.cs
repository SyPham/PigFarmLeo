
using System;
namespace PigFarm.DTO
{
    public class PigPedigreeDto
    {
        public decimal Id { get; set; }
        public string FatherGuid { get; set; }
        public string MotherGuid { get; set; }
        public DateTime? BirthDay { get; set; }
        public string PedigreeName { get; set; }
        public string FromPigFarm { get; set; }
        public string Breed { get; set; }
        public string EarNo { get; set; }
        public string EarTag { get; set; }
        public string Rfid { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string FarmGuid { get; set; }

    }
}