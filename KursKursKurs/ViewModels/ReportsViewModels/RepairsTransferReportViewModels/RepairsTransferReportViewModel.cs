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
    class RepairsTransferReportViewModel : ViewModel
    {
        public ObservableCollection<RenovationAcceptanceCertificate> RenovationAcceptanceCertificates { get; set; } = new ObservableCollection<RenovationAcceptanceCertificate>();

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
        private int totalTransferredForRepair;
        public int TotalTransferredForRepair
        {
            get => totalTransferredForRepair;
            set
            {
                totalTransferredForRepair = value;
                OnPropertyChanget();
            }
        }
        public RepairsTransferReportViewModel(Window window) : base(window)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<RenovationAcceptanceCertificate> renovationAcceptanceCertificates =
                    db.RenovationAcceptanceCertificates.
                    Include(sc => sc.Employee).
                    Include(sc => sc.Equipment).
                    Where(sc => sc.DateOfPreparation >= Begining && sc.DateOfPreparation <= End).
                    ToList();
                renovationAcceptanceCertificates.ForEach(sc => RenovationAcceptanceCertificates.Add(sc));
                TotalTransferredForRepair = renovationAcceptanceCertificates.Count();
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
            RenovationAcceptanceCertificates.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                List<RenovationAcceptanceCertificate> renovationAcceptanceCertificates =
                    db.RenovationAcceptanceCertificates.
                    Include(sc => sc.Employee).
                    Include(sc => sc.Equipment).
                    Where(sc => sc.DateOfPreparation >= Begining && sc.DateOfPreparation <= End).
                    ToList();
                renovationAcceptanceCertificates.ForEach(sc => RenovationAcceptanceCertificates.Add(sc));
                TotalTransferredForRepair = renovationAcceptanceCertificates.Count();
            }
        }
    }
}
