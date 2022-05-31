using System;

namespace PigFarm.DTO
{
    public class DailyFeedingDto
    {
        public int ID { get; set; }
        public double Unit { get; set; }
        public string Name { get; set; }
        public int FoodID { get; set; }
        public string Food { get; set; }

        public bool? Status { get; set; }

        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public int? DeleteBy { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
