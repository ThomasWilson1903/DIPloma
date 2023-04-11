using DIPloma.DataBase.Entity;
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
            DataContext = User;
            InitializeComponent();
        }

        private void clSaveChangUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
