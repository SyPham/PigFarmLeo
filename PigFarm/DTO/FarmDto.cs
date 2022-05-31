using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.DTO
{
    public partial class FarmDto
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public string FarmNo { get; set; }
        public string FarmName { get; set; }
        public string FarmPrincipal { get; set; }
        public decimal? FarmLength { get; set; }
        public decimal? FarmWidth { get; set; }
        public string FarmTel { get; set; }
        public string FarmAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string TemptureTopLimit { get; set; }
        public string TemptureLowLimit { get; set; }
        public decimal? FarmGgp { get; set; }
        public decimal? FarmGp { get; set; }
        public decimal? FarmPmpf { get; set; }
        public decimal? FarmSemen { get; set; }
        public decimal? FarmNursery { get; set; }
        public decimal? FarmGrower { get; set; }
        public string Comment { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public decimal? DeleteBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public partial class Farm2Dto
    {
        public decimal Id { get; set; }
        public string Guid { get; set; }
        public string FarmNo { get; set; }
        public string FarmName { get; set; }
    }
}
