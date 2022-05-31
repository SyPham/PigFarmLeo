using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class MultiChoiceCountyTownShip
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string CountyId { get; set; }
        public string TownShipId { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
    }
}
