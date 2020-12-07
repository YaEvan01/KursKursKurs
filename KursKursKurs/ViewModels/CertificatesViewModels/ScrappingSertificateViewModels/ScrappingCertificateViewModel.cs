using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class ScrappingCertificateViewModel:ViewModel
    {
        public List<ScrappingCertificate> ScrappingCertificates { get; set; }
        public ScrappingCertificateViewModel(Window window) : base(window) 
        {
            CertificateInitialization();
        }

        private RelayCommand _addCertificateCommand;

        public RelayCommand AddCertificateCommand
        {
            get
            {
                return _addCertificateCommand ??
                    (_addCertificateCommand = new RelayCommand(AddCertificate));
            }
        }
        private void AddCertificate(object data)
        {
            AddNewScrappingCertificate addScrappingCertificate = new AddNewScrappingCertificate();
            if (addScrappingCertificate.ShowDialog() == true)
            {
                CertificateInitialization();
            }
        }

        private void CertificateInitialization()
        {
            using(ApplicationContext db= new ApplicationContext())
            {
                ScrappingCertificates = 
                    db.ScrappingCertificates.
                    Include(sc => sc.Employee).
                    Include(sc => sc.Equipment).
                    ToList();
            }
        }
    }
}
