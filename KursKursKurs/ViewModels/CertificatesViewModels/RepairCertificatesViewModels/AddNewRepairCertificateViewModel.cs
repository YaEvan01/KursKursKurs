using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class AddNewRepairCertificateViewModel:ViewModel
    {

        private int repairPrice;
        public int RepairPrice
        {
            get => repairPrice;
            set
            {
                repairPrice = value;
                OnPropertyChanget();
            }
        }
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
        public AddNewRepairCertificateViewModel(Window window) : base(window) { }

        private RelayCommand _addNewRepaiCertificateCommand;
        public RelayCommand AddNewRepaiCertificateCommand
        {
            get
            {
                return _addNewRepaiCertificateCommand ??
                    (_addNewRepaiCertificateCommand = new RelayCommand(AddNewRepairCertificate));
            }
        }
        private void AddNewRepairCertificate(object data)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.RepairCertificates.Add(new RepairCertificate
                {
                    DateOfPreparation = DateTime.Now,
                    EmployeeId = Employee.Id,
                    EquipmentId = Equipment.Id,
                    RepairPrice = this.RepairPrice,
                    Comment = this.Comment
                }) ;
                db.SaveChanges();
                db.Equipment.FirstOrDefault(e => e.Id == Equipment.Id).SpentOfRepair +=this.RepairPrice;              
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
