﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursKursKurs
{
    public class Certificate
    {
        public int Id { get; set; }
        public DateTime DateOfPreparation { get; set; }


        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

    }
}
