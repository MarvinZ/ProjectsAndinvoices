﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO.Models
{
    public class Invoice : Audit

    {

        public int ID { get; set; }

        public decimal AmountDue { get; set; }

        public DateTime DueDate { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }

    }
}
