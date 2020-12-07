﻿using System;
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
    /// Логика взаимодействия для RepairsTransferReportWindow.xaml
    /// </summary>
    public partial class RepairsTransferReportWindow : Window
    {
        public RepairsTransferReportWindow()
        {
            InitializeComponent();
            DataContext =new RepairsTransferReportViewModel(this);
            myMenu.Content = new UserControlMenu(this);
        }

        
    }
}
