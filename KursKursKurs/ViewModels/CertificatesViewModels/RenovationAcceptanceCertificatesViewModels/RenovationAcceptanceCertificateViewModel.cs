using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class RenovationAcceptanceCertificateViewModel:ViewModel
    {
        public List<RenovationAcceptanceCertificate> RenovationAcceptanceCertificates { get; set; }
        public RenovationAcceptanceCertificateViewModel(Window window): base(window) 
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
            AddNewRenovationAcceptanceCertificate addCertificate = new AddNewRenovationAcceptanceCertificate();
            if (addCertificate.ShowDialog() == true)
            {
                CertificateInitialization();
            }
        }

        private void CertificateInitialization()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                RenovationAcceptanceCertificates =
                    db.RenovationAcceptanceCertificates.
                    Include(rac => rac.Employee).
                    Include(rac => rac.Equipment).
                    ToList();
            }
        }
    }
}
