using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class MakeOrder
    {
        public decimal Id { get; set; }
        public string FarmGuid { get; set; }
        public string CustomerGuid { get; set; }
        public string OrderNo { get; set; }
        public string OrderName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? EstimateStartDate { get; set; }
        public DateTime? EstimateEndDate { get; set; }
        public DateTime? RealStartDate { get; set; }
        public DateTime? RealEndDate { get; set; }
        public string OrderBreed { get; set; }
        public decimal? OrderAmound { get; set; }
        public string OrderType { get; set; }
        public string OrderFarm { get; set; }
        public decimal? OrderPrice { get; set; }
        public string Comment { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public decimal? DeleteBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string PigType { get; set; }
        public string BomGuid { get; set; }
        public string RoomGuid { get; set; }
        public decimal? InAmound { get; set; }
        public decimal? CurrentAmound { get; set; }
        public decimal? CullingAmound { get; set; }
        public decimal? DeathAmound { get; set; }
        public decimal? SaleAmound { get; set; }
        public decimal? DonateAmound { get; set; }
        public DateTime? CloseDate { get; set; }
        public string CloseReason { get; set; }
        public string CloseGuid { get; set; }
        public DateTime? AgreeDate { get; set; }
        public string AgreeReason { get; set; }
        public string AgreeGuid { get; set; }
    }
}
