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

namespace DIPloma.Window
{
    /// <summary>
    /// Interaction logic for wdCalendar.xaml
    /// </summary>
    public partial class wdCalendar
    {
        Teacher Teacher;

        private DateTime _teacherHB = DateTime.Today;
        public DateTime TeacherHB => _teacherHB;

        public wdCalendar(DateTime dataSelect)
        {
            _teacherHB = dataSelect;
            InitializeComponent();
        }

        private void clSaveDate(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void sdcDateHB(object sender, SelectionChangedEventArgs e)
        {
            DateTime? date = calendar1.SelectedDate;
            _teacherHB = date.Value;
        }
    }
}
