﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class PublicMemo
    {
        public int Id { get; set; }
        public string UpperGuid { get; set; }
        public string MemoProject { get; set; }
        public string Memo { get; set; }
        public int? MemoYearsStart { get; set; }
        public int? MemoYearsEnd { get; set; }
        public DateTime? MemoDate { get; set; }
        public string PaymentCode { get; set; }
        public int AccountId { get; set; }
        public string Guid { get; set; }
        public string CancelFlag { get; set; }
        public bool TempFlag { get; set; }
        public bool? Status { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
