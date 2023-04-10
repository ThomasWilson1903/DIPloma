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
using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using DIPloma.Pages;

namespace DIPloma.Window
{
    /// <summary>
    /// Interaction logic for WdAuthorization.xaml
    /// </summary>
    public partial class WdAuthorization 
    {


        private User? _authUser;
        public User? AuthUser => _authUser;

        public WdAuthorization()
        {

            InitializeComponent();
           
        }
        



        private void hidePassChecked(object sender, RoutedEventArgs e)
        {

        }

        private void showPassChecked(object sender, RoutedEventArgs e)
        {

        }

        private void xws(object sender, MouseButtonEventArgs e)
        {

        }

        private void clEnter(object sender, RoutedEventArgs e)
        {
            _authUser = EfModels.init().Users.FirstOrDefault(u => u.Login == tbLogin.Text && (u.Password == tbPassword.Text || u.Password == pbPassword.Password));
            if (_authUser != null)
            {
                DialogResult = true;
                Close();
            }
            else
                MessageBox.Show("Ошибка! неверный логин или пароль");
        }
    }
}
