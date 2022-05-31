using PigFarm.Models.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigFarm.Models
{
    [Table("FoodCategories")]
    public class FeedCategory : AuditEntity
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
