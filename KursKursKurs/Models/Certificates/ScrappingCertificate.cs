using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursKursKurs
{
    public class ScrappingCertificate:Certificate
    {        
        public int RerairCertificateId { get; set; }
        public RepairCertificate RepairCertificate { get; set; }
        //public List<JunkTransferReport> JunkTransferReports { get; set; }
    }
}
