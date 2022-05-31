using System;
using System.Collections.Generic;

#nullable disable

namespace PigFarm.Models
{
    public partial class AccountPermission
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string CodeNo { get; set; }
        public string UpperGuid { get; set; }

        public virtual Account Account { get; set; }
    }
}
