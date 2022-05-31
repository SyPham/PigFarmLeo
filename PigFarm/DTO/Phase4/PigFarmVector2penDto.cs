using System;

namespace PigFarm.DTO
{
    public partial class PigFarmVector2penDto
    {
        public decimal Id { get; set; }
        public string PigHouseVectorMasterGuid { get; set; }
        public string PenGuid { get; set; }
    }
}