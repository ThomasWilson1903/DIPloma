using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using Microsoft.EntityFrameworkCore;
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

namespace DIPloma.Pages.pgUserEntity
{
    /// <summary>
    /// Interaction logic for pgUserSelect.xaml
    /// </summary>
    public partial class pgUserSelect : Page
    {
        public pgUserSelect()
        {
            InitializeComponent();
            selectUser();
        }

        private void clDel(object sender, RoutedEventArgs e)
        {

        }

        private void clChang(object sender, RoutedEventArgs e)
        {

        }

        void selectUser()
        {
            List<User> listUsers = EfModels.init().Users.Include(p => p.RoleNavigation).ToList();
            //listUsers = listUsers.OrderBy(p => p.SurNameUser);
            listUsers = listUsers.Where(p => p.SurNameUser.ToLower().Contains(tbSerch.Text.ToLower())).ToList();
            dgUserMember.ItemsSource = listUsers;
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            selectUser();
        }
    }
}
