﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class DbPublicMemo
    {
        public decimal Id { get; set; }
        public string UpperGuid { get; set; }
        public string MemoProject { get; set; }
        public decimal? MemoYearsStart { get; set; }
        public decimal? MemoYearsEnd { get; set; }
        public DateTime? MemoDate { get; set; }
        public string Memo { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public string Guid { get; set; }
        public string TempFlag { get; set; }
    }
}
