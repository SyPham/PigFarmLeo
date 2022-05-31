using System;

namespace PigFarm.DTO
{
    public partial class SalesOrderDto
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public DateTime? SalesOrderDate { get; set; }
        public string SalesOrderTime { get; set; }
        public string SalesOrderNo { get; set; }
        public string SalesOrderName { get; set; }
        public string SalesOrderComment { get; set; }
        public string CustomerGuid { get; set; }
        public string AccountGuid { get; set; }
        public DateTime? RejectDate { get; set; }
        public string RejectReason { get; set; }
        public string RejectGuid { get; set; }
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