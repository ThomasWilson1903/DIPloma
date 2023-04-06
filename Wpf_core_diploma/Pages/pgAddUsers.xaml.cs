
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

namespace DIPloma.Pages
{
    /// <summary>
    /// Interaction logic for pgAddUsers.xaml
    /// </summary>
    public partial class pgAddUsers : Page
    {
        public pgAddUsers()
        {
            InitializeComponent();
            select();
        }
        void select()
        {
            IEnumerable<User> listUsers = EfModels.init().Users.Include(p => p.RoleNavigation).ToList();
            listUsers = listUsers.DistinctBy(p => p.IdUserss);
            dgUserMember.ItemsSource = listUsers;
        }

        private void dgUserMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void clChang(object sender, RoutedEventArgs e)
        {

        }

        private void clDel(object sender, RoutedEventArgs e)
        {
            User Del = (sender as Button).DataContext as User;
            if (MessageBox.Show("точно да?", "dqw", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                EfModels.init().Users.Remove(Del);
                EfModels.init().SaveChanges();
            }
            select();
        }
    }
}
