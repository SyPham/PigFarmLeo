﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PigFarm.Models
{
    public partial class InventoryChange
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
        public string Type { get; set; }
        public string InventoryType { get; set; }
        public string InventoryGuid { get; set; }
        public decimal? InventoryAmount { get; set; }
        public decimal? OriginalAmount { get; set; }
    }
}