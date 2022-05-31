using System;

namespace PigFarm.DTO
{
    public partial class SalesOrderDetailDto
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string SalesOrderGuid { get; set; }
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
        public string LocationName { get; set; }
        
    }
}