using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using DIPloma.Window.wdAddUserEntity;
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

namespace DIPloma.Pages.pgUserEntity
{
    /// <summary>
    /// Interaction logic for pgTeacerSelect.xaml
    /// </summary>
    public partial class pgTeacerSelect : Page
    {
        public pgTeacerSelect()
        {
            InitializeComponent();
            selectTeacher();
        }

        void selectTeacher()
        {
            IEnumerable<Teacher> listTeacher = EfModels.init().Teachers.Where(p => p.SurnameTeacher.Contains(tbSerch.Text)).ToList();
            dgUserMember.ItemsSource = listTeacher;
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            selectTeacher();
        }

        private void clChang(object sender, RoutedEventArgs e)
        {
            Teacher chang = (sender as Button).DataContext as Teacher;
            new wdTeacherAddEntity(chang).ShowDialog();
            NavigationService.Navigate(new pgTeacerSelect());
        }

        private void clDel(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Уверены? ", "Уверены? ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                Teacher del = (sender as Button).DataContext as Teacher;

                List<DataBase.Entity.ListItem> delListItems = EfModels.init().ListItems.Where(p => p.Teachers == del.IdTeachers).ToList();
                if (delListItems.Count > 0)
                {
                    for (int i = 0; i < delListItems.Count; i++)
                    {
                        EfModels.init().Remove(delListItems[i]);
                    }

                }
                EfModels.init().Remove(del);
                EfModels.init().SaveChanges();
                NavigationService.Navigate(new pgTeacerSelect());
            }
        }
    }
}
