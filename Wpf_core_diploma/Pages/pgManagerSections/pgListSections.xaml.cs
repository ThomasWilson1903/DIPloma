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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIPloma.Pages.pgManagerSections
{
    /// <summary>
    /// Interaction logic for pgListSections.xaml
    /// </summary>
    public partial class pgListSections : Page
    {

        List<Section> sections;
        User User;

        public pgListSections(User user)
        {
            this.User = user;
            InitializeComponent();
            selectListSection();
        }

        void selectListSection()
        {
            sections = EfModels.init().Sections.Where(p=>p.User == User.IdUserss).ToList();
            lvMain.ItemsSource = sections;
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Section selectItem = sections[lvMain.SelectedIndex];

            NavigationService.Navigate(new pgСontrollerAttendance(selectItem));
        }
    }
}
