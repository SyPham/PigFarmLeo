using PigFarm.Models.Abstracts;
using PigFarm.Models.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigFarm.Models
{

    [Table("Plans")]
    public class Plan : AuditEntity
    {
        [Key]
        public int ID { get; set; }
     
      
      
    }
}
