using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Room
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string AreaGuid { get; set; }
        public string BarnGuid { get; set; }
        public string Type { get; set; }
        public string RoomNo { get; set; }
        public string RoomName { get; set; }
        public string RoomPrincipal { get; set; }
        public decimal? RoomLength { get; set; }
        public decimal? RoomWidth { get; set; }
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
