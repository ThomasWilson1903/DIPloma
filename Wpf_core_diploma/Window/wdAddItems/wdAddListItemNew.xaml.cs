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
using System.Windows.Shapes;

namespace DIPloma.Window.wdAddItems
{
    /// <summary>
    /// Interaction logic for wdAddListItemNew.xaml
    /// </summary>
    public partial class wdAddListItemNew
    {
        ListItem ListItem;
        List<Subiectum> subiecta = new();
        List<Teacher> teachers = new();
        List<User> users = new();

        public wdAddListItemNew(ListItem listItem)
        {
            this.ListItem = listItem;
            InitializeComponent();
            DataContext = ListItem;
            selectSubiecta();
            selectTeachers();
            selectUser();

        }

        void selectSubiecta()
        {
            subiecta = EfModels.init().Subiecta.ToList();
            dgSubiecta.ItemsSource = subiecta;
        }

        void selectTeachers()
        {
            teachers = EfModels.init().Teachers.ToList();
            dgTeacher.ItemsSource = teachers;
        }
        void selectUser()
        {
            users = EfModels.init().Users.ToList();
            dgUsers.ItemsSource = users;

        }

        private void tcTeacher(object sender, TextChangedEventArgs e)
        {
            var list = teachers.Where(p=>p.SurnameTeacher.ToLower().ToString().Contains(tbSerchTeacher.Text.ToLower())).ToList();
            dgTeacher.ItemsSource = list;
        }

        private void tcItems(object sender, TextChangedEventArgs e)
        {
            var list = subiecta.Where(p => p.NameSubiectum.ToLower().ToString().Contains(tbSerchItems.Text.ToLower())).ToList();
            dgSubiecta.ItemsSource = list;
        }

        private void tcUser(object sender, TextChangedEventArgs e)
        {
            var list = users.Where(p=>p.SurNameUser.ToLower().ToString().Contains(tbSerchUser.Text.ToLower())).ToList();
            dgUsers.ItemsSource = list;
        }
    }
}
