﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class WebMenu
    {
        public decimal Id { get; set; }
        public int? WebSiteId { get; set; }
        public decimal? SortId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string MenuName { get; set; }
        public string MenuNameEn { get; set; }
        public string MenuNameVn { get; set; }
        public string MenuLink { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public decimal? UpperId { get; set; }
        public string MenuLinkEn { get; set; }
        public string MenuIcon { get; set; }
        public string MenuIcon1 { get; set; }
        public string WebPageGuid { get; set; }
        public string WebPageGuidEn { get; set; }
        public string InFooter { get; set; }
        public string InHeader { get; set; }
    }
}
