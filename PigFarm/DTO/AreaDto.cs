using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.DTO
{
    public partial class AreaDto
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string Type { get; set; }
        public string AreaNo { get; set; }
        public string AreaName { get; set; }
        public string AreaPrincipal { get; set; }
        public decimal? AreaLength { get; set; }
        public decimal? AreaWidth { get; set; }
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
}
