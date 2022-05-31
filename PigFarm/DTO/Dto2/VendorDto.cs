﻿using System;

namespace PigFarm.DTO
{
    public partial class VendorDto
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string VendorNo { get; set; }
        public string VendorName { get; set; }
        public string VendorSex { get; set; }
        public DateTime? VendorBirthday { get; set; }
        public string VendorNickname { get; set; }
        public string VendorTel { get; set; }
        public string VendorMobile { get; set; }
        public string VendorAddress { get; set; }
        public string VendorIdcard { get; set; }
        public string VendorEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string VendorSexName { get; set; }
    }
}