using PigFarm.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigFarm.Models
{
    [Table("DailyFeeding")]
    public class DailyFeeding : AuditEntity
    {
        [Key]
        public int ID { get; set; }
        public double Unit { get; set; }
        public string Name { get; set; }
        public int FoodID { get; set; }
        public virtual Food Food { get; set; }
    }
}
