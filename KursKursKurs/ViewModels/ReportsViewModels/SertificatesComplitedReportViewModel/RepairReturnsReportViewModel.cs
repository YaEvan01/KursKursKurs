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
    class RepairReturnsReportViewModel : ViewModel
    {
        public ObservableCollection<RepairCertificate> RepairCertificates { get; set; } = new ObservableCollection<RepairCertificate>();

        private int spentOnRepairs;
        public int SpentOnRepairs
        {
            get => spentOnRepairs;
            set
            {
                spentOnRepairs = value;
                OnPropertyChanget();
            }
        }
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
        public RepairReturnsReportViewModel(Window window) : base(window)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<RepairCertificate> repairCertificates = 
                    db.RepairCertificates.
                    Include(rc => rc.Employee).
                    Include(rc => rc.Equipment).
                    ToList();
                repairCertificates.ForEach(rc => RepairCertificates.Add(rc));               
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
            RepairCertificates.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                List<RepairCertificate> repairCertificates =
                    db.RepairCertificates.
                    Include(rc => rc.Employee).
                    Include(rc => rc.Equipment).
                    ToList();
                repairCertificates.ForEach(rc => RepairCertificates.Add(rc));
                repairCertificates.ForEach(rc =>
                {
                    SpentOnRepairs += rc.RepairPrice;
                });
            }
        }
    }
}
