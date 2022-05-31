using System;
namespace PigFarm.DTO
{
    public class PigGeneticDto
    {
        public decimal Id { get; set; }
        public string GeneticAa { get; set; }
        public string GeneticGg { get; set; }
        public string GeneticGg2 { get; set; }
        public string GeneticHmga1 { get; set; }
        public string GeneticHmga2 { get; set; }
        public string GeneticCckar1 { get; set; }
        public string GeneticCckar2 { get; set; }
        public string GeneticCckar3 { get; set; }
        public string GeneticCckar4 { get; set; }
        public string GeneticCast { get; set; }
        public string GeneticHal { get; set; }
        public string GeneticRn { get; set; }
        public string GeneticEsr { get; set; }
        public string GeneticEpor { get; set; }
        public string PedigreeGuid { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
    }
}