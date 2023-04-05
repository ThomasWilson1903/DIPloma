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
    /// Interaction logic for pgListViewTeacher.xaml
    /// </summary>
    public partial class pgListViewTeacher : Page
    {
        int SubiectumTeacher;
        public pgListViewTeacher(int subiectumTeacher)
        {
            this.SubiectumTeacher = subiectumTeacher;
            InitializeComponent();
            select();
        }
        void select()
        {
            IEnumerable<DataBase.Entity.ListItem> listItems = EfModels.init().ListItems.Where(p=>p.Subiectum == SubiectumTeacher).Include(p=>p.TeachersNavigation).ToList();

            lvMain.ItemsSource = listItems;
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {

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
