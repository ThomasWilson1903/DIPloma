using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DIPloma.Window.wdAddUserEntity
{
    /// <summary>
    /// Interaction logic for wdUserAddEntity.xaml
    /// </summary>
    public partial class wdUserAddEntity 
    {
        User User;
        public wdUserAddEntity(User user)
        {
            this.User = user;
            InitializeComponent();
            comboBox();
            DataContext = User;
        }
        void comboBox()
        {
            List<Role> role = EfModels.init().Roles.ToList();
            cbRoleUser.ItemsSource = role;
        }

        private void clSaveChangUser(object sender, RoutedEventArgs e)
        {

        }
        void downloadImage()
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All file|*.*" };

            if (openFile.ShowDialog() == true)
            {
                User.PhotoUsers = File.ReadAllBytes(openFile.FileName);

                var uri = new Uri(openFile.FileName);
                var bitmap = new BitmapImage(uri);
                ImageUser.ImageSource = bitmap;


            }
        }

        private void clDomlodeImage(object sender, RoutedEventArgs e)
        {
            downloadImage();
        }
    }
}
