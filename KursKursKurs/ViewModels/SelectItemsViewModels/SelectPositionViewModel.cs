using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursKursKurs
{
    public class SelectPositionViewModel:ViewModel
    {
        private Position selectedPosition;
        public Position SelectedPosition
        {
            get => selectedPosition;
            set
            {
                selectedPosition = value;
                OnPropertyChanget();
            }
        }

        public List<Position> Positions { get; set; }
        public SelectPositionViewModel(Window window) : base(window) 
        { 
            using(ApplicationContext db = new ApplicationContext())
            {
                Positions = db.Positions.ToList();
            }
        }

    }
}
