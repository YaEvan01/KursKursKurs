using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class RepairCertificateViewModel:ViewModel
    {
        public List<RepairCertificate> RepairCertificates { get; set; }
        public RepairCertificateViewModel(Window window) : base(window) 
        {
            CertificateInitialization();
        }

        private RelayCommand _addNewCertificateCommand;

        public RelayCommand AddNewCertificateCommand
        {
            get
            {
                return _addNewCertificateCommand ??
                    (_addNewCertificateCommand = new RelayCommand(AddNewCertificate));
            }
        }       
        private void AddNewCertificate(object data)
        {
            AddNewRepairCertificateWindow addCertificate = new AddNewRepairCertificateWindow();
            if (addCertificate.ShowDialog() == true)
            {
                CertificateInitialization();
            }
        }

        private void CertificateInitialization()
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
