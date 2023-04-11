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
using System.Windows.Shapes;

namespace DIPloma.Window.wdAddUserEntity
{
    /// <summary>
    /// Interaction logic for wdTeacherAddEntity.xaml
    /// </summary>
    public partial class wdTeacherAddEntity 
    {
        Teacher Teacher;
        public wdTeacherAddEntity(Teacher teacher)
        {
            this.Teacher = teacher;
            InitializeComponent();
        }

        private void clOpenCalendarHB(object sender, RoutedEventArgs e)
        {
            wdCalendar calendar = new wdCalendar(DateTime.Today);//attention dibil
            calendar.ShowDialog();//attention dibil, da blute, aaaaa!
            MessageBox.Show($"{calendar.TeacherHB}");
        }
    }
}
