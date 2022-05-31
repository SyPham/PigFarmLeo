using System;

namespace PigFarm.DTO
{
    public partial class InventoryChangeDto
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string ChangeGuid { get; set; }
        public string ThingGuid { get; set; }
        public string MaterialGuid { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string ChangeTime { get; set; }
        public string FromInventoryGuid { get; set; }
        public string ToInventoryGuid { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }

        public string Thing { get; set; }
        public string Material { get; set; }
        public string ToInventory { get; set; }
        public string Type { get; set; }
        public string InventoryType { get; set; }
        public string InventoryGuid { get; set; }
        public decimal? InventoryAmount { get; set; }
        public decimal? OriginalAmount { get; set; }


    }
}
