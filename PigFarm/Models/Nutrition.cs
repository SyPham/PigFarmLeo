using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Nutrition
    {
        public decimal Id { get; set; }
        public string NutritionType { get; set; }
        public string NutritionNo { get; set; }
        public string NutritionName { get; set; }
        public string NutritionElement { get; set; }
        public string NutritionEffect { get; set; }
        public string NutritionSideEffect { get; set; }
        public string NutritionBreed { get; set; }
        public string NutritionRange { get; set; }
        public string NutritionCare { get; set; }
        public string Comment { get; set; }
        public string CancelFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? UpdateBy { get; set; }
        public decimal? Status { get; set; }
        public string Guid { get; set; }
        public string FarmGuid { get; set; }
    }
}
