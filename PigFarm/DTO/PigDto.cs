using System;
namespace PigFarm.DTO
{
    public class PigDto
    {
        public decimal Id { get; set; }
        public string PigType { get; set; }
        public string Phase { get; set; }
        public decimal? Outsourcing { get; set; }
        public string FarmGuid { get; set; }
        public string AreaGuid { get; set; }
        public string BarnGuid { get; set; }
        public string RoomGuid { get; set; }
        public string PenGuid { get; set; }
        public string CullingTankGuid { get; set; }
        public string FatherGuid { get; set; }
        public string MotherGuid { get; set; }
        public string Idno { get; set; }
        public string EarNo { get; set; }
        public string EarTag { get; set; }
        public string Rfidtag { get; set; }
        public DateTime? Birthday { get; set; }
        public decimal? DayAge { get; set; }
        public decimal? Sex { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? WeightDate { get; set; }
        public decimal? WeightDayAge { get; set; }
        public string Breed { get; set; }
        public decimal? BirthPenGuid { get; set; }
        public decimal? EnterOrigin { get; set; }
        public DateTime? EnterDate { get; set; }
        public decimal? EnterDept { get; set; }
        public decimal? TransferMoney { get; set; }
        public DateTime? TransferDate { get; set; }
        public decimal? TransferFrom { get; set; }
        public decimal? FarrowStatus { get; set; }
        public string FarrowComment { get; set; }
        public DateTime? SuckingCheckInDate { get; set; }
        public decimal? SuckingCheckInStatus { get; set; }
        public DateTime? SuckingCheckOutDate { get; set; }
        public decimal? SuckingCheckOutStatus { get; set; }
        public DateTime? GrowerCheckInDate { get; set; }
        public decimal? GrowerCheckInStatus { get; set; }
        public DateTime? GrowerCheckOutDate { get; set; }
        public decimal? GrowerCheckOutStatus { get; set; }
        public DateTime? FinisherCheckInDate { get; set; }
        public decimal? FinisherCheckInStatus { get; set; }
        public DateTime? FinisherCheckOutDate { get; set; }
        public decimal? FinisherCheckOutStatus { get; set; }
         public DateTime? NurseryCheckInDate { get; set; }
        public decimal? NurseryCheckInStatus { get; set; }
        public DateTime? NurseryCheckOutDate { get; set; }
        public decimal? NurseryCheckOutStatus { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string MakeOrderGuid { get; set; }
        public string PigTypeName { get; set; }
        public string SexName { get; set; }
        public decimal? Sequence { get; set; }
        public string PhaseName { get; set; }
    }
    public class PigDrodownlistDto {
  public string Name { get; set; }
        public decimal Id { get; set; }
        public string Guid { get; set; }
    }
    public class MultiplePigParams {
        public string[] pens { get; set; }
        public string RoomGuid { get; set; }
        public string FarmGuid { get; set; }

    }
      public class SelectedPigParams {
        public string[] Pigs { get; set; }
        public string RecordGuid { get; set; }
        public string Type { get; set; }

    }
}
