using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class ViewModel : INotifyPropertyChanged
    {
        protected Window _thisWindow;
        public ViewModel(Window window)
        {
            _thisWindow = window;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanget([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }






        private RelayCommand _openEquepmentWindowCommand;
        private RelayCommand _openEmployeesWindowCommand;

        public RelayCommand OpenEquepmentWindowCommand
        {
            get
            {
                return _openEquepmentWindowCommand ??
                     (_openEquepmentWindowCommand = new RelayCommand(OpenEquepmentWindow));
            }
        }
        public RelayCommand OpenEmployeesWindowCommand
        {
            get
            {
                return _openEmployeesWindowCommand ??
                    (_openEmployeesWindowCommand = new RelayCommand(OpenEmployeesWindow));
            }
        }
        private void OpenEquepmentWindow(object data)
        {
            EquipmentWindow window = new EquipmentWindow();
            window.Show();
            _thisWindow.Close();
            
        }
        private void OpenEmployeesWindow(object data)
        {
            MainWindow window = new MainWindow();
            window.Show();
            _thisWindow.Close();
        }










        //<Open Certificates>
        private RelayCommand _openRenovationAcceptanceCertificatesWindowCommand;
        private RelayCommand _openRepairCertificatesWindowCommand;
        private RelayCommand _openScrappingCertificateWindowCommand;

        public RelayCommand OpenRenovationAcceptanceCertificatesWindowWindowCommand
        {
            get
            {
                return _openRenovationAcceptanceCertificatesWindowCommand ??
                     (_openRenovationAcceptanceCertificatesWindowCommand = new RelayCommand(OpenRenovationAcceptanceCertificatesWindow));
            }
        }
        public RelayCommand OpenRepairCertificatesWindowCommand
        {
            get
            {
                return _openRepairCertificatesWindowCommand ??
                     (_openRepairCertificatesWindowCommand = new RelayCommand(OpenRepairCertificatesWindow));
            }
        }
        public RelayCommand OpenScrappingCertificateWindowCommand
        {
            get
            {
                return _openScrappingCertificateWindowCommand ??
                     (_openScrappingCertificateWindowCommand = new RelayCommand(OpenScrappingCertificateWindow));
            }
        }

        private void OpenRenovationAcceptanceCertificatesWindow(object data)
        {
            RenovationAcceptanceCertificateWindow window = new RenovationAcceptanceCertificateWindow();
            window.Show();
            _thisWindow.Close();
        }
        private void OpenRepairCertificatesWindow(object data)
        {
            RepairCertificateWindow window = new RepairCertificateWindow();
            window.Show();
            _thisWindow.Close();
        }
        private void OpenScrappingCertificateWindow(object data)
        {
            ScrappingCertificateWindow window = new ScrappingCertificateWindow();
            window.Show();
            _thisWindow.Close();
        }
        //</Open Certificates>
















        //<Open Reports>
        private RelayCommand _openJunkTransferReportWindowCommand;
        private RelayCommand _openRepairsTransferReportsWindowCommand;
        private RelayCommand _openSertificatesCompletedReportsWindowCommand;


        public RelayCommand OpenJunkTransferReportWindowCommand
        {
            get
            {
                return _openJunkTransferReportWindowCommand ??
                    (_openJunkTransferReportWindowCommand = new RelayCommand(OpenJunkTransferReportWindow));
            }
        }
        public RelayCommand OpenRepairsTransferReportsWindowCommand
        {
            get
            {
                return _openRepairsTransferReportsWindowCommand ??
                    (_openRepairsTransferReportsWindowCommand = new RelayCommand(OpenRepairsTransferReportsWindow));
            }
        }
        public RelayCommand OpenSertificatesCompletedReportsWindowCommand
        {
            get
            {
                return _openSertificatesCompletedReportsWindowCommand ??
                    (_openSertificatesCompletedReportsWindowCommand = new RelayCommand(OpenSertificatesCompletedReportsWindow));
            }
        }
        private void OpenJunkTransferReportWindow(object data)
        {
            JunkTransferReportWindow window = new JunkTransferReportWindow();
            window.Show();
            _thisWindow.Close();
        }
        private void OpenRepairsTransferReportsWindow(object data)
        {
            RepairsTransferReportWindow window = new RepairsTransferReportWindow();
            window.Show();
            _thisWindow.Close();
        }
        private void OpenSertificatesCompletedReportsWindow(object data)
        {
            RepairReturnsReportWindow window = new RepairReturnsReportWindow();
            window.Show();
            _thisWindow.Close();
        }
        //</Open Reports>





        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return _closeCommand ??
                    (_closeCommand = new RelayCommand(Close));
            }
        }
        private void Close(object data)
        {
            _thisWindow.DialogResult = true;
        }
    }
}
