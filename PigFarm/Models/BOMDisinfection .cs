using PigFarm.Models.Abstracts;
using PigFarm.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace PigFarm.Models
{
    public class BOMDisinfection : AuditEntity
    {
        [Key]
        public int ID { get; set; }
        public string BOMGuid { get; set; }
        public string DisinfectionBrand { get; set; }
        public string DisinfectionName { get; set; }
        public string DisinfectionMethod { get; set; }
        public string DisinfectionMedicine { get; set; }
        public string DisinfectionCare { get; set; }

        public string MethodType { get; set; }
        public decimal MethodFreq { get; set; }
        public decimal MethodUseTime { get; set; }
        public decimal MethodAmount { get; set; }

        public string Guid { get; set; }
        public string CancelFlag { get; set; }
        public string Comment { get; set; }
    }
}

