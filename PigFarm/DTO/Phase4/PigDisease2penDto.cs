using System;

namespace PigFarm.DTO
{
    public partial class PigDisease2penDto
    {
        public decimal Id { get; set; }
        public string PigDiseaseMasterGuid { get; set; }
        public string PenGuid { get; set; }
    }
}