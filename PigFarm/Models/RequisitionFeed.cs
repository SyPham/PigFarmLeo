﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PigFarm.Models
{
    public partial class RequisitionFeed
    {
        public decimal Id { get; set; }
        public string RequisitionGuid { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
    }
}