using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class AddNewEquipmentViewModel:ViewModel
    {
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
        private int passport;
        public int Passport
        {
            get => passport;
            set
            {
                passport = value;
                OnPropertyChanget();
            }
        }
        private int form;
        public int Form
        {
            get => form;
            set
            {
                form = value;
                OnPropertyChanget();
            }
        }

        private int price;
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanget();
            }
        }
        public AddNewEquipmentViewModel(Window window) : base(window) { }

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
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Equipment.Add(new Equipment
                {
                    Name = this.Name,
                    Passport = this.Passport,
                    Form=this.Form,
                    Price=this.Price
                });
                db.SaveChanges();
            }
            _thisWindow.DialogResult = true;
        }
    }
}
