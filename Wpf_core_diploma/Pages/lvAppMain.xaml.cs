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
    /// Interaction logic for lvAppMain.xaml
    /// </summary>
    public partial class lvAppMain : Page
    {

        public class fun
        {
            public string namefun { get; set; }

            public string? image { get; set; }
            
            public fun(string name)
            {
                namefun = name;
            }
        }

        public lvAppMain()
        {
            InitializeComponent();
            Select();
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            Select();
        }

        void Select()
        {
            IEnumerable<fun> list = new List<fun>
            {
                new fun("тестовая иконка")
                {
                    image = "\\Resources\\free-icon-dark-mode-6714978.png"
                },

                new fun("Журнал")
                {
                    image = "\\Resources\\jornal 2.png"
                },

                new fun("Добавления пользователя")
                {
                    image = "\\Resources\\Добавить 2 2.png"
                }
            }.Where(p=>p.namefun.ToLower().Contains(tbSerch.Text.ToLower()));
            lvMain.ItemsSource = list;
        }

        private void mdSerch(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(tbSerch);
        }

        private void muSerch2(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(tbSerch);
        }
    }
}
