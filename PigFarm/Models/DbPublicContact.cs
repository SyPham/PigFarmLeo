﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class DbPublicContact
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string ContactNo { get; set; }
        public string ContactName { get; set; }
        public string ContactNameEn { get; set; }
        public string ContactDepartment { get; set; }
        public string ContactJobTitle { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMobile { get; set; }
        public string ContactTel { get; set; }
        public string ContactFax { get; set; }
        public string Memo { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public string Guid { get; set; }
    }
}
