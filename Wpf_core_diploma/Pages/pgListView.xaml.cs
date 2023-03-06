
using DIPloma._1.DataBase.Entity;
using DIPloma.DataBase;
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
    /// Interaction logic for pgListView.xaml
    /// </summary>
    public partial class pgListView : Page
    {
        public pgListView()
        {
            InitializeComponent();
            List<User> users = EfModels.init().Users.ToList();
            lvMain.ItemsSource = users;

        }
    }
}
