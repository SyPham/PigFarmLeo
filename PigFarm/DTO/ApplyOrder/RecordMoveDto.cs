using System;

namespace PigFarm.DTO
{
    public partial class RecordMoveDto
    {
        public int Id { get; set; }
        public string FarmGuid { get; set; }
        public string Type { get; set; }
        public string MakeOrderGuid { get; set; }
        public string UpperGuid { get; set; }
        public string UpperRecord { get; set; }
        public string RoomGuid { get; set; }
        public string PenGuid { get; set; }
        public string Comment { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public decimal? DeleteBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public DateTime? EstDate { get; set; }
        public DateTime? ApplyDate { get; set; }
        public string ApplyReason { get; set; }
        public string ApplyGuid { get; set; }
        public DateTime? AgreeDate { get; set; }
        public string AgreeReason { get; set; }
        public string AgreeGuid { get; set; }
        public DateTime? RejectDate { get; set; }
        public string RejectReason { get; set; }
        public string RejectGuid { get; set; }
        public DateTime? ExecuteDate { get; set; }
        public string ExecuteReason { get; set; }
        public string ExecuteGuid { get; set; }
        public string BeforePenGuid { get; set; }
        public string AfterPenGuid { get; set; }
        public string PigStatus { get; set; }
        public string MoveType { get; set; }
        public string MoveInOut { get; set; }
        public string ApplyDays { get; set; }

        public string BeforePenName { get; set; }
        public string AfterPenName { get; set; }
        public string MoveInOutName { get; set; }
        public string ApplyDaysName { get; set; }
        public string PigStatusName { get; set; }
        public string MoveTypeName { get; set; }
        public string TypeName { get; set; }
        public string DelayReason { get; set; }

        public decimal? DelayDays { get; set; }
        public string[] Pigs { get; set; }
        public string StatusName { get; set; }

        public string[] Pens { get; set; }

        public string ApplyName { get; set; }
        public string AgreeName { get; set; }
        public string RejectName { get; set; }
public string ExecuteName { get; set; }
public string RoomName { get; set; }
public string OrderNo { get; set; }
    }
}