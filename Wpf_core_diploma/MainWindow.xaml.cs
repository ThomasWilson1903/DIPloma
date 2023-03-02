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

        bool checkAtorization;

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
            WdAuthorization wdAuthorization = new WdAuthorization();

            if (wdAuthorization.ShowDialog() == true)
            {
                //MessageBox.Show("yes");
                FrMain.Navigate(new pgListView());
                visibleUsers(true);
            }
            else
            {
                visibleUsers(false);
                MessageBox.Show("авторизацию не была выполнена");
            }

        }

        private void ClSingUp(object sender, RoutedEventArgs e)
        {
            bool checkAuthorization;

            new WdRegistration(new Userss()).ShowDialog();
        }

        private void visibleUsers(bool check)
        {
            switch (check)
            {
                case true:
                    tbFIO.Visibility = Visibility.Visible;
                    btLogin.Visibility = Visibility.Collapsed;
                    btRegister.Visibility = Visibility.Collapsed;
                    break;
                case false:
                    tbFIO.Visibility = Visibility.Collapsed;
                    break;

            }
        }
    }
}
