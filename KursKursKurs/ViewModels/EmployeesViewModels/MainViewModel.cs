using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class MainViewModel:ViewModel
    {        
        public List<Employee> Employees { get; set; }
        public MainViewModel(Window window): base(window)
        {
            EmployeeInitialization();           
        }

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
            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow();
            if (addNewEmployeeWindow.ShowDialog() == true)
            {
                EmployeeInitialization();
            }
        }

        private void EmployeeInitialization()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Employees =
                    db.Employees.
                    Include(employee => employee.Position).
                    ToList();
            }
        }
    }
}
