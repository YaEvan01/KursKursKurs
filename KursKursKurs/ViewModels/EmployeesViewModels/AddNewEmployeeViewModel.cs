using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class AddNewEmployeeViewModel:ViewModel
    {
        private Position position;
        public Position Position
        {
            get => position;
            set
            {
                position = value;
                OnPropertyChanget();
            }
        }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanget();
            }
        }
        
        public AddNewEmployeeViewModel(Window window) : base(window) { }

        private RelayCommand _addNewEmployeeCommand;

        public RelayCommand AddNewEmployeeCommand
        {
            get
            {
                return _addNewEmployeeCommand ??
                    (_addNewEmployeeCommand = new RelayCommand(AddNewEmployee));
            }
        }
        private void AddNewEmployee(object data)
        {            
            using(ApplicationContext db=new ApplicationContext())
            {
                db.Employees.Add(new Employee
                {
                    Name = this.Name,
                    PositionId = this.Position.Id,
                });
                db.SaveChanges();
            }
            _thisWindow.DialogResult=true;
        }

        private RelayCommand _selectPositionCommand;
        public RelayCommand SelectPositionCommand
        {
            get
            {
                return _selectPositionCommand ??
                    (_selectPositionCommand = new RelayCommand(SelectPosition));
            }
        }
        private void SelectPosition(object data)
        {
            SelectPositionWindow selectPositionWindow = new SelectPositionWindow();
            if (selectPositionWindow.ShowDialog() == true)
            {
                Position = selectPositionWindow.Context.SelectedPosition;
            }
        }
    }
}
