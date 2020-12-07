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
    /// Логика взаимодействия для AddRepairCertificateWindow.xaml
    /// </summary>
    public partial class AddNewRepairCertificateWindow : Window
    {
        public AddNewRepairCertificateViewModel Context { get; set; }
        public AddNewRepairCertificateWindow()
        {
            InitializeComponent();
            Context = new AddNewRepairCertificateViewModel(this);
            DataContext = Context;
        }
    }
}
