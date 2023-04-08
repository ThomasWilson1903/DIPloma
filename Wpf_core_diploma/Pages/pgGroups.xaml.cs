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

namespace DIPloma.Pages
{
    /// <summary>
    /// Interaction logic for pgGroups.xaml
    /// </summary>
    public partial class pgGroups : Page
    {
        int listitems;
        public pgGroups(int listitems)
        {
            InitializeComponent();
            select();
            this.listitems = listitems;
        }

        void select()
        {
            IEnumerable<EducationalClass> listClass = EfModels.init().EducationalClasses.ToList();
            
            lvMain.ItemsSource = listClass;
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new pgLvStudent(listitems, lvMain.SelectedIndex + 1)); ;
        }

        private void muSerch2(object sender, MouseButtonEventArgs e)
        {

        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {

        }

        private void mdSerch(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
