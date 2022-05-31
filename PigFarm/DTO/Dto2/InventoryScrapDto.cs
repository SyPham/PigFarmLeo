﻿using System;

namespace PigFarm.DTO
{
    public partial class InventoryScrapDto
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string ScrapGuid { get; set; }
        public DateTime? ScrapDate { get; set; }
        public string ScrapTime { get; set; }
        public string FromInventoryGuid { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string Type { get; set; }
        public string InventoryType { get; set; }
        public string InventoryGuid { get; set; }
        public decimal? InventoryAmount { get; set; }
        public decimal? OriginalAmount { get; set; }

    }
}