using System;

namespace PigFarm.DTO
{
    public class BomMoveDto
    {
        public int Id { get; set; }
        public string BomGuid { get; set; }
        public string MoveNo { get; set; }
        public string MoveName { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
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
    }
}
