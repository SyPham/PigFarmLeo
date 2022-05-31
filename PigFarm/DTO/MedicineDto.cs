using System;

namespace PigFarm.DTO
{
    public partial class MedicineDto
    {
        public decimal Id { get; set; }
        public string MedicineType { get; set; }
        public string MedicineNo { get; set; }
        public string MedicineName { get; set; }
        public string MedicineElement { get; set; }
        public string MedicineEffect { get; set; }
        public string MedicineSideEffect { get; set; }
        public string MedicineBreed { get; set; }
        public string MedicineRange { get; set; }
        public string MedicineCare { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string FarmGuid { get; set; }
        public string MedicineTypeName { get; set; }
         public DateTime? DeleteDate { get; set; }
        public decimal? DeleteBy { get; set; }
         public string VendorGuid { get; set; }
        public string Location { get; set; }
        public string Spec { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? ExpireDate { get; set; }
    public string LocationName { get; set; }

    }
}
