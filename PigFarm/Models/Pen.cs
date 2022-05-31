using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Pen
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string AreaGuid { get; set; }
        public string BarnGuid { get; set; }
        public string RoomGuid { get; set; }
        public string Type { get; set; }
        public string PenNo { get; set; }
        public string PenName { get; set; }
        public string PenPrincipal { get; set; }
        public string PenLength { get; set; }
        public decimal? PenWidth { get; set; }
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
