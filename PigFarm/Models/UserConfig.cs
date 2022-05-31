﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class UserConfig
    {
        public decimal Id { get; set; }
        public string ConfigType { get; set; }
        public decimal? ConfigNo { get; set; }
        public string ConfigValue { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Sort { get; set; }
        public decimal? OrganizationId { get; set; }
        public decimal? SiteId { get; set; }
    }
}
