
using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using DIPloma.Pages.pgUserEntity;
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
        SolidColorBrush color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0061FF"));
        int buttonSelect;
        public pgAddUsers()
        {
            InitializeComponent();
            selectUser();
        }
        void selectUser()
        {
            /*List<User> listUsers = EfModels.init().Users.Include(p => p.RoleNavigation).ToList();
            //listUsers = listUsers.OrderBy(p => p.SurNameUser);
            listUsers = listUsers.Where(p => p.SurNameUser.ToLower().Contains(tbSerch.Text.ToLower())).ToList();
            dgUserMember.ItemsSource = listUsers;*/
        }
        void selectTeacher()
        {
            /*List<Teacher> listUsers = EfModels.init().Teachers.ToList();
            //listUsers = listUsers.OrderBy(p => p.SurNameUser);
            listUsers = listUsers.Where(p => p.SurnameTeacher.ToLower().Contains(tbSerch.Text.ToLower())).ToList();
            dgUserMember.ItemsSource = listUsers;*/
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
            selectUser();
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            selectUser();
        }

        private void clSelectUser(object sender, RoutedEventArgs e)
        {
            buttonSelect = 1;

            borderTransperent();
            btUserSelect.BorderBrush = color;
            frMain.Navigate(new pgUserSelect());
            
        }

        private void clSelectTeacher(object sender, RoutedEventArgs e)
        {
            buttonSelect = 2;

            btUserSelect.BorderBrush = Brushes.Transparent;
            btTeacherSelect.BorderBrush = color;
            
        }

        private void clSelectStudent(object sender, RoutedEventArgs e)
        {
            buttonSelect = 3;

            borderTransperent();
            btStudentSelect.BorderBrush = color;
        }

        void borderTransperent()
        {
            btUserSelect.BorderBrush = Brushes.Transparent;
            btTeacherSelect.BorderBrush = Brushes.Transparent;
            btStudentSelect.BorderBrush = Brushes.Transparent;
        }
    }
}
