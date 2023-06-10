using DIPloma.DataBase.Entity;
using DIPloma.Pages.educationalMCon;
using DIPloma.Pages.pgManagerSections;
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
            public int id;

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
            Select2(User);
        }
        List<fun> list = new List<fun>
            {
                new fun("Управления классами")
                {
                    id = 1,
                    image = "\\Resources\\free-icon-classroom-906175.png",
                    access = 0,
                },

                new fun("Журнал")
                {
                    id = 2,
                    image = "\\Resources\\jornal 2.png",
                    access = 0,
                },
                new fun("Секции/Кружки")
                {
                    id = 5,
                    image = "\\Resources\\free-icon-innovation-1430941.png",
                    access = 0,
                },
            };
        List<fun> list1 = new List<fun>
            {
                new fun("Управления классами")
                {
                    id = 1,
                    image = "\\Resources\\free-icon-classroom-906175.png",
                    access = 0,
                },

                new fun("Журнал")
                {
                    id = 2,
                    image = "\\Resources\\jornal 2.png",
                    access = 0,
                },

                new fun("Управления пользователями")
                {
                    id = 3,
                    image = "\\Resources\\Добавить 2 2.png",
                    access = 1
                },
                new fun("Управления предметами")
                {
                    id = 4,
                    image = "\\Resources\\free-icon-frequency-2961248.png",
                    access = 0,
                },

                new fun("Секции/Кружки")
                {
                    id = 5,
                    image = "\\Resources\\free-icon-innovation-1430941.png",
                    access = 0,
                },
            };

        void Select2(User user)
        {
            switch (user.Role)
            {
                case 1:
                    lvMain.ItemsSource = list;
                    break;


                case 2:
                    lvMain.ItemsSource = list1;
                    break;

            }




        }



        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (User.Role)
            {
                case 1:
                    switch (list[lvMain.SelectedIndex].id)
                    {
                        case 1:
                            //MessageBox.Show("DW" + lvMain.SelectedIndex);
                            NavigationService.Navigate(new managerClass());

                            break;
                        case 2:
                            NavigationService.Navigate(new pgSubject(User));

                            break;
                        /* case 3:
                             NavigationService.Navigate(new pgAddUsers());
                             break;*/
                        default:
                            MessageBox.Show("Вероятнее всего, эта функция находится в разработке. Если вы уверены, " +
                                "что она должна быть доступна, попробуйте обновить программу. Обновление программы может включать " +
                                "в себя новые функции и исправления ошибок, которые могут помочь решить вашу проблему. Если обновление " +
                                "программы не решит вашу проблему, пожалуйста, свяжитесь с технической поддержкой для получения помощи.",
                                "Ошибка функционала!!");
                            break;
                    }
                    break;
                case 2:
                    switch (list1[lvMain.SelectedIndex].id)
                    {
                        case 1:
                            //MessageBox.Show("DW" + lvMain.SelectedIndex);
                            NavigationService.Navigate(new managerClass());

                            break;
                        case 2:
                            NavigationService.Navigate(new pgSubject(User));

                            break;
                        case 3:
                            NavigationService.Navigate(new pgAddUsers());
                            break;
                        case 4:
                            NavigationService.Navigate(new pgItemManager());
                            break;

                        case 5:
                            NavigationService.Navigate(new pgListSections(User));
                            break;


                        default:
                            MessageBox.Show("Вероятнее всего, эта функция находится в разработке. Если вы уверены, " +
                                "что она должна быть доступна, попробуйте обновить программу. Обновление программы может включать " +
                                "в себя новые функции и исправления ошибок, которые могут помочь решить вашу проблему. Если обновление " +
                                "программы не решит вашу проблему, пожалуйста, свяжитесь с технической поддержкой для получения помощи.",
                                "Ошибка функционала!!");
                            break;
                    }
                    break;
            }

        }
    }
}
