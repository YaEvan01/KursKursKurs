using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class JunkTransferReportViewModel:ViewModel
    {
        public ObservableCollection<ScrappingCertificate> ScrappingCertificates { get; set; } = new ObservableCollection<ScrappingCertificate>();

        private DateTime begining;
        public DateTime Begining
        {
            get => begining;
            set
            {
                begining = value;
                OnPropertyChanget();
            }
        }

        private DateTime end;
        public DateTime End
        {
            get => end;
            set
            {
                end = value;
                OnPropertyChanget();
            }
        }
        private int totalLosses;
        public int TotalLosses
        {
            get => totalLosses;
            set
            {
                totalLosses = value;
                OnPropertyChanget();
            }
        }
        public JunkTransferReportViewModel(Window window) : base(window) 
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<ScrappingCertificate> scrappingCertificates = db.ScrappingCertificates.Include(sc => sc.Employee).Include(sc => sc.Equipment).ToList();
                scrappingCertificates.ForEach(sc => ScrappingCertificates.Add(sc));
            }
        }

        private RelayCommand _updateCommand;
        public RelayCommand myUpdateCommand
        {
            get
            {
                return _updateCommand ??
                    (_updateCommand = new RelayCommand(Update));
            }
        }
        private void Update(object data)
        {
            ScrappingCertificates.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {                
                List<ScrappingCertificate> scrappingCertificates =
                    db.ScrappingCertificates.
                    Include(sc => sc.Employee).
                    Include(sc => sc.Equipment).
                    Where(sc=>sc.DateOfPreparation>=Begining && sc.DateOfPreparation<=End).
                    ToList();
                scrappingCertificates.ForEach(sc => ScrappingCertificates.Add(sc));
                scrappingCertificates.ForEach(sc =>
                {
                    TotalLosses += sc.Equipment.Price + sc.Equipment.SpentOfRepair;
                });
            }
        }
    }
}
