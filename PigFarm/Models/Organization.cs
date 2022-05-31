﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Organization
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public string OrganizationNo { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationPrincipal { get; set; }
        public string OrganizationTel { get; set; }
        public string OrganizationMobile { get; set; }
        public string OrganizationAddress { get; set; }
        public string OrganizationEmail { get; set; }
        public string OrganizationUrl { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
    }
}
