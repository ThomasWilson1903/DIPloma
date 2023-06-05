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
using DIPloma.DataBase.Entity;
using DIPloma.Pages;
using DIPloma.Pages.pgUserEntity;
using DIPloma.Window;

namespace DIPloma
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
            visibleUsers(false);

        }
        void FrMains()
        {
            //FrMain.Navigate(new pgAddUsers());
        }

        private void ClSingIn(object sender, RoutedEventArgs e)
        {
            WdAuthorization wdAuthorization = new WdAuthorization();

            if (wdAuthorization.ShowDialog() == true && wdAuthorization.AuthUser != null)
            {
                User user = wdAuthorization.AuthUser;
                FrMain.Navigate(new lvAppMain(user));
                MessageBox.Show(user.SurNameUser + " " + user.NameUser + " " + user.DobleNameUser);
                visibleUsers(true);
                tbFIO.Text = user.SurNameUser + " " + user.NameUser + " " + user.DobleNameUser;
                DataContext = user;


                //ibImage.ImageSource = ImageBrush(user.PhotoUsers);
            }
            else
            {
                visibleUsers(false);
                MessageBox.Show("авторизацию не была выполнена");
            }

        }

        private void ClSingUp(object sender, RoutedEventArgs e)
        {

        }

        private void visibleUsers(bool check)
        {
            switch (check)
            {
                case true:
                    tbFIO.Visibility = Visibility.Visible;
                    btLogin.Visibility = Visibility.Collapsed;
                    elImage.Visibility = Visibility.Visible;
                    btBack.Visibility = Visibility.Visible;
                    btFrameBacks.Visibility = Visibility.Visible;
                    break;
                case false:
                    tbFIO.Visibility = Visibility.Collapsed;
                    elImage.Visibility = Visibility.Collapsed;
                    btLogin.Visibility = Visibility.Visible;
                    btBack.Visibility = Visibility.Collapsed;
                    btFrameBacks.Visibility = Visibility.Collapsed;
                    break;

            }
        }

        private void muBack(object sender, MouseButtonEventArgs e)
        {
            //FrMain.Navigate(new PgWelcomes());
            //FrMain.RemoveBackEntry();
            FrMain.Navigate(new PgWelcomes());
            ClearHistory();
            visibleUsers(false);
        }
        public void ClearHistory()
        {
            if (!this.FrMain.CanGoBack && !this.FrMain.CanGoForward)
            {
                return;
            }

            var entry = this.FrMain.RemoveBackEntry();
            while (entry != null)
            {
                entry = this.FrMain.RemoveBackEntry();
            }

            this.FrMain.Navigate(new PageFunction<string>() { RemoveFromJournal = true });
        }

        private void clBackFrame(object sender, RoutedEventArgs e)
        {
            if (FrMain.CanGoBack)
            {
                FrMain.NavigationService.GoBack();
            }
        }
    }//Server=twilson.ru;Port=3306;User ID=Diplom2;Password=QvjG{td4lrrb;Database=ISPr22-33_BirukovAA_WpfApp_diploma2;Character Set=utf8
    //scaffold-dbContext "Server=twilson.ru;Port=3306;User ID=Diplom2;Password=QvjG{td4lrrb;Database=ISPr22-33_BirukovAA_WpfApp_diploma2;Character Set=utf8" Pomelo.EntityFrameworkCore.MySql -contextDir DataBase -outputDir DataBase/Entity
}
