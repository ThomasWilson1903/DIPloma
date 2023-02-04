using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_core_diploma.Database.Entity;
using Wpf_core_diploma.Pages;
using Wpf_core_diploma.Window;

namespace Wpf_core_diploma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            FrMains();
        }
        void FrMains()
        {
            FrMain.Navigate(new PgWelcomes());
        }

        private void ClSingIn(object sender, RoutedEventArgs e)
        {
            new WdAuthorization().ShowDialog();
            
        }

        private void ClSingUp(object sender, RoutedEventArgs e)
        {
            bool checkAuthorization;

            new WdRegistration(new Userss()).ShowDialog();
        }
    }
}
