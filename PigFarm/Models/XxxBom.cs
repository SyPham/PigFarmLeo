using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class XxxBom
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int PigKindId { get; set; }
        public int? VaccineId { get; set; }
        public int FeedingId { get; set; }
        public bool? Status { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? MethodId { get; set; }
        public double DailyFeeding { get; set; }
        public double FromDaysOld { get; set; }
        public double ToDaysOld { get; set; }

        public virtual Feeding Feeding { get; set; }
        public virtual Food Food { get; set; }
        public virtual Method Method { get; set; }
        public virtual PigKind PigKind { get; set; }
        public virtual Vaccine Vaccine { get; set; }
    }
}
