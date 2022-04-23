﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CriminalCodeDTO
    {
        public IQueryable<CriminalCode> CriminalCodes { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
