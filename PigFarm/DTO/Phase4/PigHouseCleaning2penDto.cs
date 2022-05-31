using System;

namespace PigFarm.DTO
{
    public partial class PigHouseCleaning2penDto
    {
        public decimal Id { get; set; }
        public string PigHouseCleaningMasterGuid { get; set; }
        public string PenGuid { get; set; }
    }
}