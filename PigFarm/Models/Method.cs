using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class Method
    {
        public Method()
        {
            XxxBoms = new HashSet<XxxBom>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual ICollection<XxxBom> XxxBoms { get; set; }
    }
}
