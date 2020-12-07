using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursKursKurs
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Passport { get; set; }
        public int Form { get; set; }
        public int SpentOfRepair { get; set; }
        public int Price { get; set; }
        public DateTime LastRenovation { get; set; }
    }
}
