using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class PublicCountyTownShip
    {
        public int Id { get; set; }
        public string CountryId { get; set; }
        public string TownShip { get; set; }
        public string UpperGuid { get; set; }
        public string CancelFlag { get; set; }
        public string Guid { get; set; }
    }
}
