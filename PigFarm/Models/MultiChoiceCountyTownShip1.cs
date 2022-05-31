using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class MultiChoiceCountyTownShip1
    {
        public int Id { get; set; }
        public string UpperGuid { get; set; }
        public string AccountGuid { get; set; }
        public int AccountId { get; set; }
        public int CountryId { get; set; }
        public int TownShipId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
    }
}
