using System;
using System.Collections.Generic;

namespace PigFarm.DTO
{
    public  class MakeOrderDto
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
        public string PigType { get; set; }
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
        public string OrderBreedName { get; set; }
        public double? DayAge {set; get;}
        public string BomGuid { get; set; }
        public object CurrentAmount { get; set; }
        public object PenName { get; set; }
        public object RoomName { get; set; }
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
    public partial class RemoveMakeOrder2PenDto
    {
        public string Guid { get; set; }

        public string PenGuid { get; set; }

    }
     public partial class AddMakeOrder2PenDto
    {
        public string Guid { get; set; }

        public string PenGuid { get; set; }

    }

    public partial class StoreMakeOrder2PenDto
    {
        public string Guid { get; set; }

        public List<string> Pens { get; set; }

    }
    public partial class UpdateRoomGuidDto
    {
        public string Guid { get; set; }
        public string RoomGuid { get; set; }


    }
    public  class MakeOrderMobileDto
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
        public string PigType { get; set; }
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
        public string OrderBreedName { get; set; }
        public double? DayAge {set; get;}
        public string BomGuid { get; set; }
        public object CurrentAmount { get; set; }
        public object PenName { get; set; }
        public object RoomName { get; set; }
        public object RecordFeeding { get; set; }
        public object RecordImmunization { get; set; }
        public object RecordWeighing { get; set; }
        public object RecordMove { get; set; }
        public object RecordCulling { get; set; }
        public object RecordDeath { get; set; }
        public object RecordPigEar { get; set; }
        public object RecordTreatment { get; set; }
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