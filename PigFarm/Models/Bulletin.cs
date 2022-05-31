using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Bulletin
    {
        public decimal Id { get; set; }
        public decimal? OrganizationId { get; set; }
        public decimal? SiteId { get; set; }
        public decimal? TypeId { get; set; }
        public decimal? SortId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public DateTime? BulletinDate { get; set; }
        public string Language { get; set; }
        public decimal? WebSiteId { get; set; }
        public string Link { get; set; }
        public string AlwaysTop { get; set; }
    }
}
