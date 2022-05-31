using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Bom
    {
        public int Id { get; set; }
        public string BomNo { get; set; }
        public string BomName { get; set; }
        public string BomVersion { get; set; }
        public string BomBreed { get; set; }
        public string BomType { get; set; }
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
