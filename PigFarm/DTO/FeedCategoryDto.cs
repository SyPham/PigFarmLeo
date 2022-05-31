using PigFarm.Models.Interface;
using System;

namespace PigFarm.DTO
{
    public class FeedCategoryDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreatedTime { get ; set ; }
        public DateTime? ModifiedTime { get ; set ; }
    }
}
