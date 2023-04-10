
using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using DIPloma.Pages.pgUserEntity;
using DIPloma.Window.wdAddUserEntity;
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
        int buttonSelect = 1;
        public pgAddUsers()
        {
            InitializeComponent();
            frMain.Navigate(new pgUserSelect());
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
        }


        private void clSelectUser(object sender, RoutedEventArgs e)
        {
            buttonSelect = 1;
            btAddUserEntity.Content = "+ Добавить пользователя";
            borderTransperent();
            btUserSelect.BorderBrush = color;
            frMain.Navigate(new pgUserSelect());

        }

        private void clSelectTeacher(object sender, RoutedEventArgs e)
        {
            buttonSelect = 2;

            btAddUserEntity.Content = "+ Добавить учителя";
            borderTransperent();
            btTeacherSelect.BorderBrush = color;
            frMain.Navigate(new pgTeacerSelect());
        }

        private void clSelectStudent(object sender, RoutedEventArgs e)
        {
            buttonSelect = 3;
            btAddUserEntity.Content = "+ Добавить ученика";

            borderTransperent();
            btStudentSelect.BorderBrush = color;
            frMain.Navigate(new pgStudentSelect());
        }

        void borderTransperent()
        {
            btUserSelect.BorderBrush = Brushes.Transparent;
            btTeacherSelect.BorderBrush = Brushes.Transparent;
            btStudentSelect.BorderBrush = Brushes.Transparent;
        }

        private void clAddUser(object sender, RoutedEventArgs e)
        {
            switch (buttonSelect)
            {
                case 1:
                    new wdUserAddEntity().ShowDialog();
                    frMain.Navigate(new pgUserSelect());
                    break;
                case 2:
                    new wdTeacherAddEntity(new Teacher()).ShowDialog();
                    frMain.Navigate(new pgTeacerSelect());
                    break;
                case 3:
                    //new wdUserAddEntity().ShowDialog();
                    frMain.Navigate(new pgStudentSelect());
                    break;

            }
        }
    }
}
