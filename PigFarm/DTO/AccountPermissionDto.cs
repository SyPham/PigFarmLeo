﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PigFarm.DTO
{
    public class AccountPermissionDto
    {
        public int ID { get; set; }
        public string UpperGuid { get; set; }
        public int? AccountID { get; set; }
        public string CodeNO { get; set; }
    }
}
