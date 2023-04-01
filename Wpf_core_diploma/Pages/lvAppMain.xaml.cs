using DIPloma.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for lvAppMain.xaml
    /// </summary>
    public partial class lvAppMain : Page
    {

        public class fun
        {
            public string namefun { get; set; }

            public string? image { get; set; }

            public int? access { get; set; }

            public fun(string name)
            {
                namefun = name;
            }
        }
        User User;
        public lvAppMain(User user)
        {
            User = user;
            InitializeComponent();
            Select2(User);
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            //Select2(User);
        }



        void Select2(User user)
        {
            switch (user.Role)
            {
                case 1:
                    IEnumerable<fun> list = new List<fun>
            {
                new fun("тестовая иконка")
                {
                    image = "\\Resources\\free-icon-dark-mode-6714978.png",
                    access = 0,
                },

                new fun("Журнал")
                {
                    image = "\\Resources\\jornal 2.png",
                    access = 0,
                },
            }.Where(p => p.namefun.ToLower().Contains(tbSerch.Text.ToLower()));
                    lvMain.ItemsSource = list;
                    break;
                case 2:
                    IEnumerable<fun> list1 = new List<fun>
            {
                new fun("тестовая иконка")
                {
                    image = "\\Resources\\free-icon-dark-mode-6714978.png",
                    access = 0,
                },

                new fun("Журнал")
                {
                    image = "\\Resources\\jornal 2.png",
                    access = 0,
                },

                new fun("Добавления пользователя")
                {
                    image = "\\Resources\\Добавить 2 2.png",
                    access = 1
                }
            }.Where(p => p.namefun.ToLower().Contains(tbSerch.Text.ToLower()));
                    lvMain.ItemsSource = list1;
                    break;

            }




        }

        private void mdSerch(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(tbSerch);
        }

        private void muSerch2(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(tbSerch);
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (lvMain.SelectedIndex)
            {
                case 0:
                    //MessageBox.Show("DW" + lvMain.SelectedIndex);
                    NavigationService.Navigate(new PgWelcomes());

                    break;
                case 1:
                    NavigationService.Navigate(new pgLvStudent());

                    break;
                case 2:
                    MessageBox.Show("В разработки функция №" + lvMain.SelectedIndex);

                    break;
            }
        }
    }
}
