using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KursKursKurs
{
    /// <summary>
    /// Логика взаимодействия для SelectEmployeeWindow.xaml
    /// </summary>
    public partial class SelectEmployeeWindow : Window
    {
        public SelectEmployeeViewModel Context { get; set; }
        public SelectEmployeeWindow()
        {
            InitializeComponent();
            Context = new SelectEmployeeViewModel(this);
            DataContext = Context;
        }
    }
}
