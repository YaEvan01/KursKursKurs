using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class SelectRepairCertificateViewModel:ViewModel
    {
        private RepairCertificate selectedRepairCertificate;
        public RepairCertificate SelectedRepairCertificate
        {
            get => selectedRepairCertificate;
            set
            {
                selectedRepairCertificate = value;
                OnPropertyChanget();
            }
        }

        public List<RepairCertificate> RepairCertificates { get; set; }
        public SelectRepairCertificateViewModel(Window window) : base(window) 
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                RepairCertificates = 
                    db.RepairCertificates.
                    Include(rc => rc.Employee).
                    Include(rc => rc.Equipment).
                    ToList();
            }
        }

 
    }
}
