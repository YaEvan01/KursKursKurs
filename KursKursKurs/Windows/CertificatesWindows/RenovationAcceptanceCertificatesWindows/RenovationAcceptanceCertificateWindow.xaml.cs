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
    /// Логика взаимодействия для RenovationAcceptanceCertificateWindow.xaml
    /// </summary>
    public partial class RenovationAcceptanceCertificateWindow : Window
    {
        public RenovationAcceptanceCertificateViewModel Context { get; set; }
        public RenovationAcceptanceCertificateWindow()
        {
            InitializeComponent();
            Context = new RenovationAcceptanceCertificateViewModel(this);
            DataContext = Context;
            MyMenu.Content = new UserControlMenu(this);
        }
    }
}
