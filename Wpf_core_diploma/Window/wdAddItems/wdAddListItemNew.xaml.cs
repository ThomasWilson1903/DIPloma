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
        List<Subiectum> subiecta1;
        List<Teacher> teachers = new();
        List<Teacher> teachers1;
        List<User> users = new();
        List<User> users1;

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
            teachers1 = teachers.Where(p => p.SurnameTeacher.ToLower().ToString().Contains(tbSerchTeacher.Text.ToLower())).ToList();
            dgTeacher.ItemsSource = teachers1;
        }

        private void tcItems(object sender, TextChangedEventArgs e)
        {
            subiecta1 = subiecta.Where(p => p.NameSubiectum.ToLower().ToString().Contains(tbSerchItems.Text.ToLower())).ToList();
            dgSubiecta.ItemsSource = subiecta1;
        }

        private void tcUser(object sender, TextChangedEventArgs e)
        {
            users1 = users.Where(p => p.SurNameUser.ToLower().ToString().Contains(tbSerchUser.Text.ToLower())).ToList();
            dgUsers.ItemsSource = users1;
        }

        private void clSaveEdit(object sender, RoutedEventArgs e)
        {
            if (ListItem.Idschedule == 0)
            {
                if (dgTeacher.SelectedItem != null)
                {
                    if (dgSubiecta.SelectedItem != null)
                    {
                        if (dgUsers.SelectedItem != null)
                        {
                            EfModels.init().Add(ListItem);
                            EfModels.init().SaveChanges();
                            Close();

                        }
                        else
                            MessageBox.Show("Выберите элемент из каждого списка");

                    }
                    else
                        MessageBox.Show("Выберите элемент из каждого списка");

                }
                else
                    MessageBox.Show("Выберите элемент из каждого списка");
            }
        }
    }
}
