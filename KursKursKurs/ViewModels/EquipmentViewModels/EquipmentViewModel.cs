using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class EquipmentViewModel: ViewModel
    {
        public List<Equipment> Equipment { get; set; }
        public EquipmentViewModel(Window window) : base(window) 
        {
            EquipmentInitialization();
        }


        private RelayCommand _addNewEquipmentCommand;

        public RelayCommand AddNewEquipmentCommand
        {
            get
            {
                return _addNewEquipmentCommand ??
                    (_addNewEquipmentCommand = new RelayCommand(AddNewEquipment));
            }
        }
        private void AddNewEquipment(object data)
        {
            AddNewEquipmentWindow addNewEquipmentWindow = new AddNewEquipmentWindow();
            if (addNewEquipmentWindow.ShowDialog() == true)
            {
                EquipmentInitialization();
            }
        }
        
        private void EquipmentInitialization()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Equipment = db.Equipment.ToList();
            }            
        }
    }
}
