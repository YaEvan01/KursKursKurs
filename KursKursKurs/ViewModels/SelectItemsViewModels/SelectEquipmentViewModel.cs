using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class SelectEquipmentViewModel:ViewModel
    {
        private Equipment selectedEquipment;
        public Equipment SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                selectedEquipment = value;
                OnPropertyChanget();
            }
        }

        public List<Equipment> Equipment { get; set; }
        public SelectEquipmentViewModel(Window window) : base(window)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Equipment = db.Equipment.ToList();
            }
        }
       
    }
}
