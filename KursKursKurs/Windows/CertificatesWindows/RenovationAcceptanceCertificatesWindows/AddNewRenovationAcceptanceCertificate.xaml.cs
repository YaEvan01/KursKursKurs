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
    /// Логика взаимодействия для AddNewRenovatioAcceptanceCertificate.xaml
    /// </summary>
    public partial class AddNewRenovationAcceptanceCertificate : Window
    {
        public AddNewRenovationAcceptanceCertificateViewModel Context { get; set; }
        public AddNewRenovationAcceptanceCertificate()
        {
            InitializeComponent();
            Context = new AddNewRenovationAcceptanceCertificateViewModel(this);
            DataContext = Context;
        }
    }
}
