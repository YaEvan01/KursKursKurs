using System;
using System.Linq;
using System.Windows;

namespace KursKursKurs
{
    public class AddNewRenovationAcceptanceCertificateViewModel:ViewModel
    {
        private string comment;
        public string Comment
        {
            get => comment;
            set
            {
                comment = value;
                OnPropertyChanget();
            }
        }
        private Employee employee;
        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;
                OnPropertyChanget();
            }
        }

        private Equipment equipment;
        public Equipment Equipment
        {
            get => equipment;
            set
            {
                equipment = value;
                OnPropertyChanget();
            }
        }
        public AddNewRenovationAcceptanceCertificateViewModel(Window window) : base(window) { }

        private RelayCommand _addNewRenovationAcceptanceCertificateCommand;
        public RelayCommand AddNewRenovationAcceptanceCertificateCommand
        {
            get
            {
                return _addNewRenovationAcceptanceCertificateCommand ??
                    (_addNewRenovationAcceptanceCertificateCommand = new RelayCommand(AddNewRenovationAcceptanceCertificate));
            }
        }
        private void AddNewRenovationAcceptanceCertificate(object data)
        {
            using(ApplicationContext db=new ApplicationContext())
            {
                db.RenovationAcceptanceCertificates.Add(new RenovationAcceptanceCertificate
                {
                    DateOfPreparation = DateTime.Now,
                    EmployeeId = Employee.Id,
                    EquipmentId = Equipment.Id,
                    Comment = this.Comment
                });
                db.SaveChanges();
                db.Equipment.FirstOrDefault(e => e.Id == this.Equipment.Id).LastRenovation = DateTime.Now;
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


        private RelayCommand _selectEquipmentCommand;
        public RelayCommand SelectEquipmentCommand
        {
            get
            {
                return _selectEquipmentCommand ??
                    (_selectEquipmentCommand = new RelayCommand(SelectEquipment));
            }
        }
        private void SelectEquipment(object data)
        {
            SelectEquipmentWindow selectEquipmentWindow = new SelectEquipmentWindow();
            if (selectEquipmentWindow.ShowDialog() == true)
            {
                Equipment = selectEquipmentWindow.Context.SelectedEquipment;
            }
        }

    }
}
