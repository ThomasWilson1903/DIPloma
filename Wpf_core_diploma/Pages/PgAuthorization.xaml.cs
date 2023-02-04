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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_core_diploma.Pages
{
    /// <summary>
    /// Interaction logic for PgAuthorization.xaml
    /// </summary>
    public partial class PgAuthorization : Page
    {
        public PgAuthorization()
        {
            InitializeComponent();
        }

        private void btRegistr(object sender, RoutedEventArgs e)
        {

        }

        private void showPassChecked(object sender, RoutedEventArgs e)
        {
            tbPassword.Text = pbPassword.Password;
            tbPassword.Visibility = Visibility.Visible;
            pbPassword.Visibility = Visibility.Collapsed;
        }

        private void hidePassChecked(object sender, RoutedEventArgs e)
        {
            pbPassword.Password = tbPassword.Text;
            tbPassword.Visibility = Visibility.Collapsed;
            pbPassword.Visibility = Visibility.Visible;
        }

        private void xws(object sender, MouseButtonEventArgs e)
        {
            TbLogin.Text = "dwdwdw";
        }
    }
}
