using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class AccountGroup
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public int BuildingId { get; set; }
        public string GroupNo { get; set; }
        public string GroupName { get; set; }
        public bool? Status { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
