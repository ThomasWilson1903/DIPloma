using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using DIPloma.Window;
using DIPloma.Window.wdAddItems;
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
using ListItem = DIPloma.DataBase.Entity.ListItem;

namespace DIPloma.Pages
{
    /// <summary>
    /// Interaction logic for pgItemManager.xaml
    /// </summary>
    public partial class pgItemManager : Page
    {
        List<Subiectum> subiecta = new();
        List<ListItem> listItems = new();

        public pgItemManager()
        {
            InitializeComponent();
            selectDataGrid();
            selectItem();
        }
        void selectItem()
        {
            subiecta = EfModels.init().Subiecta.ToList();
            lvItems.ItemsSource = subiecta;
        }


        void selectDataGrid()
        {
            listItems = EfModels.init().ListItems.Include(p => p.SubiectumNavigation).Include(p => p.TeachersNavigation).Include(p => p.UsersNavigation).ToList();
            dgItemsList.ItemsSource = listItems;
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IEnumerable<ListItem> list = listItems;
            list = list.Where(p=>p.Subiectum == subiecta[lvItems.SelectedIndex].Idobjects);
            dgItemsList.ItemsSource = list;
        }

        private void clRestartListItem(object sender, RoutedEventArgs e)
        {
            selectDataGrid();
        }

        private void clAddItems(object sender, RoutedEventArgs e)
        {
            new wdAddItems(new Subiectum()).ShowDialog();
            selectItem();
        }
    }
}
