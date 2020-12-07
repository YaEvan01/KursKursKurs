using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class SelectEmployeeViewModel:ViewModel
    {
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanget();
            }
        }

        public List<Employee> Employees { get; set; }
        public SelectEmployeeViewModel(Window window) : base(window)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Employees = 
                    db.Employees.
                    Include(e => e.Position).
                    ToList();
            }
        }
       
    }
}
