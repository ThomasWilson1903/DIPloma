
using DIPloma.DataBase;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DIPloma.Pages.lvAppMain;

namespace DIPloma.Pages
{
    /// <summary>
    /// Interaction logic for pgSubject.xaml
    /// </summary>
    public partial class pgSubject : Page
    {
        List<Subiectum> listItems;
        public pgSubject()
        {
            InitializeComponent();
            select();
        }
        void select()
        {
            listItems = EfModels.init().Subiecta.Where(p => p.NameSubiectum.ToLower().Contains(tbSerch.Text.ToLower())).ToList();

            lvMain.ItemsSource = listItems;
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new pgGroups(listItems[lvMain.SelectedIndex].Idobjects));
        }

        private void mdSerch(object sender, MouseButtonEventArgs e)
        {

        }

        private void muSerch2(object sender, MouseButtonEventArgs e)
        {

        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {

        }
    }
}
