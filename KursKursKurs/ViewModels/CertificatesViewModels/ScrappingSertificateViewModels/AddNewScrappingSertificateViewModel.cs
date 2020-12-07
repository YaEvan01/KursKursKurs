using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class AddNewScrappingSertificateViewModel:ViewModel
    {
        private Employee employee;
        public Employee Employee
        {
            get=> employee;
            set
            {
                employee = value;
                OnPropertyChanget();
            }
        }
        private RepairCertificate repairCertificate;
        public RepairCertificate RepairCertificate
        {
            get => repairCertificate;
            set
            {
                repairCertificate = value;
                OnPropertyChanget();
            }
        }
        public AddNewScrappingSertificateViewModel(Window window) : base(window) { }

        private RelayCommand _addScrappingCertificateCommand;
        public RelayCommand AddScrappingCertificateCommand
        {
            get
            {
                return _addScrappingCertificateCommand ??
                    (_addScrappingCertificateCommand = new RelayCommand(AddScrappingCertificate));
            }
        }
        private void AddScrappingCertificate(object data)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.ScrappingCertificates.Add(new ScrappingCertificate
                {
                    DateOfPreparation = DateTime.Now,
                    EmployeeId = Employee.Id,
                    EquipmentId = RepairCertificate.EquipmentId,
                    RerairCertificateId= RepairCertificate.Id
                });
                db.SaveChanges();
            }
            _thisWindow.DialogResult = true;
        }

        private RelayCommand _selectEmployeeCommand;
        public RelayCommand SelectEmployeeCommand
        {
            get
            {
                return _selectEmployeeCommand ??
                    (_selectEmployeeCommand = new RelayCommand(SelectEmployee));
            }
        }
        private void SelectEmployee(object data)
        {
            SelectEmployeeWindow selectEmployeeWindow = new SelectEmployeeWindow();
            if (selectEmployeeWindow.ShowDialog() == true)
            {
                Employee = selectEmployeeWindow.Context.SelectedEmployee;
            }
        }

        private RelayCommand _selectRepairSertificateCommand;
        public RelayCommand SelectRepairSertificateCommand
        {
            get
            {
                return _selectRepairSertificateCommand ??
                    (_selectRepairSertificateCommand = new RelayCommand(SelectRepairSertificate));
            }
        }
        private void SelectRepairSertificate(object data)
        {
            SelectRepairSertificateWindow selectRepairSertificateWindow = new SelectRepairSertificateWindow();
            if (selectRepairSertificateWindow.ShowDialog() == true)
            {
                RepairCertificate = selectRepairSertificateWindow.Context.SelectedRepairCertificate;
            }
        }
    }
}
